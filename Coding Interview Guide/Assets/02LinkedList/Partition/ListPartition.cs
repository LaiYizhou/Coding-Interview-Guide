using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPartition : MonoBehaviour {

	// Use this for initialization
	void Start () {

	    Node head1 = LinkedListHelper.BuildNodeList(new[] { 7, 9, 1, 8, 5, 2, 5 });
	    LinkedListHelper.PrintList(head1);
	    LinkedListHelper.PrintList(listPartition2(head1, 5));

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Node listPartition2(Node head, int pivot)
    {
        Node leftHead = null;
        Node leftTail = null;

        Node midHead = null;
        Node midTail = null;

        Node rightHead = null;
        Node rightTail = null;

        Node next = null;
        while (head!=null)
        {
            next = head.next;
            head.next = null;

            if (head.value < pivot)
            {
                if (leftHead == null)
                {
                    leftHead = head;
                    leftTail = head;
                }
                else
                {
                    leftTail.next = head;
                    leftTail = head;
                }

            }
            else if (head.value == pivot)
            {
                if (midHead == null)
                {
                    midHead = head;
                    midTail = head;
                }
                else
                {
                    midTail.next = head;
                    midTail = head;
                }
            }
            else
            {
                if (rightHead == null)
                {
                    rightHead = head;
                    rightTail = head;
                }
                else
                {
                    rightTail.next = head;
                    rightTail = head;
                }
            }

            head = next;
            
        }

        if (leftTail != null)
        {
            leftTail.next = midHead;
            midTail = midTail == null ? leftTail : midTail;
        }

        if (midTail != null)
        {
            midTail.next = rightHead;
        }

        return leftHead != null ? leftHead : midHead != null ? midHead : rightHead;
    }

    public Node listPartition1(Node head, int pivot)
    {
        if (head == null)
            return head;

        Node cur = head;
        int length = 0;

        while (cur!=null)
        {
            length++;
            cur = cur.next;
        }

        Node[] nodeArray = new Node[length];

        cur = head;
        for (int i = 0; i < length; i++)
        {
            nodeArray[i] = cur;
            cur = cur.next;
        }

        arrPartition(nodeArray, pivot);

        for (int i = 0; i < length - 1; i++)
            nodeArray[i].next = nodeArray[i + 1];

        nodeArray[length-1].next = null;

        return nodeArray[0];

    }

    private void arrPartition(Node[] array, int pivot)
    {
        int left = 0;
        int right = array.Length - 1;

        int cur = 0;
        while (cur <= right)
        {
            if (array[cur].value < pivot)
            {
                Swap(array, left, cur);
                left++;
                cur++;
            }
            else if (array[cur].value > pivot)
            {
                Swap(array, right, cur);
                right--;
            }
            else
            {
                cur++;
            }

        }
    }

    private void Swap(Node[] array, int a, int b)
    {
        Node temp = array[a];
        array[a] = array[b];
        array[b] = temp;
    }
}
