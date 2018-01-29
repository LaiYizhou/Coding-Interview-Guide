using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveValueNode : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    Node head1 = LinkedListHelper.BuildNodeList(new[] { 1, 2, 3, 4, 4, 4, 2, 1, 1 });
	    LinkedListHelper.PrintList(head1);
	    LinkedListHelper.PrintList(RemoveValue(head1, 4));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Node RemoveValue(Node head, int num)
    {
        if(head == null)
            return null;

        Node cur = head;
        while (cur!=null)
        {
            if(cur.value != num)
                break;

            cur = cur.next;

        }

        Node pre = cur;
        Node next = cur;
        while (pre!=null)
        {
            next = pre.next;

            if(next == null)
                break;

            if (next.value == num)
            {
                pre.next = next.next;
            }
            else
            {
                pre = next;
            }
        }

        return cur;
    }
}
