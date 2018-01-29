using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class SelectSort : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    Node head1 = LinkedListHelper.BuildNodeList(new[] { 1, 2, 3, 4, 4, 4, 2, 1, 1 });
	    LinkedListHelper.PrintList(head1);
	    LinkedListHelper.PrintList(SelectionSort(head1));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Node SelectionSort(Node head)
    {
        Node tail = null;
        Node cur = head;
        Node smallPre = null;
        Node small = null;


        while (cur!=null)
        {
            small = cur;
            smallPre = GetPreMin(cur);

            if (smallPre != null)
            {
                small = smallPre.next;
                smallPre.next = small.next;
            }

            if (cur == small)
                cur = cur.next;

            if (tail != null)
                tail.next = small;
            else
                head = small;

            tail = small;

        }


        return head;
    }

    public Node GetPreMin(Node head)
    {
        Node smallPre = null;
        Node small = head;
        Node pre = head;
        Node cur = head.next;

        while (cur != null)
        {
            if (cur.value < small.value)
            {
                smallPre = pre;
                small = smallPre.next;
            }

            pre = cur;
            cur = cur.next;

        }

        return smallPre;

    }
}
