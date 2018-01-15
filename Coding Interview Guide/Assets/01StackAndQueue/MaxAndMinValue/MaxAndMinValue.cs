using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEditor.iOS.Xcode;
using UnityEngine;

public class MaxAndMinValue : MonoBehaviour
{
    private int[] arr = new[] {4, 1, 2, 3};
    private int num = 2;


    public MaxAndMinValue()
    {
        Debug.Log(getNum(arr, num));
    }

    // Use this for initialization
    void Start () {
		
	}

    public int getNum(int[] arr, int num)
    {
        if (arr == null || arr.Length == 0)
            return 0;
        else
        {
            LinkedList<int> qmin = new LinkedList<int>();
            LinkedList<int> qmax = new LinkedList<int>();

            int res = 0;
            int i = 0;
            int j = 0;

            while (i < arr.Length)
            {
                while (j < arr.Length)
                {
                    while (qmin.Count!= 0 && arr[qmin.Last.Value] >= arr[j])
                        qmin.RemoveLast();

                    qmin.AddLast(j);

                    while (qmax.Count!=0 && arr[qmax.Last.Value] < arr[j])
                        qmax.RemoveLast();

                    qmax.AddLast(j);


                    if(arr[qmax.First.Value] - arr[qmin.First.Value]>num)
                        break;

                    j++;

                }

                if(qmin.First.Value == i)
                    qmin.RemoveFirst();

                if(qmax.First.Value == i)
                    qmax.RemoveFirst();

                res += (j - i);
                i++;

            }

            return res;
        }

    }

    // Update is called once per frame
	void Update () {
		
	}
}
