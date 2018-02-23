using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class RemoveZero : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public RemoveZero(string s, int k)
    {
        Debug.Log("s = "+s+" ; k = "+k+" ; "+RemoveKZero(s,k));
    }

    public string RemoveKZero(string s, int k)
    {
        if (s == null || k < 1)
            return s;

        int count = 0;
        int start = -1;

        char[] charArray = s.ToCharArray();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '0')
            {
                count++;
                start = start == -1 ? i : start;
            }
            else
            {
                if (count == k)
                {
                    s = s.Remove(start, k);
                }

                count = 0;
                start = -1;
            }
        }

        if (count == k)
        {
            s = s.Remove(start, k);
        }

        return s;

        //StringBuilder sb = new StringBuilder();
        //for (int i = 0; i < charArray.Length; i++)
        //{
        //    sb.Append(charArray[i]);
        //}

        //return sb.ToString();
    }
}
