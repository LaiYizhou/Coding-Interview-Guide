using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSortedList : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    Node head1 = LinkedListHelper.BuildNodeList(new[] { 0, 4, 6, 12, 54 });
	    Node head2 = LinkedListHelper.BuildNodeList(new[] { -4, 1, 45, 65, 100 });
        LinkedListHelper.PrintList(head1);
	    LinkedListHelper.PrintList(head2);
        LinkedListHelper.PrintList(Merge(head1, head2));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    Node Merge(Node head1, Node head2)
    {
        if (head1 == null || head2 == null)
            return head1 == null ? head1 : head2;

        Node head = null;
        Node res = head1.value < head2.value ? head1 : head2;
        Node cur1 = head1;
        Node cur2 = head2;

        while (cur1 != null && cur2 != null)
        {
            if (cur1.value <= cur2.value)
            {
                if (head == null)
                {
                    head = cur1;
                    cur1 = cur1.next;
                }
                else
                {
                    head.next = cur1;
                    cur1 = cur1.next;
                    head = head.next;
                }

            }
            else
            {
                if (head == null)
                {
                    head = cur2;
                    cur2 = cur2.next;
                }
                else
                {
                    head.next = cur2;
                    cur2 = cur2.next;
                    head = head.next;
                }

            }
        }

        if(cur1!=null)
        {
            head.next = cur1;
        }

        if (cur2 != null)
            head.next = cur2;

        return res;
    }
}
