using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    public GameObject endGame;

    // Start is called before the first frame update
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "End")
        {
            Application.Quit();
        }
    }
}
