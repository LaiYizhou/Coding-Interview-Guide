using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ReverseKNodes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Node ReverseKNode2(Node head, int k)
    {
        if (k < 2)
            return head;

        Node cur = head;

        Node pre = null;
        Node start = null;

        int count = 1;
        Node next = null;
        while (cur!=null)
        {
            next = cur.next;
            if (count == k)
            {
                start = pre == null ? head : pre.next;
                head = pre == null ? cur : head;

                Resign2(pre, start, cur, next);

                pre = start;

                count = 0;
            }
            count++;
            cur = next;
        }

        return null;
    }

    private void Resign2(Node left, Node start, Node end, Node right)
    {
        Node pre = start;
        Node cur = start.next;
        Node next = null;
        while (cur != right)
        {
            next = cur.next;
            cur.next = pre;
            pre = cur;
            cur = next;
        }

        if (left != null)
            left.next = end;

        start.next = right;
    }

    public Node ReverseKNode1(Node head, int k)
    {
        if (k < 2)
            return head;

        Stack<Node> stack = new Stack<Node>();

        Node newhead = head;
        Node cur = head;

        Node pre = null;
        Node next = null;

        while (cur!=null)
        {
            next = cur.next;

            stack.Push(cur);
            if (stack.Count == k)
            {
                pre = Resign1(stack, pre, next);
                newhead = newhead == head ? cur : newhead;
            }

            cur = next;
        }

        return newhead;

    }

    private Node Resign1(Stack<Node> stack, Node left, Node right)
    {

        Node cur = stack.Pop();
        if (left != null)
            left.next = cur;

        Node next = null;
        while (stack.Count != 0)
        {
            next = stack.Pop();
            cur.next = next;
            cur = next;
        }

        cur.next = right;
        return cur;

    }

    private Node R(Node head)
    {
        Node pre = null;
        Node next = null;

        while (head!=null)
        {
            next = head.next;
            head.next = pre;
            pre = head;
            head = next;
        }

        return pre;
    }
}
