using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PathArray : MonoBehaviour {

	// Use this for initialization
	void Start () {

	    int[] paths = new int[] { 9, 1, 4, 9, 0, 4, 8, 9, 0, 1 };
	    Print(paths);

	    PathsToDistances(paths);
	    Print(paths);

	    DistancesToNums(paths);
        Print(paths);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void PathsToDistances(int[] path)
    {
        int cap = 0;

        for (int i = 0; i < path.Length; i++)
        {
            if (path[i] == i)
                cap = i;
            else if (path[i] > -1)
            {
                int curIndex = path[i];
                int preIndex = i;
                

                path[i] = -1;

                while (path[curIndex] != curIndex)
                {
                    if (path[curIndex] > -1)
                    {
                        int nextIndex = path[curIndex];
                        path[curIndex] = preIndex;
                        preIndex = curIndex;
                        curIndex = nextIndex;
                    }
                    else
                    {
                        break;
                    }
                }

                int value = path[curIndex] == curIndex ? 0 : path[curIndex];

                while (path[preIndex]!=-1)
                {
                    int lastPreIndex = path[preIndex];
                    path[preIndex] = --value;
                    //curIndex = preIndex;
                    preIndex = lastPreIndex;
                }
                path[preIndex] = value - 1;
            } 
        }

        path[cap] = 0;

    }

    private void DistancesToNums(int[] dis)
    {
        for (int i = 0; i < dis.Length; i++)
        {
            int index = dis[i];
            if (index < 0)
            {
                dis[i] = 0;
                while (true)
                {
                    index = -index;
                    if (dis[index] > -1)
                    {
                        dis[index]++;
                        break;
                    }
                    else
                    {
                        int nextIndex = dis[index];
                        dis[index] = 1;
                        index = nextIndex;
                    }
                }
            }
        }

        dis[0] = 1;
    }

    private void Print(int[] paths)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < paths.Length; i++)
        {
            sb.Append(paths[i]).Append(", ");
        }

        Debug.Log(sb.ToString());
    }

}
