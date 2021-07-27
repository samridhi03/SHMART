using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using SocketIO;

public class SelectObject : MonoBehaviour
{
    public List<GameObject> selectableObjectList;
    public List<GameObject> markerObjectList;
    public GameObject tar;
    public bool checkTap;

    void Start()
    {
        selectableObjectList = new List<GameObject>();
        markerObjectList = new List<GameObject>();
        checkTap = false;
    }
    
  
    public void ListOfObjects(GameObject ob)
    {
        if (ob.transform.tag == "Selectable")
        {
            if (!(selectableObjectList.Contains(ob)))
            {
                selectableObjectList.Add(ob);
            }
        }

        else if (ob.transform.tag == "Markers")
        {
            if (!(markerObjectList.Contains(ob)))
            {
                markerObjectList.Add(ob);

            }
        }

    }
    //////////////////////////////////////////////////////
    /// <summary>
    /// This functions return Raycast hitPoint
    /// </summary>
    /// <param name="target"></param>
    /// <returns>Vector3</returns>
    public void GetHitPosition(GameObject target)
    {
        tar = target;
        if (tar.transform.tag == "Selectable")
        {
            tar.GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0);
            tar.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
       
    }


    public void swipeDownMessage()
    {
        GameObject p = GameObject.Find("PointerTarget");
      
         foreach(GameObject o in selectableObjectList)
         {
             Debug.Log(o.name+" "+p.name );
             o.transform.SetParent(p.gameObject.transform);
             o.transform.position = p.gameObject.transform.position;
         }
    }
    public void swipeUpMessage()
    {
        GameObject p = GameObject.Find("PointerTarget");
        Transform child = p.gameObject.transform.GetChild(1);
        Debug.Log(child.name);
        foreach(GameObject ob in markerObjectList)
        {
            child.SetParent(ob.transform);
            child.position = ob.transform.position;
        }
    }






    
}