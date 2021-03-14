using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warpoint : MonoBehaviour
{
    public GameObject target;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.transform.position = target.transform.GetChild(0).transform.position;
            
        }
    }
}
