using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class PlayerAnimate : MonoBehaviour
{
    public Animator animator;
    public Directions direction = Directions.None;
    public bool walking = false;

    void FixedUpdate()
    {
        direction = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>().direction;
        walking = this.gameObject.GetComponent<FollowPlayer>().walking;

        if (walking)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }

        switch (direction)
        {
            case Directions.North:
                animator.SetInteger("Direction", 0);
                break;
            case Directions.East:
                animator.SetInteger("Direction", 1);
                break;
            case Directions.South:
                animator.SetInteger("Direction", 2);
                break;
            case Directions.West:
                animator.SetInteger("Direction", 3);
                break;
            default:
                break;
        }
    }
}
