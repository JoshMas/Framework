using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FramedWok.Inventory
{
    public class Item : MonoBehaviour, IComparable<Item>
    {
        /// <summary>
        /// The maximum number of items that can fit into one slot in the inventory
        /// </summary>
        [SerializeField] private int maximumStack;
        /// <summary>
        /// The name of the item
        /// </summary>
        [SerializeField] private string itemName;

        /// <summary>
        /// Compares the two items using their names
        /// </summary>
        /// <returns>-1 if the first number is smaller, 1 if it is larger, and 0 if they are equal</returns>
        public int CompareTo(Item other)
        {
            return name.CompareTo(other.itemName);
        }
    }
}