using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RemoveRep : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    Node head1 = LinkedListHelper.BuildNodeList(new[] {1, 2, 3, 4, 4, 4, 2, 1, 1});
	    LinkedListHelper.PrintList(head1);
	    Remove1(head1);
        LinkedListHelper.PrintList(head1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Remove1(Node head)
    {

    }
}
