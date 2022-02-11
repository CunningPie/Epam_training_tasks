using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollectionMethdosLibrary
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private T[] _collection;

        /// <summary>
        /// Базовый конструктор стека.
        /// </summary>
        public CustomStack()
        {
            _collection = new T[10];
            Count = 0;
        }

        /// <summary>
        /// Конструктор стека, принимающий на вход коллекцию элементов.
        /// </summary>
        /// <param name="collection"></param>
        public CustomStack(T[] collection)
        {
            _collection = collection;
            Count = _collection.Length;
        }

        /// <summary>
        /// Возвращает количество элементов в стеке.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Проверяет пустой ли стек.
        /// </summary>
        /// <returns>Возвращает true если стек пуст, false - иначе.</returns>
        public bool IsEmpty()
        {
            if (Count == 0)
                return true;

            return false;
        }

        /// <summary>
        /// Добавляет элемент в стек.
        /// </summary>
        /// <param name="item"></param>

        public void Push(T item)
        {
            if (Count == _collection.Length)
            {
                Resize(Count);
            }

            _collection[Count++] = item;
        }

        /// <summary>
        /// Убирает верхний элемент из стека и возвращает его.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            T item = _collection[--Count];
            _collection[Count] = default(T);

            return item;
        }

        /// <summary>
        /// Берет верхний элемент стека.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return _collection[Count - 1];
        }

        /// <summary>
        /// Получает коллекцию стека начиная с верха.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return _collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        private void Resize(int size)
        {
            T[] newSizeCollection = new T[size * 2];

            for (int i = 0; i < _collection.Length; i++)
            {
                newSizeCollection[i] = _collection[i];
            }

            _collection = newSizeCollection;
        }
    }
}
