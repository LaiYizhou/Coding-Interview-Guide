using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deformation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Deformation(string s1, string s2)
    {
        Debug.Log("s1 = "+s1+" ; s2 = "+s2+" ;"+IsDeformation(s1, s2));
    }

    public bool IsDeformation(string s1, string s2)
    {
        if (s1 == null || s2 == null || s1.Length != s2.Length)
            return false;

        int[] map = new int[256];
        for (int i = 0; i < s1.Length; i++)
            map[i] = 0;

        for (int i = 0; i < s1.Length; i++)
            map[s1[i]]++;

        for (int i = 0; i < s1.Length; i++)
        {
            if (map[s2[i]]-- == 0)
                return false;
        }



        return true;

    }
}
