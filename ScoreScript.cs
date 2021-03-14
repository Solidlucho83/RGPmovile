using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;

    Text score;

    void Start()
    {

        score = GetComponent<Text>();
        //  DontDestroyOnLoad(this.gameObject);
    }


    void Update()
    {
        score.text = "SCORE: " + scoreValue;
      
        if (scoreValue > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", scoreValue);
        }
    }

}
