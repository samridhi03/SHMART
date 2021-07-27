using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_instantiation : MonoBehaviour
{
    public GameObject cube;
    public GameObject canvasPos;

    public void add_shape()
    {
        GameObject ob = Instantiate(cube, canvasPos.transform.position, canvasPos.transform.rotation);
        ob.transform.SetParent(canvasPos.transform);
        //ob.transform.position = canvasPos.transform.position;
    }
}
