using FramedWok.Sorting;
using FramedWok.Searching;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortAndSearchTest : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Test();
    }

    private void Test()
    {
        List<string> list = new List<string>();
        string unsortedList = "Unsorted List: ";
        for (int i = 0; i < 100; ++i)
        {
            string number = UnityEngine.Random.Range(0, 100) + ", ";
            list.Add(number);
            unsortedList += number;
        }
        Debug.Log(unsortedList);
        list = HeapSortAlgorithm.HeapSort(list);
        string sortedList = "Sorted List: ";
        foreach (string item in list)
        {
            sortedList += item;
        }
        Debug.Log(sortedList);
        string itemToLookFor = Random.Range(0, 100) + "";
        Debug.Log(itemToLookFor);
        Debug.Log(BinarySearch.Search(list,itemToLookFor));
    }
}
