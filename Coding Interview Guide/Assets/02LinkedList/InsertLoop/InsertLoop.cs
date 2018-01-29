using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertLoop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    Node head1 = LinkedListHelper.BuildLoopList(new[] { 1, 2, 3, 4 });
	    LinkedListHelper.PrintLoopList(head1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
