using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticule : MonoBehaviour
{
    [Tooltip("Transform controlling the script")]
    public Transform controller;
    
    [Tooltip("Set the reticule distance from the controller")]
    public float distance = 2;

    [Tooltip("Switch between automatic update and manual update")]
    public bool overrideUpdatePosition;

    /// <summary>
    /// Sets the value of the override Update Position field
    /// </summary>
    /// <param name="value"></param>
    public void OverrideUpdatePosition(bool value)
    {
        overrideUpdatePosition = value;
    }

    /// <summary>
    /// Positions the reticule exactly in front of the controller at a given distance
    /// </summary>
    public void PositionReticule()
    {
        transform.position = controller.position + controller.forward * distance;
    }
    
    /// <summary>
    /// Positions the reticule at a specific position
    /// </summary>
    /// <param name="position"></param>
    public void PositionReticule(Vector3 position)
    {
        transform.position = position;
    }

    public void FaceController()
    {   
        transform.forward = controller.forward;
    }

    public void MatchSurfaceHitAngle(Vector3 angle)
    {
        transform.forward = angle;
        transform.position += angle * 0.02f;
    }

    void Update()
    {
        if(overrideUpdatePosition == false)
        { 
            PositionReticule(); 
            FaceController();
        }
    }
}
