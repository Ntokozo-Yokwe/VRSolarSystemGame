using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject Player;
    public GameObject PlayerPrefab;

    public GameObject SpawnLocation;

    // Start is called before the first frame update
    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("MM") == null)
        {
            Player = Instantiate(PlayerPrefab);
            Player.transform.position = SpawnLocation.transform.position;
            
        }

        else if (GameObject.FindGameObjectsWithTag("MM") != null)
        {
            //Player already exists 
            //Player = GameObject.FindGameObjectsWithTag("Player");
            Player.transform.position = SpawnLocation.transform.position;
            //Destroy(PlayerPrefab);
        }
    }
}
