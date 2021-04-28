using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FramedWok.Sorting;
using UnityEngine.UI;

namespace FramedWok.Inventory
{
    /// <summary>
    /// Use this component to create a basic inventory screen
    /// You must attach it to a Canvas
    /// </summary>
    [RequireComponent(typeof(Canvas))]
    public class Inventory : MonoBehaviour
    {
        /// <summary>
        /// How many items wide the inventory is
        /// </summary>
        [SerializeField] private int width;
        /// <summary>
        /// How many items tall the inventory is
        /// </summary>
        [SerializeField] private int height;

        private List<List<ItemStack>> inventory;

        //UI
        private Canvas inventoryScreen;
        private Button inventorySlot;
        [SerializeField]
        private float buttonSize = 50.0f;
        [SerializeField]
        private float spacing = 10.0f;

        // Start is called before the first frame update
        void Start()
        {
            inventoryScreen = GetComponent<Canvas>();
            inventoryScreen.renderMode = RenderMode.ScreenSpaceOverlay;
            inventorySlot = Resources.Load<Button>("Inventory/InventorySlot");

            SetupInventoryScreen();
        }

        /// <summary>
        /// Call this function to set up the inventory with the correct width and height
        /// </summary>
        private void SetupInventoryScreen()
        {
            inventorySlot.image.rectTransform.sizeDelta = new Vector2(buttonSize, buttonSize);
            inventory = new List<List<ItemStack>>();
            GameObject column = Instantiate(new GameObject(), gameObject.transform);
            VerticalLayoutGroup verticalLayoutGroup = column.AddComponent<VerticalLayoutGroup>();
            verticalLayoutGroup.spacing = spacing;
            verticalLayoutGroup.childControlHeight = false;
            for(int i = 0; i < height; ++i)
            {
                List<ItemStack> inventoryRow = new List<ItemStack>();
                inventory.Add(inventoryRow);
                GameObject row = Instantiate(new GameObject(), column.transform);
                HorizontalLayoutGroup horizontalLayoutGroup = row.AddComponent<HorizontalLayoutGroup>();
                horizontalLayoutGroup.spacing = spacing;
                horizontalLayoutGroup.childControlWidth = false;
                for(int j = 0; j < width; ++j)
                {
                    Button itemSlot = Instantiate(inventorySlot, row.transform);
                    ItemStack item = new ItemStack
                    {
                        inventorySlot = itemSlot
                    };
                    inventoryRow.Add(item);
                }
            }
        }

        /// <summary>
        /// Puts the inventory into a one-dimensional list to be sorted
        /// </summary>
        private List<ItemStack> FlattenInventory(List<List<ItemStack>> itemStacks)
        {
            List<ItemStack> flatList = new List<ItemStack>();
            foreach(List<ItemStack> row in itemStacks)
            {
                flatList.AddRange(row);
            }
            return flatList;
        }

        /// <summary>
        /// Sorts a list using the Heap sort algorithm
        /// </summary>
        /// <param name="unsortedList"></param>
        private List<ItemStack> SortInventory(List<ItemStack> unsortedList)
        {
            return HeapSortAlgorithm.HeapSort(unsortedList);
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