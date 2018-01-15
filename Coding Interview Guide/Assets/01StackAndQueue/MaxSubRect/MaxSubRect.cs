using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxSubRect : MonoBehaviour
{

    private int[,] map = new int[,] {{1, 0, 1, 1}, {1, 1, 1, 1}, {1, 1, 1, 0}};

    public MaxSubRect()
    {
        Debug.Log("res = " + maxRectSize());
    }

    // Use this for initialization
	void Start () {
		


	}

    private int maxRectSize()
    {
        int maxArea = 0;

        int[] height = new int[map.GetLength(1)];
        //Debug.Log(height.Length);

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                height[j] = map[i, j] == 0 ? 0 : height[j] + 1;
            }

            maxArea = Mathf.Max(maxArea, maxRectFromBottom(height));
        }

        return maxArea;

    }

    public int maxRectFromBottom(int[] height)
    {
        if (height == null || height.Length == 0)
            return 0;

        int maxArea = 0;
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < height.Length; i++)
        {
            int cur = height[i];
            while (stack.Count != 0 && height[stack.Peek()] >= cur)
                maxArea = Math.Max(maxArea, CalMax(stack, i, height));

            stack.Push(i);
        }

        while (stack.Count != 0)
            maxArea = Math.Max(maxArea, CalMax(stack, height.Length, height));

        return maxArea;
    }

    private int CalMax(Stack<int> stack, int index, int[] height)
    {
        int j = stack.Pop();
        int k = stack.Count != 0 ? stack.Peek() : -1;

        int curArea = (index - k - 1) * height[j];
        return curArea;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
