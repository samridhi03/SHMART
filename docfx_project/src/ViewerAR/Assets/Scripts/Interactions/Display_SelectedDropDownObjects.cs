using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display_SelectedDropDownObjects : MonoBehaviour
{
    //Drag&Drop the prefabs in the inspector
    [SerializeField]
    private GameObject[] shapes;
    private int selectedShapeIndex = -1;

    public GameObject canvasPos;

    private GameObject SelectedShape
    {
        get
        {
            return selectedShapeIndex >= 0 && selectedShapeIndex < shapes.Length ? shapes[selectedShapeIndex] : null;
        }
    }

    //specify this function in the 'OnValueChanged' event
    //of your drop-down, in this inspector
    //choose the function under the "dynamic section"

    public void SelectShape(int index)
    {
        selectedShapeIndex = index;
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectedShape != null)
        {
            GameObject ob = Instantiate(SelectedShape);
            ob.transform.SetParent(canvasPos.transform);
            //  GameObject clone = (GameObject)
        }
    }
}
