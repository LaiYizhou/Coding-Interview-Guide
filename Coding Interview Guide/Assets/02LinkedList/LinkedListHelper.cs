using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LinkedListHelper : MonoBehaviour {

    public static Node BuildNodeList(int[] arr)
    {
        Node head = null;
        if (arr == null || arr.Length <= 0)
            return head;

        head = new Node(arr[0]);
        Node cur = head;
        for (int i = 1; i < arr.Length; i++)
        {
            Node temp = new Node(arr[i]);
            cur.next = temp;
            cur = temp;
        }

        return head;

    }

    public static void PrintList(Node head)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("List : ");

        while (head!=null)
        {
            sb.Append(head.value.ToString()).Append(" -> ");
            head = head.next;
        }

        sb.Append("NULL");
        Debug.Log(sb.ToString());

    }

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
