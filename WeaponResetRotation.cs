using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponResetRotation : MonoBehaviour
{



    private void OnDisable()
 
    {
        transform.rotation = quaternion.identity;
    }

    private void OnEnable()
    {
        transform.rotation = quaternion.identity;
    }
}

   

