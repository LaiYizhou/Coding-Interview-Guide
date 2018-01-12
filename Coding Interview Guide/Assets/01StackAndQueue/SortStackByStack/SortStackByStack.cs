using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortStackByStack : MonoBehaviour
{

    private Stack<int> stack;

    private List<int> testList = new List<int>(){3,5,4,1,2};

	// Use this for initialization
	void Start ()
	{

	    Test();
	}

    private void Test()
    {
        stack = new Stack<int>();
        for(int i = 0; i<testList.Count; i++)
            stack.Push(testList[i]);

        SortByStack(stack);

    }

    private void SortByStack(Stack<int> s)
    {
        Stack<int> help = new Stack<int>();

        while (s.Count != 0)
        {
            int cur = s.Pop();
            while(help.Count!=0 && cur > help.Peek())
                stack.Push(help.Pop());

            help.Push(cur);
        }

        while(help.Count!=0)
            stack.Push(help.Pop());

    }

    // Update is called once per frame
    void Update () {
		
	}
}
