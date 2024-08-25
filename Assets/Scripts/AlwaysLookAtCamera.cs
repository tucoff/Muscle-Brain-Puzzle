using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class AlwaysLookAtCamera : MonoBehaviour
{
    void FixedUpdate()
    {
        //Se existir uma camera, sempre olha pra ela
        GameObject camera = GameObject.FindWithTag("MainCamera");
        if (camera != null)
        {
            transform.LookAt(camera.transform);
            Directions d = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>().direction;
            if (GameObject.FindWithTag("Player") != null && d == Directions.East || d == Directions.North)
            {
                transform.Rotate(0, 180, 0);
            }
            else if (d == Directions.West || d == Directions.South)
            {
                transform.Rotate(0, 0, 0);
            }
        }
    }
}
