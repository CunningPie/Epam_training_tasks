using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomCollectionMethdosLibrary
{
    /// <summary>
    /// Расширение generic коллекций, реализующих интерфейс IList, методом бинарного поиска .
    /// </summary>
    public static class BinarySearchCollectionExtension
    {
        private static bool IsSorted<T>(this IList<T> collection)
            where T : IComparable<T>
        {
            Guard.Against.Null(collection, nameof(collection));

            for (int i = 0; i < collection.Count - 1; i++)
            {
                if (collection[i].CompareTo(collection[i + 1]) > 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Бинарный поиск по коллекции.
        /// </summary>
        /// <typeparam name="TCollection">Тип коллекции, реализующий интерфейс IList.</typeparam>
        /// <typeparam name="TItem">Тип элементов коллекции, реализующий IComparable и IEquatable.</typeparam>
        /// <param name="collection"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static int CustomBinarySearch<TCollection, TItem>(this TCollection collection, TItem item)
            where TCollection : IList<TItem>
            where TItem : IComparable<TItem>, IEquatable<TItem>
        {
            Guard.Against.NullOrEmpty(collection, nameof(collection));
            Guard.Against.Null(item, nameof(item));

            if (!collection.IsSorted())
            {
                throw new ArgumentException("Collection is not sorted!");
            }

            int botIndex = 0;
            int upIndex = collection.Count;
            int itemIndex = (upIndex - botIndex) / 2;
            bool searchFlag = true;

            while (searchFlag)
            {
                if (collection[itemIndex].Equals(item))
                {
                    return itemIndex;
                }
                else
                {
                    if (itemIndex == botIndex || itemIndex == upIndex)
                    {
                        return -1;
                    }
                    if (item.CompareTo(collection[itemIndex]) > 0)
                    {
                        botIndex = itemIndex;
                    }
                    else
                    {
                        upIndex = itemIndex;
                    }

                    itemIndex = botIndex + (upIndex - botIndex) / 2;
                }

                searchFlag = itemIndex >= 0 && itemIndex < collection.Count;
            }

            return -1;
        }
    }
}
