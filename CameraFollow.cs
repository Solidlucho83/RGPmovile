using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject followTarget;
    [SerializeField]
    private Vector3 targetPosition; 
    [SerializeField]
    private float cameraSpeed = 4.0f;

 

    // Start is called before the first frame update
    void Start()
    {
        followTarget = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(followTarget.transform.position.x,
            followTarget.transform.position.y,
            this.transform.position.z);

        //Lerp interpolacion. le da suavidad al movimiento de vectorA a vectorB y ultimo el tiempo
        this.transform.position = Vector3.Lerp(
            this.transform.position, targetPosition,
            cameraSpeed * Time.deltaTime);
    }

    
}
