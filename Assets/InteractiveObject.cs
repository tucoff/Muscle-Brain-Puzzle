using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class InteractiveObject : MonoBehaviour
{
    public bool isQuebravel;
    public bool isLuva;

    public void Interact(Directions direction)
    {
        if(isQuebravel && GameObject.Find("Player").GetComponent<PlayerBehaviour>().luvas)
        {
            Destroy(this.gameObject);
            switch (direction)
            {
                case Directions.North:
                    GameObject.Find("North").GetComponent<IsColliding>().isColliding = false;
                    break;
                case Directions.South:
                    GameObject.Find("South").GetComponent<IsColliding>().isColliding = false;
                    break;
                case Directions.East:
                    GameObject.Find("East").GetComponent<IsColliding>().isColliding = false;
                    break;
                case Directions.West:
                    GameObject.Find("West").GetComponent<IsColliding>().isColliding = false;
                    break;
            }
            GameObject.Find("North").GetComponent<IsColliding>().ChangeDirection();
        }
        else if(isLuva)
        {
            GameObject.Find("Player").GetComponent<PlayerBehaviour>().luvas = true;
            isLuva = false;
            GameObject.Find("LuvasLoucas").SetActive(false);
        }
        else
        {
            Debug.Log("Interagindo com " + this.gameObject.name);
        }
    }
}
