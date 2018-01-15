using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Hanoi
{
    private string left = "1";
    private string mid = "2";
    private string right = "3";

    private enum EAction
    {
        No,
        LToM,
        MToL,
        MToR,
        RToM
    }

    EAction[] record = new[] { EAction.No };

    public void SolveProblem2(int num)
    {
        if (num < 1)
            return;
        else
        {
            Stack<int> leftStack = new Stack<int>();
            Stack<int> midStack = new Stack<int>();
            Stack<int> rightStack = new Stack<int>();

            leftStack.Push(Int32.MaxValue);
            midStack.Push(Int32.MaxValue);
            rightStack.Push(Int32.MaxValue);

            for(int i = num; i>0; i--)
                leftStack.Push(i);

            int step = 0;
            while (rightStack.Count != num+1)
            {
                step += StackProcess(EAction.MToL, EAction.LToM, leftStack, midStack);

                step += StackProcess(EAction.LToM, EAction.MToL, midStack, leftStack);

                step += StackProcess(EAction.RToM, EAction.MToR, midStack, rightStack);

                step += StackProcess(EAction.MToR, EAction.RToM, rightStack, midStack);
            }


            Debug.Log("###Total: " + step);

        }
    }


    private int StackProcess(EAction noAction, EAction nowAction, Stack<int> from, Stack<int> to)
    {
        if (record[0]!=noAction && from.Peek() < to.Peek())
        {
            to.Push(from.Pop());
            record[0] = nowAction;

            switch (nowAction)
            {
                case EAction.LToM:
                    Move(to.Peek(), left, mid);
                    break;
                case EAction.MToL:
                    Move(to.Peek(), mid, left);
                    break;
                case EAction.MToR:
                    Move(to.Peek(), mid, right);
                    break;
                case EAction.RToM:
                    Move(to.Peek(), right, mid);
                    break;
                default:
                    break;
               
            }

            return 1;
        }

        return 0;
    }











    private void Move(int index, string from, string to)
    {
        Debug.Log("Move " + index + " : " + from + " -> " + to);
    }

    public void SolveProblem1(int num)
    {
        if (num < 1)
            return;
        else
        {
            int res = Process(num, left, right);
            Debug.Log("###Total: "+ res);
        }
    }

    int Process(int num, string from, string to)
    {
        if (num == 1)
        {
            if (from.Equals(mid) || to.Equals(mid))
            {
                Move(1, from, to);
                return 1;
            }
            else
            {
                Move(1, from, mid);
                Move(1, mid, to);
                return 2;
            }
        }
        else
        {
            if (from.Equals(mid) || to.Equals(mid))
            {
                string another = (from.Equals(left) || to.Equals(left)) ? right : left;

                int part1 = Process(num - 1, from, another);
                int part2 = 1;
                Move(num, from, to);
                int part3 = Process(num - 1, another, to);

                return part1 + part2 + part3;

            }
            else
            {
                int part1 = Process(num - 1, from, to);
                int part2 = 1;
                Move(num, from, mid);
                int part3 = Process(num - 1, to, from);
                int part4 = 1;
                Move(num, mid, to);
                int part5 = Process(num - 1, from, to);

                return part1 + part2 + part3 + part4 + part5;
            }
        }
      
    }
}
