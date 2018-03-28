using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToNOneNumber : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{

	    int ans = GetNumber(213);
        Debug.Log(ans);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private int GetNumber(int num)
    {
        if (num < 1)
            return 0;

        int length = GetLength(num);

        int powerOfTenNumber = getPowerOfTen(length - 1);
        int highPosNumber = num / powerOfTenNumber;
        int remainNumber = num % powerOfTenNumber;

        int highOneNumber = highPosNumber == 1 ? remainNumber + 1 : powerOfTenNumber;
        int otherOneNumber = highPosNumber * (length - 1) * powerOfTenNumber / 10;

        return highOneNumber + otherOneNumber + GetNumber(remainNumber);

    }

    private int GetLength(int num)
    {
        int length = 0;
        while (num != 0)
        {
            length++;
            num /= 10;
        }

        return length;
    }

    private int getPowerOfTen(int num)
    {
        int res = 1;
        for (int i = 0; i < num; i++)
            res *= 10;
        return res;
    }

}
