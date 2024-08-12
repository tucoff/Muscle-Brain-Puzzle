using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysLookAtCamera : MonoBehaviour
{
    void FixedUpdate()
    {
        //Se existir uma camera, sempre olha pra ela
        GameObject camera = GameObject.FindWithTag("MainCamera");
        if (camera != null)
        {
            transform.LookAt(camera.transform);
        }
    }
}
