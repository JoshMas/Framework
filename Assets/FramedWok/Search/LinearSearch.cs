using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FramedWok.Searching
{
    public static class LinearSearch
    {
        /// <summary>
        /// Search for an item though a list from start to end
        /// Not the most efficient, but it works on unsorted lists
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="itemToLookFor"></param>
        /// <returns></returns>
        public static T Search<T>(List<T> list, T itemToLookFor) where T : IComparable<T>
        {
            foreach(T item in list)
            {
                if(item.CompareTo(itemToLookFor) == 0)
                {
                    return item;
                }
            }
            return default;
        }
    }
}