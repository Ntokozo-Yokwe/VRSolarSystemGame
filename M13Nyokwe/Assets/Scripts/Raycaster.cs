using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Raycaster : MonoBehaviour
{
    [Tooltip("Targeted layers")]
    public LayerMask layerMask;

    [Tooltip("Raycast reach")]
    public float distance;

    [System.Serializable]
    public class GameObjectUnityEvent : UnityEvent<GameObject> {}

    [Tooltip("Event triggered when a target is hit, passing the gameobject as argument")]
    public GameObjectUnityEvent hitTarget;

    [System.Serializable]
    public class Vector3UnityEvent : UnityEvent<Vector3> { }

    [Tooltip("Event triggered when a target is hit, passing the Vector3 as argument")]
    public Vector3UnityEvent hitLocation;

    public Vector3UnityEvent hitAngle;

    [Tooltip("Event triggered when you no longer hit a target")]
    public UnityEvent stopHittingTarget;

    [Tooltip("Currently hitting a target")]
    private bool makingContact;


    private void Raycast()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        bool hasHit = Physics.Raycast(ray, out hitInfo, distance, layerMask);

        if (hasHit)
        {
            hitTarget?.Invoke(hitInfo.transform.gameObject);
            hitLocation?.Invoke(hitInfo.point);
            hitAngle?.Invoke(hitInfo.normal);
        }
        else if(makingContact)
        {
            stopHittingTarget?.Invoke();
        }

        if (makingContact != hasHit)
        {
            makingContact = hasHit;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
    }
}
