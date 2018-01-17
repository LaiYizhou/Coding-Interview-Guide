using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonPart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PrintCommonPart(Node head1, Node head2)
    {
        while (head1 != null && head2 != null)
        {
            if (head1.value < head2.value)
                head1 = head1.next;
            else if (head1.value > head2.value)
                head2 = head2.next;
            else
            {
                Debug.Log(head1.value);
                head1 = head1.next;
                head2 = head2.next;
            }
        }
    }
}
