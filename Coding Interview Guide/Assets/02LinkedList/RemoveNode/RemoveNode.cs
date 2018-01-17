using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveNode : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
    }

    // Update is called once per frame
    void Update () {
		
	}

    public Node RemoveMidNode(Node head)
    {
        if (head == null || head.next == null)
            return head;

        if (head.next.next == null)
            return head.next;

        Node slow = head;
        Node fast = head.next.next;

        while (fast.next!=null && fast.next.next!=null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        slow.next = slow.next.next;
        return head;

    }

    public Node RemoveByRatio(Node head, int a, int b)
    {
        if (a <= 0 || a > b || head == null)
            return head;

        int n = 0;
        Node cur = head;
        while (cur!=null)
        {
            n++;
            cur = cur.next;
        }

        n = (int) Mathf.Ceil((float) (a * n) / (float) b);

        if (n == 1)
            return head.next;
        else if (n > 1)
        {
            cur = head;
            while (n!=1)
            {
                cur = cur.next;
                n--;
            }

            cur.next = cur.next.next;
            
        }

        return head;
    }
}
