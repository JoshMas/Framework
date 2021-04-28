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

        [SerializeField] private Sprite itemSprite;

        /// <summary>
        /// Compares the two items using their names
        /// </summary>
        /// <returns>-1 if the first item is sorted lower, 1 for higher, and 0 if they are equal</returns>
        public int CompareTo(Item other)
        {
            return name.CompareTo(other.itemName);
        }

        /// <summary>
        /// Check if a value is over the number of items that fit in one stack
        /// </summary>
        public bool OverMaximum(int amount)
        {
            return amount > maximumStack;
        }
    }
}