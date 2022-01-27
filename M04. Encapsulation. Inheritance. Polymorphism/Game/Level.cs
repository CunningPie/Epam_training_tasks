using Ardalis.GuardClauses;
using Game.Units;
using Game.Units.Basic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    /// <summary>
    /// Класс уровня. Отвечает за создание, запуск и контроль игрового уровня.
    /// </summary>
    public class Level
    {
        private Field _field;
        private Player _player;
        int _score = 0;
        State[,] _map;

        private Position SelectEmptyPos(int width, int height)
        {
            Position newPos;

            do
            {
                newPos = Position.GenerateRandomPos(width, height);
            }
            while (_map[newPos.PosX, newPos.PosY] != State.Empty);

            return newPos;
        }

        private List<Unit> GenerateUnits<T>(int count, int width, int height) where T : Unit
        {
            List<Unit> units = new List<Unit>();

            for (int i = 0; i < count; i++)
            {
                Position newPos = SelectEmptyPos(width, height);

                if (newPos == null)
                {
                    break;
                }

                State newState = State.Empty;

                T newUnit = (T)Activator.CreateInstance(typeof(T), newPos);

                switch (newUnit)
                {
                    case Wolf:
                    case Bear:
                    case Apple:
                    case Cherry:
                    case Melon:
                        newState = State.Visitable;
                        break;
                    case Wall:
                        newState = State.Obstacle;
                        break;
                }

                _map[newPos.PosX, newPos.PosY] = newState;

                units.Add(newUnit);
            }

            return units;
        }

        /// <summary>
        /// Генерация случайной карты размера width x heigth.
        /// </summary>
        public void GenerateLevel(int width, int height)
        {
            List<Unit> obstacles = new List<Unit>();
            List<IMovable> movingUnits = new List<IMovable>();
            List<Unit> bonuses = new List<Unit>();

            Random rand = new Random();

            _map = new State[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    _map[i, j] = State.Empty;
                }
            }

            _player = new Player(rand.Next() % width, rand.Next() % height);
            _map[_player.Position.PosX, _player.Position.PosY] = State.Player;

            obstacles = GenerateUnits<Wall>(width * height / 5, width, height);
            movingUnits.AddRange(GenerateUnits<Wolf>(width * height / 200 + 1, width, height).ConvertAll(x => { return x as IMovable; }));
            movingUnits.AddRange(GenerateUnits<Bear>(width * height / 200 + 1, width, height).ConvertAll(x => { return x as IMovable; }));
            bonuses.AddRange(GenerateUnits<Cherry>(width * height / 100 + 1, width, height));
            bonuses.AddRange(GenerateUnits<Apple>(width * height / 100 + 1, width, height));
            bonuses.AddRange(GenerateUnits<Melon>(width * height / 100 + 1, width, height));

            _field = new Field(width, height, obstacles, bonuses, movingUnits);
        }

        private bool CheckPosition(Position pos)
        {
            return 
                pos.PosX >= 0
                && pos.PosX < _field.Width
                && pos.PosY >= 0
                && pos.PosY < _field.Height
                && _map[pos.PosX, pos.PosY] != State.Obstacle;
        }

        private IVisitable FindVisitedUnit(Position pos)
        {
            var visitable = new List<IVisitable>();

            visitable.AddRange(_field.MovingUnits.ConvertAll(x => x as IVisitable));
            visitable.AddRange(_field.Bonuses.ConvertAll(x => x as IVisitable));

            return visitable.Where(x => (x as Unit).Position.Equals(pos)).FirstOrDefault();
        }

        private bool PlayerInput(ConsoleKeyInfo input, ref Position playerPosition)
        {
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    playerPosition.ChangePosY(_player.Position.PosY + 1);
                    break;
                case ConsoleKey.DownArrow:
                    playerPosition.ChangePosY(_player.Position.PosY - 1);
                    break;
                case ConsoleKey.LeftArrow:
                    playerPosition.ChangePosX(_player.Position.PosX - 1);
                    break;
                case ConsoleKey.RightArrow:
                    playerPosition.ChangePosX(_player.Position.PosX + 1);
                    break;
                default:
                    return false;
            }

            return true;
        }

        private bool Turn()
        {
            Position playerPosition = new(_player.Position.PosX, _player.Position.PosY);
            bool correctInput = false;

            while (!correctInput)
            {
                correctInput = PlayerInput(Console.ReadKey(), ref playerPosition);
            }

            if (CheckPosition(playerPosition))
            {
                if (_map[playerPosition.PosX, playerPosition.PosY] == State.Visitable)
                {
                    var visitedUnit = FindVisitedUnit(playerPosition);
                    Guard.Against.Default(visitedUnit, nameof(visitedUnit));

                    if (visitedUnit.Visit() < 0)
                    {
                        return false;
                    }
                    else
                    {
                        _score += visitedUnit.Visit();
                        if (!_field.DeleteBonus(playerPosition))
                        {
                            _score += 1000;
                            return false;
                        }
                    }
                }
                _map[_player.Position.PosX, _player.Position.PosY] = State.Empty;
                _map[playerPosition.PosX, playerPosition.PosY] = State.Player;
                _player.Move(playerPosition);
            }

            foreach (var movingUnit in _field.MovingUnits)
            {
                List<Position> freePositions = new List<Position>();
                int posX = (movingUnit as Unit).Position.PosX;
                int posY = (movingUnit as Unit).Position.PosY;

                _map[posX, posY] = State.Empty;

                freePositions.Add(new Position(posX, posY));

                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if ( posX + i >= 0 
                            && posX + i < _field.Width
                            && posY + j >= 0 
                            && posY + j < _field.Height
                            && (i + j) % 2 != 0
                            && (_map[posX + i, posY + j] == State.Empty || _map[posX + i, posY + j] == State.Player))
                        {
                            freePositions.Add(new Position(posX + i, posY + j));
                        }
                    }
                }

                var newUnitPos = movingUnit.TurnMove(freePositions, _player.Position);

                if (newUnitPos.Equals(_player.Position))
                {
                    return false;
                }

                _map[newUnitPos.PosX, newUnitPos.PosY] = State.Visitable;
            }

            return true;
        }

        private char[,] CreateLevelOutput()
        {
            char[,] map = new char[_field.Width, _field.Height];

            for (int i = 0; i < _field.Width; i++)
            {
                for (int j = 0; j < _field.Height; j++)
                {
                    map[i, j] = '.';
                }
            }

            foreach (var obst in _field.Obstacles)
            {
                map[obst.Position.PosX, obst.Position.PosY] = obst.Symbol;
            }

            foreach (var unit in _field.MovingUnits)
            {
                map[(unit as Unit).Position.PosX, (unit as Unit).Position.PosY] = (unit as Unit).Symbol;
            }

            foreach (var bonus in _field.Bonuses)
            {
                map[bonus.Position.PosX, bonus.Position.PosY] = bonus.Symbol;
            }

            map[_player.Position.PosX, _player.Position.PosY] = _player.Symbol;

            return map;
        }

        private void DisplayMap()
        {
            var map = CreateLevelOutput();

            for (int j = _field.Height - 1; j >= 0; j--)
            {
                for (int i = 0; i < _field.Width; i++)
                {
                    switch (map[i, j])
                    {
                        case 'W':
                        case 'B':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 'P':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case 'A':
                        case 'C':
                        case 'M':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }

                    Console.Write(map[i, j]);
                }

                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Запускает уровень.
        /// </summary>
        public void Start()
        {
            DisplayMap();

            while (Turn())
            {
                Console.Clear();
                DisplayMap();
            }

            Console.Clear();
            Console.WriteLine("Gameover!");
            Console.WriteLine("Total score: " + _score);

            _score = 0;
        }
    }
}
