using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NQueue : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    //Debug.Log(GetNumber(3));

	    for (int i = 0; i <= 8; i++)
	    {
            Debug.Log("i = "+i+" ; "+GetNumber(i));
        }

	    Debug.Log("i = " + 16 + " ; " + GetNumber(16));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetNumber(int n)
    {
        //if (n <= 0)
        //    return 0;

        //if (n == 1)
        //    return 1;

        //int[] record = new int[n];
        //return Cal(0, record, n);

        if (n < 1 || n > 32)
            return 0;

        int upperLim = (n == 32) ? -1 : (1 << n) - 1;
        return Process2(upperLim, 0, 0, 0);

    }

    private int Process2(int upperLim, int colLim, int leftDiaLim, int rightDiaLim)
    {
        if (colLim == upperLim)
            return 1;

        int pos = 0;
        int mostRightOne = 0;

        pos = upperLim & (~(colLim | leftDiaLim | rightDiaLim));

        int res = 0;

        while (pos!=0)
        {
            mostRightOne = pos & (~pos + 1);
            pos = pos - mostRightOne;

            uint temp = (uint)(rightDiaLim | mostRightOne);
            temp = temp >> 1;

            res += Process2(upperLim, colLim | mostRightOne,
                (leftDiaLim | mostRightOne) << 1,
                (int)temp);
        }

        return res;

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
