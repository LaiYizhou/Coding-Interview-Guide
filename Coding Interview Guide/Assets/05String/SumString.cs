using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumString : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public SumString(string s)
    {
        Debug.Log("s = "+s+" ;  "+GetSumString(s));
    }

    public int GetSumString(string s)
    {
        if (s == null)
            return 0;

        int res = 0;
        int num = 0;
        bool isPos = true;

        for (int i = 0; i < s.Length; i++)
        {
            int cur = s[i] - '0';

            if (cur < 0 || cur > 9) // is not Number
            {
                res += num;
                num = 0;

                if (s[i] == '-')
                {
                    if (i-1 >= 0 && s[i-1] == '-')
                        isPos = !isPos;
                    else
                        isPos = false;
                }
                else
                {
                    isPos = true;
                }


            }
            else // is Number
            {
                num = num * 10 + (isPos? cur : -cur);
            }
        }


        res += num;
        return res;

    }

}
