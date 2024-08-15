using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class PlayerBehaviour : MonoBehaviour
{
    //Variáveis de controle de movimento
    public bool N, S, L, O;
    public float cd = 0;
    public Element elementClose = Element.Air;
    public Element interactive = Element.None;
    public Element inUseElement = Element.Air;
    public float maxCD = 2f;
    public Directions direction = Directions.None;

    //Move o player de bloco em bloco
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            if (horizontalInput < 0 && O)
            {
                transform.position = GameObject.Find("West").transform.position;
                direction = Directions.West;
            }
            else if (horizontalInput > 0 && L)
            {
                transform.position = GameObject.Find("East").transform.position;
                direction = Directions.East;
            }
            else if (verticalInput > 0 && N)
            {
                transform.position = GameObject.Find("North").transform.position;
                direction = Directions.North;
            }
            else if (verticalInput < 0 && S)
            {
                transform.position = GameObject.Find("South").transform.position;
                direction = Directions.South;
            }

            cd = maxCD;
            StartCoroutine(Cooldown());
        }
    }

    void Update()
    {
        if (cd == 0) //Se o player não estiver em cooldown, ele pode se mover
        {
            Movement();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (elementClose != Element.Air)
            {
                inUseElement = elementClose;
            }
            if (interactive != Element.None)
            {
                inUseElement = elementClose;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            inUseElement = Element.Air;
        }
    }

    //Tempo até que o player possa se mover novamente ("cd")
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cd);
        cd = 0;
    }
}
