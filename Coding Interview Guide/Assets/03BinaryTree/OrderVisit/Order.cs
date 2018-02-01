using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
        TreeNode node1 = new TreeNode(1);
        TreeNode node2 = new TreeNode(2);
        TreeNode node3 = new TreeNode(3);
        TreeNode node4 = new TreeNode(4);
        TreeNode node5 = new TreeNode(5);
        TreeNode node6 = new TreeNode(6);
	    TreeNode node7 = new TreeNode(7);

	    node1.left = node2;
	    node1.right = node3;

	    node2.left = node4;
	    node2.right = node5;

	    node3.left = node6;
	    node3.right = node7;


	    TreeNode head = node1;

        PosOrderR(head);
        PosOrder(head);

    }

    public void PreOrderR(TreeNode head)
    {
        if(head == null)
            return;

        Debug.Log(head.value);
        PreOrderR(head.left);
        PreOrderR(head.right);

    }

    public void InOrderR(TreeNode head)
    {
        if (head == null)
            return;

        InOrderR(head.left);
        Debug.Log(head.value);
        InOrderR(head.right);
    }

    public void PosOrderR(TreeNode head)
    {
        if (head == null)
            return;

        PosOrderR(head.left);
        PosOrderR(head.right);
        Debug.Log(head.value);
        
    }

    public void PreOrder(TreeNode head)
    {
        if(head == null)
            return;

        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(head);

        while (stack.Count!=0)
        {
            TreeNode temp = stack.Pop();
            Debug.Log(temp.value);

            if(temp.right!=null)
                stack.Push(temp.right);

            if(temp.left!=null)
                stack.Push(temp.left);

        }

    }

    public void InOrder(TreeNode head)
    {
        if (head == null)
            return;

        Stack<TreeNode> stack = new Stack<TreeNode>();

        while (stack.Count != 0 || head != null)
        {
            if (head != null)
            {
                stack.Push(head);
                head = head.left;
            }
            else
            {
                head = stack.Pop();
                Debug.Log(head.value);
                head = head.right;
            }
        }

    }

    public void PosOrder(TreeNode head)
    {
        if (head == null)
            return;

        Stack<TreeNode> stack1 = new Stack<TreeNode>();
        Stack<TreeNode> stack2 = new Stack<TreeNode>();

        stack1.Push(head);
        while (stack1.Count != 0)
        {
            TreeNode temp = stack1.Pop();
            stack2.Push(temp);

            if(temp.left != null)
                stack1.Push(temp.left);

            if(temp.right != null)
                stack1.Push(temp.right);

        }

        while (stack2.Count!=0)
        {
            Debug.Log(stack2.Pop().value);
        }


    }

}
