using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class rotate : MonoBehaviour
{
    SocketIOComponent socket;

    
    public float x, y, z;

    void Start()
    {
        GameObject sock = GameObject.Find("SocketIO");
        socket = sock.GetComponent<SocketIOComponent>();
        socket.On("TestMessage", OnMessage);
    }

    //save str1[3] to save the values from the string
    private void OnMessage(SocketIOEvent e)
    {
        string str = e.data.ToString();
        //Debug.Log(str);
        string str1 = str.Trim('"', '}', '{');
        string[] deli = { ",", "(", ")" };
        string[] str2 = str1.Split(deli, System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < str2.Length; i++)
        {
            if (i == 1)
            {
                x = float.Parse(str2[i]);
            }
            if (i == 2)
            {
                y = float.Parse(str2[i]);
            }
            if (i == 3)
            {
                z = float.Parse(str2[i]);
            }
        } 
    }



    /*if (str1.Contains("x"))
    {
        string[] delimited = { ",", "(", ")", ":", " }", "{" };
        string[] str2 = str1.Split(delimited, System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < str1.Length; i++)
        {
            if (i == 2)
            {
                x = float.Parse(str2[i]);

            }
        }


    }
    else if (str1.Contains("y"))
    {
        string[] delimited = { ",", "(", ")", ":", " }", "{" };
        string[] str2 = str1.Split(delimited, System.StringSplitOptions.RemoveEmptyEntries);
        for (int j = 0; j < str1.Length; j++)
        {
            if (j == 2)
            {
                y = float.Parse(str2[j]);
            }
        }

    }
    else if (str1.Contains("z"))
    {

        string[] delimited = { ",", "(", ")", ":", " }", "{" };
        string[] str2 = str1.Split(delimited, System.StringSplitOptions.RemoveEmptyEntries);
        for (int k = 0; k < str2.Length; k++)
        {
            if (k == 2)
            {
                z = float.Parse(str2[3]);
            }
        }
        Debug.Log(z);
    }*/



    //Move m = new Move();

    public void Update()
    {
       

        /*if (z > 0)
        {

        }else if (z < 0)
        {

        }*/
       /* Sendx();
        Sendy();
        Sendz();*/
        //Rotate an object
        Vector3 target;
        target.x = x;
        target.y = y;
        target.z = z;
        this.transform.rotation = Quaternion.Euler(target);
    }
}
