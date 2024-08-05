using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public bool N, S, L, O;
    public float cd = 0;

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        if (horizontalInput < 0 && O)
        {
            transform.position = GameObject.Find("O").transform.position;
        }
        else if (horizontalInput > 0 && L)
        {
            transform.position = GameObject.Find("L").transform.position;
        }
        else if (verticalInput > 0 && N)
        {
            transform.position = GameObject.Find("N").transform.position;
        }
        else if (verticalInput < 0 && S)
        {
            transform.position = GameObject.Find("S").transform.position;
        }

        cd = 0.5f;
        StartCoroutine(Cooldown());
    }


    void Start()
    {
        
    }

    void Update()
    {
        if(cd == 0)
        {
            Movement();
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cd);
        cd = 0;
    }
}
