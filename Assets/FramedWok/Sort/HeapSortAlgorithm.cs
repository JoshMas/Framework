using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FramedWok.Inventory;

public class HeapSortAlgorithm : MonoBehaviour
{

    private int marker = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<T> HeapSort<T>(List<T> list) where T : IComparable<T>
    {
        BuildMaxHeap(list);
        for(int i = marker; i > 0; --i)
        {
            Swap(list, i - 1, 0);
            marker -= 1;
            Heapify(list, 0);
        }
        return list;
    }

    private void BuildMaxHeap<T>(List<T> list) where T : IComparable<T>
    {
        marker = list.Count;
        for(int i = marker/2; i > 0; --i)
        {
            Heapify(list, i - 1);
        }
    }

    private void Heapify<T>(List<T> list, int index) where T : IComparable<T>
    {
        int left = (2 * (index + 1)) - 1;
        int right = left + 1;

        int max = index;

        if(left < marker)
        {
            if(list[left].CompareTo(list[index]) == 1)
                max = left;
        }

        if(right < marker)
        {
            if(list[right].CompareTo(list[max]) == 1)
                max = right;
        }

        if(max != index)
        {
            Swap(list, index, max);
            Heapify(list, max);
        }
    }

    private void Swap<T>(List<T> list, int a, int b) where T : IComparable<T>
    {
        T temp = list[a];
        list[a] = list[b];
        list[b] = temp;
    }
}
