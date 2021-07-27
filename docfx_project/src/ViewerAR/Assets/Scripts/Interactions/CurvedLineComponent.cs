using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class CurvedLineComponent : MonoBehaviour
{

    SocketIOComponent socket;

    List<GameObject> li = new List<GameObject>();

    void Start()
    {
        //currentAngle = initialAngle_0;

        GameObject sock = GameObject.Find("SocketIO");
        socket = sock.GetComponent<SocketIOComponent>();
        socket.On("TestMessage", OnMessage);
    }

    private void OnMessage(SocketIOEvent e)
    {
        if ((e.data.ToString()).Contains("hold"))
        {
            GameObject ImgTarget = GameObject.Find("Target3");

            Vector3 clonePos = transform.position;
            Quaternion cloneRot = transform.rotation;

            //instantiate a point at every hit 
            GameObject var = Instantiate(clone, clonePos, Quaternion.identity);
            var.transform.parent = ImgTarget.transform;
            li.Add(var);
            RearrangePositions(li);
        }
        else if ((e.data.ToString()).Contains("swipeLeft"))
        {
            DeleteAll();
        }

    }
    public GameObject[] Markers;
    public GameObject clone;


    public void RearrangePositions(List<GameObject> li) 
    {
        if (li != null)
        {
            for(int i=0;i<li.Count;i++)
            {
                if(li[i].transform.position != li[i+1].transform.position)
                {
                    continue;
                }
                else
                {
                    li[i + 1].transform.position = new Vector3(li[i + 1].transform.position.x*2, li[i + 1].transform.position.y*2, li[i + 1].transform.position.z*2);
                }
            }

        }
    }
 
    public void  Draw()
    {
        RaycastHit hit;
        Physics.SphereCast(transform.position, transform.lossyScale.x / 2, transform.forward, out hit, 10f);
        GameObject f = hit.collider.gameObject;
        string hit_object_name = f.name;
        GameObject ImgTarget = GameObject.Find(hit_object_name);
        GameObject var = Instantiate(clone,hit.transform.position, Quaternion.identity);
        li.Add(var);
        var.transform.parent = ImgTarget.transform;

    }

    public void DeleteAll()
    {
        //Delete all
        if (li != null)
        {
            foreach(GameObject ob in li)
            {
                Destroy(ob);
            }
        }
    }
    /// <summary>
    /// Delete one by one function
    /// </summary>
  /*  public void DeleteImmediateOne()
    {
        //Delete objects one by one
        if (li != null)
        {
            for (int i = 0; i < li.Count; i++)
            {
                li[i].transform.parent = null;

                Destroy(li[i].gameObject);
            }
        }
        GameObject ob = GameObject.Find("PointPrefab(Clone)");
        Destroy(ob);
        Debug.Log("deleted?");
    }*/

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
            //Gizmos.color = Color.green;
            //Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
        }
    }
}
