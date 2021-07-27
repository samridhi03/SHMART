using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    //Check_Selection check = new Check_Selection();
    public List<GameObject> list = new List<GameObject>();

    public Color blueColor;
    public Color whiteColor;
    public Color greenColor;

    /// <summary>
    /// OnTriggerEnter method
    /// </summary>
    /// <param name="other"></param>
    /// 
    public void OnTriggerEnter(Collider other)
    {
        other.transform.GetComponent<Renderer>().material.color = blueColor;

        if (other.gameObject.tag == "Selectable")
        {
            //gameObject added to the list onTrigggerEnter
            list.Add(other.gameObject);
            Debug.Log("object addded");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        other.transform.GetComponent<Renderer>().material.color = default;
    }

    public void SwipeDownMessage()
    {
        foreach(GameObject o in list)
        {
            //Turned all selected gameObjects to green
            Debug.Log("swipedown message called");
            o.transform.GetComponent<MeshRenderer>().material.color = greenColor;
            o.transform.SetParent(gameObject.transform);
            o.transform.position = gameObject.transform.position;
        }

    }

    public void SwipeUpMessage()
    {
        Debug.Log("swipeup message reached");

        /*foreach (GameObject o in list)
        {
            //Turned all selected gameObjects to green
            Debug.Log("swipeUp message called");
            o.transform.GetComponent<MeshRenderer>().material.color = default;
            o.transform.parent = null;
            o.transform.position = gameObject.transform.position;
        }*/
    }
   
   
}
