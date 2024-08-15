using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsColliding : MonoBehaviour
{
    public string direction;
    public bool isColliding;

    void Update()
    {
        switch (direction)
        {
            case "N":
                transform.parent.GetComponent<PlayerBehaviour>().N = !isColliding;
                break;
            case "S":
                transform.parent.GetComponent<PlayerBehaviour>().S = !isColliding;
                break;
            case "L":
                transform.parent.GetComponent<PlayerBehaviour>().L = !isColliding;
                break;
            case "O":
                transform.parent.GetComponent<PlayerBehaviour>().O = !isColliding;
                break;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "IF")
        {   
            if (other.gameObject.tag == "Elemental")
            {
                transform.parent.GetComponent<PlayerBehaviour>().elementClose = other.gameObject.GetComponent<ElementalBehaviour>().element;
            }
            isColliding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }
}
