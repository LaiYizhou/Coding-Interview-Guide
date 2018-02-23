using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Rotation(string a, string b)
    {
        Debug.Log("a = "+a+" ; b = "+b+" ; "+IsRotation(a, b));
    }

    public bool IsRotation(string a, string b)
    {
        if (a == null || b == null || a.Length != b.Length)
            return false;

        string bb = b + b;
        return bb.IndexOf(a) != -1;
    }
}
