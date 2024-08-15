using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 1f;
    void FixedUpdate()
    {
        //Se existir um player, segue ele
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Vector3 playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerPos, Time.deltaTime * speed);
        }
    }
}
