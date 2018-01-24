using System.Collections.Generic;
using UnityEngine;

public class AddList : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    Node head1 = LinkedListHelper.BuildNodeList(new[] { 7, 9, 1, 8, 5, 2, 5 });
	    Node head2 = LinkedListHelper.BuildNodeList(new[] {2, 0, 8, 2, 4, 7, 5});
	    LinkedListHelper.PrintList(head1);
	    LinkedListHelper.PrintList(head2);
        LinkedListHelper.PrintList(AddList1(head1, head2));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Node AddList1(Node head1, Node head2)
    {
        Stack<int> s1 = new Stack<int>();
        Stack<int> s2 = new Stack<int>();

        while (head1!=null)
        {
            s1.Push(head1.value);
            head1 = head1.next;
        }

        while (head2!=null)
        {
            s2.Push(head2.value);
            head2 = head2.next;
        }

        int cal = 0;
        int n1 = 0;
        int n2 = 0;
        int sum = 0;

        Node node = null;
        Node pre = null;

        while (s1.Count!= 0 || s2.Count!=0)
        {
            n1 = s1.Count == 0 ? 0 : s1.Pop();
            n2 = s2.Count == 0 ? 0 : s2.Pop();

            sum = n1 + n2 + cal;
            cal = sum / 10;

            pre = node;
            node = new Node(sum % 10);
            node.next = pre;

        }

        if (cal != 0)
        {
            pre = node;
            node = new Node(1);
            node.next = pre;
        }

        return node;

    }

    public Node AddList2(Node head1, Node head2)
    {
        head1 = ReverseList(head1);
        head2 = ReverseList(head2);

        int cal = 0;
        int n1 = 0;
        int n2 = 0;
        int sum = 0;

        Node c1 = head1;
        Node c2 = head2;

        Node node = null;
        Node pre = null;

        while (c1!=null || c2!=null)
        {
            n1 = c1 == null ? 0 : c1.value;
            n2 = c2 == null ? 0 : c2.value;

            sum = n1 + n2 + cal;
            cal = sum / 10;

            pre = node;
            node = new Node(sum % 10);
            node.next = pre;

            c1 = c1 == null ? null : c1.next;
            c2 = c2 == null ? null : c2.next;
        }

        if (cal != 0)
        {
            pre = node;
            node = new Node(1);
            node.next = pre;
        }

        ReverseList(head1);
        ReverseList(head2);

        return node;

    }

    private Node ReverseList(Node head)
    {
        Node pre = null;
        while (head != null)
        {
            var next = head.next;
            head.next = pre;
            pre = head;
            head = next;
        }

        return pre;
    }
}
