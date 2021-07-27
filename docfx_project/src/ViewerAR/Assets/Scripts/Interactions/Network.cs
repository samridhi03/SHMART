using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;

public class Network : MonoBehaviour
{
    public GameObject rb;
    public GameObject pointer;

    public GameObject checkSelection;

    SocketIOComponent socket;
    Check_Selection l;

    JSONObject msg;
    public void Start()
    {
        msg = new JSONObject();
        GameObject sock = GameObject.Find("SocketIO");
        socket = sock.GetComponent<SocketIOComponent>();
        socket.On("ConnectionEstablished", OnConnection);
        socket.On("TestMessage", OnReceive);
    }
    private void OnConnection(SocketIOEvent eve)
    {
        Debug.Log("Connection is established: " + eve.data.GetField("id"));
    }

    //recieve message method
    private void OnReceive(SocketIOEvent e)
    {
        string da = e.data.ToString();
        //Debug.Log(da);
        if (da.Contains("swipeUp"))
        {
            //pointer.GetComponent<OnCollision>().SwipeUpMessage();
            pointer.GetComponent<SelectObject>().swipeUpMessage();
        }
        
        else if (da.Contains("swipeDown"))
        {
            //pointer.GetComponent<OnCollision>().SwipeDownMessage();
            pointer.GetComponent<SelectObject>().swipeDownMessage();

        }
        else if (da.Contains("swipeLeft"))
        {
            //pointer.GetComponent<CurvedLineComponent>().Delete();
        }
        else if (da.Contains("swipeRight"))
        {
            //rb.GetComponent<Move>().MoveRight(1);

        }else if (da.Contains("tap"))
        {
            //pointer.GetComponent<SelectObject>().tapMessage("tap");
        }
        else if (da.Contains("DoubleTap"))
        {
            rb.GetComponent<CheckSelection>().ListOfObject("DoubleTap");
        }
        else if (da.Contains("hold"))
        {
            pointer.GetComponent<CurvedLineComponent>().Draw();

        }else if (da.Contains("x"))
        {
            rb.GetComponent<carController>().enabled=true;

        }else if (da.Contains("y"))
        {
            rb.GetComponent<carController>().enabled=true;
        }
        else if (da.Contains("z"))
        {
            rb.GetComponent<carController>().enabled = true; ;
        }
        else if (da.Contains("NegativeY"))
        {
            rb.GetComponent<CheckSelection>().ListOfObject("NegativeY");
        }
       

    }

    
}

    //send message method
    /*public void SendSocketMessage(string message)
    {
        // Debug.Log(message);
        string qwe = message;
    }*/

    /*private void SendIt()
    {

        msg.AddField("message", "cube");
        socket.Emit("Message", msg);

    }
    // Update is called once per frame
    void Update()
    {
        
    }*/
