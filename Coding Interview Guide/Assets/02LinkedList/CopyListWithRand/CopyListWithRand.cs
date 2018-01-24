using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyListWithRand : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private RandomNode CopyList(RandomNode head)
    {
        if (head == null)
            return null;

        RandomNode cur = head;
        RandomNode next = null;

        while (cur!=null)
        {
            next = cur.next;
            cur.next = new RandomNode(cur.value);
            cur.next.next = next;
            cur = next;
        }

        cur = head;
        RandomNode copyNode = null;

        while (cur!=null)
        {
            next = cur.next.next;
            cur.next.rand = cur.rand == null ? null : cur.rand.next;
            cur = next;
        }

        RandomNode res = head.next;
        cur = head;

        while (cur!=null)
        {
            next = cur.next.next;
            copyNode = cur.next;
            cur.next = next;
            copyNode.next = next != null ? next.next : null;
            cur = next;
        }

        return res;

    }
}
