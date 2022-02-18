using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class GoalZoneTrigger : MonoBehaviour
{
    [Tooltip("This field sets the score text")]
    public Text scoreText;
    [Tooltip("This field sets the score on Game Start")]
    public int currentScore;
    [Tooltip("This field sets the High score text")]
    public Text highScore;

    /// <summary>
    /// This will save the score as the number and covert it to a string so that it displays on the score board
    /// </summary>
    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }


    /// <summary>
    /// This allows the Balls trigger the goal collider and with a tag it will incriment the current score and once it reaches a higher score than the high score, it will save that high score as the new high score
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball") // the balls will have the tag "Ball" so that the goal zone only recognizes balls as triggers
        {
            currentScore+= 1;
            scoreText.text = currentScore.ToString();

            if(currentScore > PlayerPrefs.GetInt("HighScore", 0)) // This will update the high score if the current score is greater than it
            {
                PlayerPrefs.SetInt("HighScore", currentScore);
                highScore.text = currentScore.ToString();
            }
        }
    }
}