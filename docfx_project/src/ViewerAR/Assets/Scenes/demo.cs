using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
public class demo : MonoBehaviour
{
    SocketIOComponent socket;

    public float backWheelDistance = 1;
    private GameObject dummyPivot;
    float turningCenterDistance = 5;
    public float x, y;
    Rigidbody rb;

    void Start()
    {
        dummyPivot = new GameObject("dummyParent");
        dummyPivot.transform.parent = this.transform;
        dummyPivot.transform.localRotation = Quaternion.identity;
        dummyPivot.transform.localPosition = Vector3.zero;
        dummyPivot.transform.parent = null;

        rb = GetComponent<Rigidbody>();

        GameObject sock = GameObject.Find("SocketIO");
        socket = sock.GetComponent<SocketIOComponent>();
        socket.On("TestMessage", OnMessage);
    }

    private void OnMessage(SocketIOEvent e)
    {   
        string str = e.data.ToString();
        if (str.Contains("acceleration"))
        {
            string str1 = str.Trim('"', '}', '{');
            string[] deli = { ",", "(", ")" };
            string[] str2 = str1.Split(deli, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < str2.Length; i++)
            {
                if (i == 1)
                {
                    x = float.Parse(str2[i]);
                    
                    Debug.Log("x:"+str2[i]);
                }
                if (i == 2)
                {
                    y = float.Parse(str2[i]);
                    Debug.Log("y:" + str2[i]);
                }
                /*  if (i == 3)
                  {
                      z = float.Parse(str2[i]);
                  }*/
            }
        }else if (str.Contains("hold"))
        {
            move();
        }
        else if (str.Contains("tap"))
        {
            stop();
            x = 0;
        }
        Rotate();

        //Debug.Log(str);

    }
    /*string str = e.data.ToString();
    //Debug.Log(str);
    string str1 = str.Trim('"', '}', '{');
    if (e.data.ToString().Contains("x"))
    {
        string[] delimited = { ",", "(", ")", ":", " }", "{" };
        string[] str2 = str1.Split(delimited, System.StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < str2.Length; i++)
        {
            if (i == 2)
            {
                x = float.Parse(str2[i]);
                Debug.Log(str2[i]);
            }
        }
    }

    else if (e.data.ToString().Contains("y"))
    {
        string[] delimited = { ",", "(", ")", ":", " }", "{" };
        string[] str2 = str1.Split(delimited, System.StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < str2.Length; i++)
        {
            if (i == 2)
            {
                y = float.Parse(str2[i]);
                Debug.Log(str2[i]);
            }
        }
    }

}*/

    // Update is called once per frame
    void FixedUpdate()
    {
        Rotate();
        
    }

    public void Rotate()
    {
        if (x == -1.0f && y == 0.0f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 2);
        }
        else if (y >= 0.2f && x >= -0.9f )
        {
            this.transform.parent = dummyPivot.transform;
            this.transform.localPosition = new Vector3(0, 0, backWheelDistance);
            Vector3 turningPivotPoint = dummyPivot.transform.TransformPoint(new Vector3(-turningCenterDistance, 0, 0));
            dummyPivot.transform.RotateAround(turningPivotPoint, -Vector3.up, 20 * Time.deltaTime);
        }
        else if (y <= -0.1f && x <= -0.9f)
        {
            this.transform.parent = dummyPivot.transform;
            this.transform.localPosition = new Vector3(0, 0, backWheelDistance);
            Vector3 turningPivotPoint = dummyPivot.transform.TransformPoint(new Vector3(turningCenterDistance, 0, 0));
            dummyPivot.transform.RotateAround(turningPivotPoint, Vector3.up, 20 * Time.deltaTime);
        }
    
        /*  float angle = Mathf.Atan2(x, y) * Mathf.Rad2Deg + transform.eulerAngles.y;
          Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);
          //rb.constraints = RigidbodyConstraints.FreezeAll;
  */
        /*if (Mathf.Sign(x) >= 0.2f)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        else if (Mathf.Sign(x) <= 0.1f)
        {
            transform.Translate(Vector3.left * Time.deltaTime);

            //move left
            //transform.LookAt(transform.left)
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.left);
        }
        else if (Mathf.Sign(y) >= 0.1f)
        {
            //rb.constraints = RigidbodyConstraints.None;
            transform.Translate(Vector3.up * Time.deltaTime);

            //move right
            //transform.RotateAround(transform.position, Vector3.right, 30 * Time.deltaTime);

            //transform.LookAt(transform.position + transform.right);

        }
        else if (Mathf.Sign(y) <= 0.2f)
        {
            transform.Translate(Vector3.down * Time.deltaTime);


            //rb.constraints = RigidbodyConstraints.FreezeAll;

            //transform.Translate(Vector3.back * Time.deltaTime * 10);

        }*/




        //rb.velocity = new Vector2(dirX, 0f);
    }

    public void move()
    {
        rb.constraints = RigidbodyConstraints.None;

        transform.Translate(Vector3.forward * Time.deltaTime);
    }
    public void stop()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;

    }
}
