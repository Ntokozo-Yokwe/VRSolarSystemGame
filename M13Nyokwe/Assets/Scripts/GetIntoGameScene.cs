using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetIntoGameScene : MonoBehaviour
{
    [Tooltip("This field uses the cube trigger to restart the game")]
    public GameObject resetObject;

    /// <summary>
    /// This will reload the scene when the right hand cube trigger collides with this button to restart the game
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reset") // The right hand cube trigger is tagged "Reset" so that the restart button is only triggered by it
        {

            SceneManager.LoadScene(1);

        }
    }
}