using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //Variáveis de controle de movimento
    public bool N, S, L, O;
    public float cd = 0;
    public int elementClose = 0;
    public int inUseElement = 0;
    public float maxCD = 2f;

    //Move o player de bloco em bloco
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        if (horizontalInput != 0 || verticalInput != 0) 
        {   
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

            cd = maxCD;
            StartCoroutine(Cooldown());
        }
    }

    void Update()
    {
        if(cd == 0) //Se o player não estiver em cooldown, ele pode se mover
        {
            Movement();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (elementClose != 0)
            {
                inUseElement = elementClose;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            inUseElement = 0;
        }
    }

    //Tempo até que o player possa se mover novamente ("cd")
    IEnumerator Cooldown() 
    {
        yield return new WaitForSeconds(cd);
        cd = 0;
    }
}
