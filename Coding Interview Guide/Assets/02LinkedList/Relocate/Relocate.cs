using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Relocate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RelocateList(Node head)
    {
        if(head==null || head.next == null)
            return;

        Node mid = head;
        Node right = head.next;
        while (right.next!=null && right.next.next !=null)
        {
            mid = mid.next;
            right = right.next.next;
        }

        right = mid.next;
        mid.next = null;

        Merge(head, right);

    }

    private void Merge(Node left, Node right)
    {
        Node next = null;
        while (left.next != null)
        {
            next = right.next;
            right.next = left.next;
            left.next = right;

            left = right.next;
            right = next;
        }

        left.next = right;
    }
}
