using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour {

    MinStack minStack = new MinStack();
    TwoStackQueue twoStackQueue = new TwoStackQueue();

	// Use this for initialization
	void Start ()
	{
	    Test();
	}

    void Test()
    {
        //Cat cat = new Cat("cat");



        int[] arr = new[] {3, 4, 5, 1, 2, 1};

        for(int i = 0; i<arr.Length; i++)
            twoStackQueue.Enqueue(arr[i]);

        for (int i = 0; i < arr.Length; i++)
        {
            twoStackQueue.Dequeue();
        }

        //minStack.Push(3);
        //minStack.Push(4);
        //minStack.Push(5);
        //minStack.Push(1);
        //minStack.Push(2);
        //minStack.Pop();
        //minStack.Pop();
        //minStack.Push(1);
    }

    // Update is called once per frame
	void Update () {
		
	}
}
