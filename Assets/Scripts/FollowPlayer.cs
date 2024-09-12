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
    public GameObject puncher;

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

    public void Punch()
    {
        animator = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        puncher.GetComponent<SpriteRenderer>().enabled = true;
        StopAllCoroutines();
        StartCoroutine(PunchCoroutine());
        switch (GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>().direction)
        {
            case Directions.North:
                puncher.GetComponent<Animator>().Play("PunchWandN");
                break;
            case Directions.East:  
                puncher.GetComponent<Animator>().Play("PunchEandS");
                break;
            case Directions.South:
                puncher.GetComponent<Animator>().Play("PunchEandS");  
                break;
            case Directions.West:
                puncher.GetComponent<Animator>().Play("PunchWandN");
                break;
        }
    }

    IEnumerator PunchCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        puncher.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        animator = true;
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
