using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FramedWok.Inventory {
    public class ItemStack : IComparable<ItemStack>
    {
        private Item item;
        private int itemCount;

        public Button inventorySlot;

        /// <summary>
        /// Compares the two items using their names
        /// </summary>
        /// <returns>-1 if the first number is smaller, 1 if it is larger, and 0 if they are equal</returns>
        public int CompareTo(ItemStack other)
        {
            int itemComparison = item.CompareTo(other.item);
            if (itemComparison != 0)
            {
                return itemComparison;
            }
            else
            {
                return itemCount.CompareTo(other.itemCount);
            }
        }

        /// <summary>
        /// Check if the item stack is full
        /// </summary>
        public bool IsStackFull()
        {
            return item.OverMaximum(itemCount);
        }
    }
}