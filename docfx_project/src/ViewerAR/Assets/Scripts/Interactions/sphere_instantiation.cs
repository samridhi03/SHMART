using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere_instantiation : MonoBehaviour
{
    public GameObject sphere;
    public GameObject canvasPos;

    public void add_shape()
    {
        GameObject ob = Instantiate(sphere, canvasPos.transform.position,canvasPos.transform.rotation);
        ob.transform.SetParent(canvasPos.transform);
        //ob.transform.position= canvasPos.transform.position;
    }
}
