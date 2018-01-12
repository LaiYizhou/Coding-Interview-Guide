using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseStack : MonoBehaviour
{

    private Stack<int> stack;


    private int GetAndRemoveLastElement(Stack<int> s)
    {
        int result = s.Pop();
        if (stack.Count == 0)
            return result;
        else
        {
            int last = GetAndRemoveLastElement(s);
            s.Push(result);
            return last;
        }

    }

    private void Reverse(Stack<int> s)
    {
        if (stack.Count == 0)
        {
            return;
        }
        else
        {
            int temp = GetAndRemoveLastElement(s);
            Reverse(s);
            s.Push(temp); 
        }
    }


    // Use this for initialization
	void Start () {

	    stack = new Stack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

	    //Show();

        Reverse(stack);

        Show();

	}

    private void Show()
    {
        while (stack.Count != 0)
        {
            Debug.Log(stack.Pop());
        }
    }

    // Update is called once per frame
	void Update () {
		
	}
}
