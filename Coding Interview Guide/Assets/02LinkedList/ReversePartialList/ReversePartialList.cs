using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePartialList : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    Node head1 = LinkedListHelper.BuildNodeList(new[] { 6, 1, 4, 3, 5, 2, -1 });
	    LinkedListHelper.PrintList(head1);
	    LinkedListHelper.PrintList(ReversePart(head1,2,4));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Node ReversePart(Node head, int from, int to)
    {
        Node cur = head;
        int length = 0;

        Node fPre = null;
        Node tNext = null;

        while (cur != null)
        {
            length++;
            if (length == from - 1)
                fPre = cur;

            if (length == to + 1)
                tNext = cur;

            cur = cur.next;

        }

        if (from > to || from < 1 || to > length)
            return head;

        cur = fPre == null ? head : fPre.next;

        Node node = cur.next;
        cur.next = tNext;

        Node next = null;

        while (node != tNext)
        {
            next = node.next;
            node.next = cur;
            cur = node;
            node = next;
        }

        if (fPre != null)
        {
            fPre.next = cur;
            return head;
        }
        else
        {
            return cur;
        }

        
    }
}
