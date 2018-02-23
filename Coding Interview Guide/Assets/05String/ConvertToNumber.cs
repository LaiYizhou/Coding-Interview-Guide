using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertToNumber : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public ConvertToNumber(string s)
    {
        Debug.Log("s = "+s+" ; "+Covert(s));
    }

    public int Covert(string s)
    {

        if (!IsValid(s))
            return 0;

        bool pos = s[0] != '-';

        int min_Noge = Int32.MinValue / 10;
        int min_ge = Int32.MinValue % 10;

        int res = 0;

        for (int i = pos ? 0 : 1; i < s.Length; i++)
        {
            var cur = '0' - s[i];

            if (res < min_Noge)
                return 0;

            if (res == min_Noge && cur < min_ge)
                return 0;

            res = res * 10 + cur;
        }

        if (pos && res == Int32.MinValue)
            return 0;

        return pos ? -res : res;
    }

    public bool IsValid(string s)
    {
        if (s == null || s.Length == 0)
            return false;

        if ((s[0] < '0' || s[0] > '9') && s[0] != '-')
            return false;

        if (s[0] == '-' && (s.Length == 1 || s[1] == '0'))
            return false;

        if (s[0] == '0' && s.Length != 1)
            return false;

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] < '0' || s[i] > '9')
                return false;
        }

        return true;

    }
}
