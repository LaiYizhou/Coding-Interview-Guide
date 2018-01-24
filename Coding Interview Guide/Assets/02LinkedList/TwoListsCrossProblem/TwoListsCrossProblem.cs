using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoListsCrossProblem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Node SolveProblem(Node head1, Node head2)
    {
        if (head1 == null || head2 == null)
            return null;

        Node node1 = GetLoopNode(head1);
        Node node2 = GetLoopNode(head2);

        if (node1 == null && node2 == null)
            return GetNodeWhenNoLoop(head1, head2);

        if(node1 != null && node2 != null)
            return GetNodeWhenBothLoop(head1, node1, head2, node2);


        return null;

    }

    public Node GetNodeWhenBothLoop(Node head1, Node node1, Node head2, Node node2)
    {

        Node cur1 = head1;
        Node cur2 = head2;

        if (node1 == node2)
        {
            int length1 = 0;
            int length2 = 0;

            while (cur1 != node1)
            {
                length1++;
                cur1 = cur1.next;
            }

            while (cur2 != node2)
            {
                length2++;
                cur2 = cur2.next;
            }

            if (cur1 != cur2)
                return null;

            int n = 0;
            if (length1 > length2)
            {
                n = length1 - length2;
                cur1 = head1;
                cur2 = head2;
            }
            else
            {
                n = length2 - length1;
                cur1 = head2;
                cur2 = head1;
            }

            while (n != 0)
            {
                n--;
                cur1 = cur1.next;
            }


            while (cur1 != cur2)
            {
                cur1 = cur1.next;
                cur2 = cur2.next;
            }

            return cur1;
        }
        else
        {
            cur1 = node1.next;
            while (cur1 != node1)
            {
                if (cur1 == node2)
                    return node2;

                cur1 = cur1.next;
            }

            return null;
        }

        
    }

    public Node GetNodeWhenNoLoop(Node head1, Node head2)
    {
        if (head1 == null || head2 == null)
            return null;

        Node cur1 = head1;
        Node cur2 = head2;

        int length1 = 0;
        int length2 = 0;

        while (cur1.next!=null)
        {
            length1++;
            cur1 = cur1.next;
        }

        while (cur2.next != null)
        {
            length2++;
            cur2 = cur2.next;
        }

        if (cur1 != cur2)
            return null;

        int n = 0;
        if (length1 > length2)
        {
            n = length1 - length2;
            cur1 = head1;
            cur2 = head2;
        }
        else
        {
            n = length2 - length1;
            cur1 = head2;
            cur2 = head1;
        }

        while (n!=0)
        {
            n--;
            cur1 = cur1.next;
        }


        while (cur1!= cur2)
        {
            cur1 = cur1.next;
            cur2 = cur2.next;
        }

        return cur1;

    }

    /// <summary>
    /// Is Loop?
    /// true, return first Node; false, return NULL
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public Node GetLoopNode(Node head)
    {
        if (head == null || head.next == null || head.next.next == null)
            return null;

        Node slow = head;
        Node fast = head;

        while (slow != fast)
        {
            if (fast.next == null || fast.next.next == null)
                return null;


            fast = fast.next.next;
            slow = slow.next;

        }

        fast = head;

        while (slow != fast)
        {
            slow = slow.next;
            fast = fast.next;
        }

        return slow;

    }

}
