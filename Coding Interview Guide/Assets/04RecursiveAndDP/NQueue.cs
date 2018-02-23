using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NQueue : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    Debug.Log(GetNumber(4));

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetNumber(int n)
    {
        if (n <= 0)
            return 0;

        if (n == 1)
            return 1;

        int[] record = new int[n];
        return Cal(0, record, n);

    }

    private int Cal(int i, int[] record, int n)
    {
        if (i == n)
            return 1;

        int res = 0;
        for (int j = 0; j < n; j++)
        {
            if (isValid(record, i, j))
            {
                record[i] = j;
                res += Cal(i + 1, record, n);
            }
        }

        return res;
    }

    private bool isValid(int[] record, int i, int j)
    {
        for (int k = 0; k < i; k++)
        {
            if (j == record[k] || Mathf.Abs(record[k] - j) == Mathf.Abs(i - k))
                return false;
        }
        return true;
    }
}
