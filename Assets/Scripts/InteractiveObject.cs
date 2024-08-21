using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class InteractiveObject : MonoBehaviour
{
    public bool isQuebravel;
    public bool isLuva;
    public Element elementNeeded;
    public GameObject objectToInteract;

    public void Interact(Directions direction)
    {
        if (elementNeeded == GameObject.Find("Player").GetComponent<PlayerBehaviour>().inUseElement)
        {
            //Só funciona no código da porta, precisa ser modificado posteriormente
            if (objectToInteract != null)
            {
                objectToInteract.SetActive(false);
            }
        }

        if (isQuebravel && GameObject.Find("Player").GetComponent<PlayerBehaviour>().luvas && GameObject.Find("Player").GetComponent<PlayerBehaviour>().inUseElement == Element.Air)
        {
            Destroy(this.gameObject);
        }
        else if (isLuva)
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
