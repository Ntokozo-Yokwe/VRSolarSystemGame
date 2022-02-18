using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetScore : MonoBehaviour
{
    [Tooltip("This field resets the high score text")]
    public Text highScore;

    [Tooltip("This field resets the score text")]
    public Text scoreText;
    
    [Tooltip("This field uses the Right hand cube as the game object that will trigger a reset score")]
    public GameObject resetObject;

    [Tooltip("This field sets the score on game start")]
    public int currentScore;

    /// <summary>
    /// This will allow the right hand cube trigger to trigger the reset button and reset all the scores to 0
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reset") // The cube for triggers will be tagged as Reset so that the Reset only recognizes it as a trigger
        {
            //PlayerPrefs.DeleteAll();
            //PlayerPrefs.DeleteKey(currentScore.ToString("0"));
            PlayerPrefs.DeleteKey("ScoreText");
            PlayerPrefs.DeleteKey("HighScore");
            highScore.text = currentScore.ToString("0");
            scoreText.text = currentScore.ToString("0");
        }
    }
}
