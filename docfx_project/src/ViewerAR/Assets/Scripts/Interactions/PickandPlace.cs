using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class PickandPlace : MonoBehaviour
{
    public GameObject[] Markers;
    private List<GameObject> PickedObjects;

    SocketIOComponent socket;


    void Start()
    {
        GameObject sock = GameObject.Find("SocketIO");
        socket = sock.GetComponent<SocketIOComponent>();
        socket.On("TestMessage", OnMessage);

        PickedObjects = new List<GameObject>();
    }

    private void OnMessage(SocketIOEvent e)
    {

        RaycastHit hit;
        if (Physics.SphereCast(transform.position, transform.lossyScale.x / 2, transform.forward, out hit, 10f))
        {
            GameObject f = hit.collider.gameObject;

            if (e.data.ToString().Contains("swipeUp"))
            {
                foreach (GameObject g in Markers)
                {

                    if (g.Equals(f))
                    {
                        for (int i = 0; i < PickedObjects.Count; i++)
                        {
                            PickedObjects[i].transform.SetParent(f.transform);
                            PickedObjects[i].transform.position = f.transform.localPosition;
                            //PickedObjects.Clear();
                        }
                    }

                }

            }//condition for "up" ends

           
            else if (e.data.ToString().Contains("swipeDown"))
            {

                GameObject oTarget = GameObject.Find("PointerTarget");

                foreach (GameObject g in Markers)
                {
                    if (!g.Equals(f))
                    {

                        f.transform.SetParent(oTarget.transform);
                        f.transform.position = oTarget.transform.localPosition;
                        PickedObjects.Add(f);
                    }
                    else
                    {
                        continue;
                    }

                }

            }//condition for 'down' ends*/
        }//hit loop ends

        /*if ((e.data.ToString()).Contains("swipeUp"))
        {

            foreach (Transform child in transform)
            {
                Debug.Log(child.name + " swipeup");
                GameObject t1 = GameObject.Find("ImageTarget_1");
                child.transform.SetParent(t1.transform);
                child.transform.position = transform.position;
            }
        }
        else if ((e.data.ToString()).Contains("swipeDown"))
        {

            foreach (Transform child in transform)
            {
                Debug.Log(child.name + " swipedown");
                child.transform.SetParent(this.transform);
                child.transform.position = transform.position;
            }
        }*/
    }

    private void OnDrawGizmos()
    {
        float maxDistance = 10f;
        RaycastHit hit;
        bool isHit = Physics.BoxCast(transform.position, transform.lossyScale / 2, transform.forward, out hit, transform.rotation, maxDistance);
        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, transform.lossyScale);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
        }
    }

    /*public void hithit(string dir)
   { 
       RaycastHit hit;
       if (Physics.SphereCast(transform.position, transform.lossyScale.x / 2, transform.forward, out hit, 10f))
       {
           GameObject f = hit.collider.gameObject;

           if (dir == "up")
           {
               foreach (GameObject g in Markers)
               {

                   if (g.Equals(f))
                   {
                       for (int i = 0; i < PickedObjects.Count; i++)
                       {
                           PickedObjects[i].transform.SetParent(f.transform);
                           PickedObjects[i].transform.position = f.transform.localPosition;
                           PickedObjects.Clear();
                       }
                   }

               }

           }//condition for "up" ends

           if (dir == "down")
           {

               GameObject oTarget = GameObject.Find("PointerTarget");

               foreach (GameObject g in Markers)
               {
                   if (!g.Equals(f))
                   {

                       f.transform.SetParent(oTarget.transform);
                       f.transform.position = oTarget.transform.localPosition;
                       PickedObjects.Add(f);
                   }
                   else
                   {
                       continue;
                   }

               }

           }//condition for 'down' ends
       }//hit loop ends*/
}

   



