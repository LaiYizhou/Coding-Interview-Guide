using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palindrome : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool IsPalindrome(Node head)
    {
        Stack<Node> stack = new Stack<Node>();
        Node cur = head;
        while (cur!=null)
        {
            stack.Push(cur);
            cur = cur.next;
        }

        cur = head;
        while (cur!=null)
        {
            if (cur.value != stack.Pop().value)
                return false;
        }

        return true;

    }

    public bool IsPalindrome2(Node head)
    {
        if (head == null || head.next == null)
            return true;

        Node node1 = head;
        Node node2 = head;
        while (node1 != null && node2 != null)
        {
            node1 = node1.next;
            node2 = node2.next.next;
        }

        //node1 is Mid

        node2 = node1.next;
        node1.next = null;

        // node1 node2 node3

        Node node3 = null;
        while (node2!=null)
        {
            node3 = node2.next;
            node2.next = node1;
            node1 = node2;
            node2 = node3;
        }

        node3 = node1;
        node2 = head;

        bool res = true;
        while (node1 != null && node2 != null)
        {
            if (node1.value != node2.value)
            {
                res = false;
                break;
            }

            node1 = node1.next;
            node2 = node2.next;
        }

        //node3 node1 node2

        node1 = node3.next;
        node3.next = null;
        while (node1 != null)
        {
            node2 = node1.next;
            node1.next = node3;
            node3 = node1;
            node1 = node2;
        }

        return res;

    }
}
