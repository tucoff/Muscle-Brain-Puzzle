using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 1f;    
    void FixedUpdate()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime*speed);
        }
    }
}
