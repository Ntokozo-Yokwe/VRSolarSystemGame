using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnController : MonoBehaviour
{

    public GameObject Player;
    public GameObject PlayerPrefab;

    //public GameObject SpawnLocation;

    // Start is called before the first frame update
    public void OnAwake()
    {
        if (GameObject.FindGameObjectsWithTag("MM") == null)
        {

            Player = Instantiate(PlayerPrefab);
            //Player.transform.position = SpawnLocation.transform.position;
            //Player already exists 
            //Player = GameObject.FindGameObjectsWithTag("Player");
            //Player.transform.position = SpawnLocation.transform.position;
            //DestroyImmediate(Player, true); //Suggested to use destroy immediate because of an error pop-up
        }

        else if(GameObject.FindGameObjectsWithTag("MM") != null)
        {
            //Player = Instantiate(PlayerPrefab);
            //Player.transform.position = SpawnLocation.transform.position;
            DestroyImmediate(PlayerPrefab, true);
        }
    }
}
