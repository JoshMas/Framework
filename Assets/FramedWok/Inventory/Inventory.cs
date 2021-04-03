using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FramedWok.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private int width;
        [SerializeField]
        private int height;

        private List<List<ItemStack>> inventory;

        private HeapSort sortingAlgorithm;

        // Start is called before the first frame update
        void Start()
        {
            sortingAlgorithm = gameObject.AddComponent<HeapSort>();
        }

        /// <summary>
        /// Puts the inventory into a one-dimensional list to be sorted
        /// </summary>
        private List<ItemStack> FlattenInventory(List<List<ItemStack>> itemStacks)
        {
            List<ItemStack> flatList = new List<ItemStack>();
            foreach(List<ItemStack> list in itemStacks)
            {
                flatList.AddRange(list);
            }
            return flatList;
        }

        /// <summary>
        /// Sorts a list using the Heap sort algorithm
        /// </summary>
        /// <param name="unsortedList"></param>
        private List<ItemStack> SortInventory(List<ItemStack> unsortedList)
        {
            return sortingAlgorithm.HeapSortAlgorithm(unsortedList);
        }

        /// <summary>
        /// Puts a flat list into the inventory
        /// </summary>
        /// <param name="sortedList"></param>
        private void InsertSortedInventory(List<ItemStack> sortedList)
        {
            for(int i = 0; i < sortedList.Count; i++)
            {
                inventory[i / width][i % width] = sortedList[i];
            }
        }
    }
}