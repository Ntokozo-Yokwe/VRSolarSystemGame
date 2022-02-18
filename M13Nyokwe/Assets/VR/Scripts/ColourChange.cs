using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    public void Red()
    {
        GetComponent<Renderer>().material.color = Color.red;
        Debug.Log("Called");
    }

    public void Blue()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    public void Black()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }
}
