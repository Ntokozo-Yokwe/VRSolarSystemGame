using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewScoreSystem : MonoBehaviour
{
    /// <summary>
    /// This Trigger will be placed in all the calls and will destroy the balls when they collide with the Miss Trigger game object
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Score") // The Miss Trigger will be tagged as Score 
        {
            Destroy(gameObject);
        }
    }

}
