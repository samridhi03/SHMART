using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class collision_selection : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        GameObject p = GameObject.Find("PointerTarget");
        gameObject.transform.SetParent(p.gameObject.transform);
        gameObject.transform.position = p.gameObject.transform.position;
    }

    

    

}
