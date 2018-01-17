using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastKthNode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public DoubleNode RemoveLastKthNode(DoubleNode head, int k)
    {
        DoubleNode cur = head;
        if (head == null || k <= 0)
            return cur;

        while (cur != null)
        {
            k--;
            cur = cur.next;
        }

        if (k > 0)
            return cur;
        else if (k == 0)
        {
            cur = head.next;
            cur.last = null;
            return cur;
        }
        else
        {
            cur = head;
            while (k != 0)
            {
                k++;
                cur = cur.next;
            }

            DoubleNode newNode = cur.next.next;
            cur.next = newNode;

            if (newNode != null)
                newNode.last = cur;

            return cur;
        }
    }

    public Node RemoveLastKthNode(Node head, int k)
    {
        Node cur = head;
        if (head == null || k <= 0)
            return cur;

        while (cur!=null)
        {
            k--;
            cur = cur.next;
        }

        if (k > 0)
            return cur;
        else if (k == 0)
            return cur.next;
        else
        {
            cur = head;
            while (k != 0)
            {
                k++;
                cur = cur.next;
            }

            cur.next = cur.next.next;
            return cur;
        }

    }
}
