using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{

    public float TiempoNivel = 15.0f;



    void Start()
    {
        StartCoroutine(FinishLevel());

    }
    private IEnumerator FinishLevel()
    {

        ScoreScript.scoreValue = 0;
        yield return new WaitForSeconds(TiempoNivel);
        SceneManager.LoadScene("Title");





    }
}


