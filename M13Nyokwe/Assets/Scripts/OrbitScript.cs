using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitScript : MonoBehaviour
{
    [SerializeField,  Tooltip("Multiplies the orbit speed")]
    private float multiplier = 1;
    public float Multiplier { set { multiplier = value;  } }

    [Tooltip("The basic orbital rotation speed per seconds")]
    public float OrbitalSpeed = 1;

    [SerializeField, Tooltip("Prevents the execution of the content of this script")]
    private bool pause;
    public bool Pause { set { pause = value; } }
    
    public void TogglePause()
    {
        pause = !pause;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            transform.Rotate(0, Time.deltaTime  / OrbitalSpeed * multiplier, 0, Space.Self);
        }
    }
}
