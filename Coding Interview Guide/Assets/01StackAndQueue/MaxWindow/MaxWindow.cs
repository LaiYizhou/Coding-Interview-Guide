using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxWindow : MonoBehaviour {

    private LinkedList<int> queue = new LinkedList<int>();
         
	// Use this for initialization
	void Start ()
	{
	    //queue.AddLast(1);
	    int[] arr = new[] {4, 3, 5, 4, 3, 3, 6, 7};

	    int[] res = GetMaxWindow(arr, 3);

	    for (int i = 0; i < res.Length; i++)
	    {
            Debug.Log(res[i]);
	    }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int[] GetMaxWindow(int[] arr, int w)
    {
        if (arr == null || w < 1 || arr.Length < w)
            return null;
        
        int[] res = new int[arr.Length- w + 1];

        int index = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            while (queue.Count!=0 && arr[queue.Last.Value]<=arr[i])
                queue.RemoveLast();

            queue.AddLast(i);

            if (queue.First.Value == i - w)
                queue.RemoveFirst();

            if (i >= w - 1)
                res[index++] = arr[queue.First.Value];

        }

        return res;

    }
}
