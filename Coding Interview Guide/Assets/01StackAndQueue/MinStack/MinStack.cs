using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinStack
{
    private Stack<int> s1Data;
    private Stack<int> s2Min;

    public MinStack(int number)
    {
        s1Data = new Stack<int>(number);
        s2Min = new Stack<int>(number);
    }

    public MinStack()
    {
        s1Data = new Stack<int>();
        s2Min = new Stack<int>();
    }

    public int Peek()
    {
        return s1Data.Peek();
    }

    public int? Pop()
    {
        if (s1Data.Count == 0)
        {
            Debug.LogError("The MinStack is Empty");
            return null;
        }
        else
        {
            s2Min.Pop();
            Debug.Log("Pop : " + s1Data.Peek() + " | Now Min = " + getMin());
            return s1Data.Pop();
        }


    }

    public void Push(int number)
    {
        s1Data.Push(number);

        if(s2Min.Count == 0)
            s2Min.Push(number);
        else if(getMin() > number)
            s2Min.Push(number);
        else
        {
            int temp = s2Min.Peek();
            s2Min.Push(temp);
        }

        Debug.Log("Push : " + number + " | Now Min = " + getMin());
    }

    public int? getMin()
    {
        if (s2Min.Count == 0)
        {
            Debug.LogError("The MinStack is Empty");
            return null;
        }
        else
        {
            return s2Min.Peek();
        }

    }

}
