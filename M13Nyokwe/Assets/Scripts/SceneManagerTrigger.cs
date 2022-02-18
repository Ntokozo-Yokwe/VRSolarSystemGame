using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerTrigger : MonoBehaviour
{
    //public GameObject cubeHand;
    public GameObject theSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        theSwitcher.SetActive(false);
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Reset")
        {
            theSwitcher.SetActive(true);
        }
    }
}
