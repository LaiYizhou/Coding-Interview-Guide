using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JosephusProblem : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{

	 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Node JosephusKill(Node head, int m)
    {
        if (head == null || head.next == head || m < 1)
            return head;

        Node end = head;
        while (end!=head)
            end = end.next;

        int count = 0;

        while (head!=end)
        {
            count++;
            if (count == m)
            {
                count = 0;
                end.next = head.next;
                head = end.next;
            }
            else
            {
                end = end.next;
                head = end.next;
            }
        }

        return head;

    }


    public Node JosephusKill2(Node head, int m)
    {
        if (head == null || head.next == head || m < 1)
            return head;

        Node next = head.next;
        int count = 1;
        while (next!=head)
        {
            count++;
            next = next.next;
        }

        int n = GetNumber(count, m);

        while (--n!=0)
        {
            head = head.next;
        }

        head.next = head;
        return head;

    }

    private int GetNumber(int count, int m)
    {
        if (count == 1)
            return 1;
        return (GetNumber(count - 1, m) + m - 1) % count + 1;
    }
}
