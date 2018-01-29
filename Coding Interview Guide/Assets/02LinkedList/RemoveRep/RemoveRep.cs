using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Networking;

public class RemoveRep : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    Node head1 = LinkedListHelper.BuildNodeList(new[] {1, 2, 3, 4, 4, 4, 2, 1, 1});
	    LinkedListHelper.PrintList(head1);
	    Remove2(head1);
        LinkedListHelper.PrintList(head1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Remove1(Node head)
    {
        if(head == null)
            return;

        Dictionary<int, Node> dictionary = new Dictionary<int, Node>();

        Node cur = head;
        Node pre = head;
        dictionary.Add(cur.value, cur);

        cur = cur.next;

        while (cur!= null)
        {
            if (dictionary.ContainsKey(cur.value))
            {
                pre.next = cur.next;
            }
            else
            {
                dictionary.Add(cur.value, cur);
                pre = cur;
            }

            cur = cur.next;
        }


    }

    public void Remove2(Node head)
    {
        if (head == null)
            return;

        Node cur = head;
        Node pre = null;
        Node next = null;

        while (cur!= null)
        {
            pre = cur;
            next = pre.next;

            while (next!=null)
            {
                if (next.value == cur.value)
                {
                    pre.next = next.next;
                    next = next.next;
                }
                else
                {
                    pre = next;
                    next = next.next;
                }
            }

            cur = cur.next;

        }

    }
}
