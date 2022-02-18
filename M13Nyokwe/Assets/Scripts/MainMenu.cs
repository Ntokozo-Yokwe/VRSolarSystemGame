using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void OnEnable()
    {
        SceneManager.LoadScene(1);
    }
    /*public void SolarSystem()
    {
        SceneManager.LoadScene(0);
        //SceneManager.UnloadSceneAsync(1);
    }

    public void SpaceBall()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        EndGame();
    }
    */
}