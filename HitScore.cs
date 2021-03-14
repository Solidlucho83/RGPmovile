using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitScore : MonoBehaviour
{
 
    public Text HighScore;

    void Start()
    {
        HighScore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
