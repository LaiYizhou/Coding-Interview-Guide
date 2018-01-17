using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaxTreeNameSpace
{
    public class MaxTree : MonoBehaviour
    {
        private int[] arr = new[] { 3, 4, 5, 1, 2 };


        // Use this for initialization
        void Start()
        {

        }

        public MaxTree()
        {
            BuildMaxTree();
        }

        private Node BuildMaxTree()
        {
            Node[] nodeArr = new Node[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                nodeArr[i] = new Node(arr[i]);

            Stack<Node> stack = new Stack<Node>();
            Dictionary<Node, Node> lDictionary = new Dictionary<Node, Node>();
            Dictionary<Node, Node> rDictionary = new Dictionary<Node, Node>();

            for (int i = 0; i < nodeArr.Length; i++)
            {
                Node cur = nodeArr[i];
                while (stack.Count != 0 && stack.Peek().value < cur.value)
                    SetMap(stack, ref lDictionary);

                stack.Push(cur);

            }

            while (stack.Count != 0)
                SetMap(stack, ref lDictionary);

            stack.Clear();

            for (int i = nodeArr.Length - 1; i >= 0; i--)
            {
                Node cur = nodeArr[i];
                while (stack.Count != 0 && stack.Peek().value < cur.value)
                    SetMap(stack, ref rDictionary);

                stack.Push(cur);

            }

            while (stack.Count != 0)
                SetMap(stack, ref rDictionary);


            Node head = null;
            for (int i = 0; i < nodeArr.Length; i++)
            {
                Node cur = nodeArr[i];
                Node leftNode = lDictionary[cur];
                Node rightNode = rDictionary[cur];

                if (leftNode == null && rightNode == null)
                {
                    head = cur;
                }
                else if (leftNode == null)
                {
                    if (rightNode.left == null)
                        rightNode.left = cur;
                    else
                        rightNode.right = cur;
                }
                else if (rightNode == null)
                {
                    if (leftNode.left == null)
                        leftNode.left = cur;
                    else
                        leftNode.right = cur;
                }
                else
                {
                    Node parent = leftNode.value < rightNode.value ? leftNode : rightNode;
                    if (parent.left == null)
                        parent.left = cur;
                    else
                        parent.right = cur;
                }


            }

            return head;


        }

        private void SetMap(Stack<Node> stack, ref Dictionary<Node, Node> dic)
        {
            Node popNode = stack.Pop();
            if (stack.Count == 0)
                dic.Add(popNode, null);
            else
                dic.Add(popNode, stack.Peek());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int data)
        {
            this.value = data;
            left = null;
            right = null;
        }
    }

}

