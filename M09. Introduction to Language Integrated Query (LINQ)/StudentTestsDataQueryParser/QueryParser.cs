using Ardalis.GuardClauses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentTestsDataQueryParser
{
    /// <summary>
    /// Предоставляет методы работы с данными тестов студентов.
    /// </summary>
    public class QueryParser
    {
        private readonly List<StudentTest> _testsData;

        /// <summary>
        /// Загружает данные тестов из json файла.
        /// </summary>
        public QueryParser(string fileName)
        {
            Guard.Against.NullOrEmpty(fileName, nameof(fileName));
            Guard.Against.InvalidInput(fileName, nameof(fileName), (x) => { return x.Contains(".json"); });

            using (var reader = new StreamReader(fileName))
            {
                var testsData = reader.ReadToEnd();
                _testsData = JsonConvert.DeserializeObject<List<StudentTest>>(testsData, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
            }
        }

        private List<StudentTest> WhereName(IQueryable<StudentTest> data, string name)
        {
            return data.Where(x => x.Name.Contains(name)).ToList();
        }

        private List<StudentTest> WhereTest(IQueryable<StudentTest> data, string test)
        {
            return data.Where(x => x.Test == test).ToList();
        }

        private List<StudentTest> WhereDate(IQueryable<StudentTest> data, string date)
        {
            return data.Where(x => DateTime.Compare(x.Date, DateTime.Parse(date)) == 0).ToList();
        }

        private List<StudentTest> WhereDateFrom(IQueryable<StudentTest> data, string date)
        {
            return data.Where(x => DateTime.Compare(x.Date, DateTime.Parse(date)) >= 0).ToList();
        }

        private List<StudentTest> WhereDateTo(IQueryable<StudentTest> data, string date)
        {
            return data.Where(x => DateTime.Compare(x.Date, DateTime.Parse(date)) <= 0).ToList();
        }

        private List<StudentTest> WhereMark(IQueryable<StudentTest> data, string mark)
        {
            return data.Where(x => x.Mark == int.Parse(mark)).ToList();
        }

        private List<StudentTest> WhereMinMark(IQueryable<StudentTest> data, string mark)
        {
            return data.Where(x => x.Mark >= int.Parse(mark)).ToList();
        }

        private List<StudentTest> WhereMaxMark(IQueryable<StudentTest> data, string mark)
        {
            return data.Where(x => x.Mark <= int.Parse(mark)).ToList();
        }

        private List<StudentTest> SortAsc(IQueryable<StudentTest> data, string param)
        {
            switch (param.ToLowerInvariant())
            {
                case "name":
                    return data.OrderBy(x => x.Name).ToList();
                case "test":
                    return data.OrderBy(x => x.Test).ToList();
                case "mark":
                    return data.OrderBy(x => x.Mark).ToList();
                case "date":
                    return data.OrderBy(x => x.Date).ToList();
                default:
                    throw new ArgumentException("Invalid sort parameter!");
            }
        }

        private List<StudentTest> SortDesc(IQueryable<StudentTest> data, string param)
        {
            switch (param.ToLowerInvariant())
            {
                case "name":
                    return data.OrderByDescending(x => x.Name).ToList();
                case "test":
                    return data.OrderByDescending(x => x.Test).ToList();
                case "mark":
                    return data.OrderByDescending(x => x.Mark).ToList();
                case "date":
                    return data.OrderByDescending(x => x.Date).ToList();
                default:
                    throw new ArgumentException("Invalid sort parameter!");
            }
        }

        /// <summary>
        /// Разбирает строку запроса по ключевым словам и возвращает результат запроса.
        /// </summary>
        public List<StudentTest> ParseQuery(string query)
        {
            Guard.Against.NullOrEmpty(query, nameof(query));

            var parameters = query.Split(" ").Where(x => x != "").ToArray();
            var result = _testsData;

            try
            {
                for (var i = 0; i < parameters.Length; i++)
                {
                    if (parameters.Length < i + 2)
                    {
                        throw new ArgumentException("Invalid amount of parameters in query!");
                    }

                    switch (parameters[i].ToLowerInvariant())
                    {
                        case "-name":
                            result = WhereName(result.AsQueryable(), parameters[++i]);
                            break;
                        case "-test":
                            result = WhereTest(result.AsQueryable(), parameters[++i]);
                            break;
                        case "-mark":
                            result = WhereMark(result.AsQueryable(), parameters[++i]);
                            break;
                        case "-minmark":
                            result = WhereMinMark(result.AsQueryable(), parameters[++i]);
                            break;
                        case "-maxmark":
                            result = WhereMaxMark(result.AsQueryable(), parameters[++i]);
                            break;
                        case "-date":
                            result = WhereDate(result.AsQueryable(), parameters[++i]);
                            break;
                        case "-datefrom":
                            result = WhereDateFrom(result.AsQueryable(), parameters[++i]);
                            break;
                        case "-dateto":
                            result = WhereDateTo(result.AsQueryable(), parameters[++i]);
                            break;
                        case "-sort":
                            if (parameters.Length < i + 3)
                            {
                                throw new ArgumentException("Invalid amount of parameters in query!");
                            }

                            switch (parameters[++i + 1])
                            {
                                case "asc":
                                    result = SortAsc(result.AsQueryable(), parameters[i++]);
                                    break;
                                case "desc":
                                    result = SortDesc(result.AsQueryable(), parameters[i++]);
                                    break;
                                default:
                                    throw new ArgumentException("Invalid sort flag!");
                            }
                            break;
                        default:
                            throw new ArgumentException("Invalid query input!");
                    }
                }
            } catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return result;
        }
    }
}
