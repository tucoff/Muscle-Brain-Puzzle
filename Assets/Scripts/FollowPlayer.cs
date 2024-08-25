using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 1f;
    public bool walking = false;
    Vector3 playerPos = new Vector3(0, 0, 0);
    public bool animator;

    void FixedUpdate()
    {
        //Se existir um player, segue ele
        GameObject player = GameObject.FindWithTag("Player");
        float difX = player.transform.position.x - transform.position.x; difX = Mathf.Round(difX * 10f) / 10f;
        float difZ = player.transform.position.z - transform.position.z; difZ = Mathf.Round(difZ * 10f) / 10f;
        if (player != null)
        {
            playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerPos, Time.deltaTime * speed);

            if (difX != 0 || difZ != 0)
            {
                walking = true;
            }
            else
            {
                walking = false;
            }    
        }
        
        if (animator)
        {
            Animate();
        }
    }

    void Animate()
    {
        switch (GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>().direction)
        {
            case Directions.North:
                if (walking)
                {
                    Animator animator = GetComponent<Animator>();
                    animator.Play("WalkingN");
                }
                else
                {
                    Animator animator = GetComponent<Animator>();
                    animator.Play("IdleN");
                }
                break;
            case Directions.East:
                if (walking)
                {
                    Animator animator = GetComponent<Animator>();
                    animator.Play("WalkingE");
                }
                else
                {
                    Animator animator = GetComponent<Animator>();
                    animator.Play("IdleE");
                }
                break;
            case Directions.South:
                if (walking)
                {
                    Animator animator = GetComponent<Animator>();
                    animator.Play("WalkingS");
                }
                else
                {
                    Animator animator = GetComponent<Animator>();
                    animator.Play("IdleS");
                }
                break;
            case Directions.West:
                if (walking)
                {
                    Animator animator = GetComponent<Animator>();
                    animator.Play("WalkingW");
                }
                else
                {
                    Animator animator = GetComponent<Animator>();
                    animator.Play("IdleW");
                }
                break;
        }
    }
}
