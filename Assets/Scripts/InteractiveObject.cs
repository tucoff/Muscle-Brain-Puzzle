using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class InteractiveObject : MonoBehaviour
{
    public bool isQuebravel;
    public bool isLuva;
    public Element elementNeeded;
    public GameObject objectToInteract;

    public void Interact(Directions direction)
    {
        if(elementNeeded == GameObject.Find("Player").GetComponent<PlayerBehaviour>().inUseElement)
        {
            //Só funciona no código da porta, precisa ser modificado posteriormente
            objectToInteract.SetActive(false);
        }

        if(isQuebravel && GameObject.Find("Player").GetComponent<PlayerBehaviour>().luvas && GameObject.Find("Player").GetComponent<PlayerBehaviour>().inUseElement == Element.Air)
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
            GameObject.FindWithTag("CurrentElement").GetComponent<Image>().color = Color.white;
        }
        else
        {
            Debug.Log("Interagindo com " + this.gameObject.name);
        }
    }
}
