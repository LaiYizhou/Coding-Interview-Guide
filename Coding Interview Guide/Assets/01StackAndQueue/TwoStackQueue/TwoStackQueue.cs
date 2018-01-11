using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoStackQueue
{

    private Stack<int> stackPush;
    private Stack<int> stackPop;

    public TwoStackQueue(int number)
    {
        stackPush = new Stack<int>(number);
        stackPop = new Stack<int>(number);
    }

    public bool IsEmpty()
    {
        return (stackPush.Count == 0 && stackPop.Count == 0);
    }

    public TwoStackQueue()
    {
        stackPush = new Stack<int>();
        stackPop = new Stack<int>();
    }

    //public Queue<int> queue;

    public void Enqueue(int number)
    {
        stackPush.Push(number);
        Debug.Log("Enqueue : " + number);
    }

    public int? Dequeue()
    {
        if (IsEmpty())
        {
            Debug.LogError("The Queue is Empty!");
            return null;
        }
        else if (stackPop.Count == 0)
        {
            while (stackPush.Count != 0)
            {
                int temp = stackPush.Pop();
                stackPop.Push(temp);
            }
        }

        Debug.Log("Dequeue : " + stackPop.Peek());

        return stackPop.Pop();
    }

    public int? Peek()
    {
        if (IsEmpty())
        {
            Debug.LogError("The Queue is Empty!");
            return null;
        }
        else if (stackPop.Count == 0)
        {
            while (stackPush.Count != 0)
            {
                int temp = stackPush.Pop();
                stackPop.Push(temp);
            }
        }

        Debug.Log("Peek : " + stackPop.Peek());

        return stackPop.Peek();
    }

}
