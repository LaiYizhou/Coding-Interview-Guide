using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseList : MonoBehaviour {

	// Use this for initialization
	void Start () {
	   
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Node ReverseNodeList(Node head)
    {
        Node pre = null;
        Node next = null;

        while (head != null)
        {
            next = head.next;
            head.next = pre;
            pre = head;
            head = next;
        }

        return pre;
    }

    public DoubleNode ReverseDoubleNode(DoubleNode head)
    {
        DoubleNode pre = null;
        DoubleNode next = null;

        while (head!=null)
        {
            next = head.next;
            head.next = pre;
            head.last = next;
            pre = head;
            head = next;
        }

        return pre;
    }

}
