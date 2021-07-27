using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GVR_GazeInteraction : MonoBehaviour
{
    public Image pointer_image;
    public UnityEvent GVRClick;
    public float total_time = 2;
    bool gvrStatus;
    public float gvrTimer;
    

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer +=Time.deltaTime;
            pointer_image.fillAmount = gvrTimer / total_time;
        }
        if (gvrTimer > total_time)
        {
            GVRClick.Invoke();
        }
    }


    public void GvrOn()
    {
        gvrStatus = true;
    }
    public void GvrOff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        pointer_image.fillAmount = 0;
    }

    public void display()
    {
        Debug.Log("submit");
    }
}
