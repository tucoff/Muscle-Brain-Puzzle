using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class IsColliding : MonoBehaviour
{
    public string direction;
    public bool isColliding;

    void Update()
    {
        switch (direction)
        {
            case "North":
                transform.parent.GetComponent<PlayerBehaviour>().N = !isColliding;
                break;
            case "South":
                transform.parent.GetComponent<PlayerBehaviour>().S = !isColliding;
                break;
            case "East":
                transform.parent.GetComponent<PlayerBehaviour>().L = !isColliding;
                break;
            case "West":
                transform.parent.GetComponent<PlayerBehaviour>().O = !isColliding;
                break;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Elemental" && transform.parent.GetComponent<PlayerBehaviour>().direction.ToString() == direction)
        {
            transform.parent.GetComponent<PlayerBehaviour>().elementClose = other.gameObject.GetComponent<ElementalBehaviour>().element;
        }
        if (other.gameObject.tag == "Interactive" && transform.parent.GetComponent<PlayerBehaviour>().direction.ToString() == direction)
        {
            transform.parent.GetComponent<PlayerBehaviour>().interactive = other.gameObject.GetComponent<ElementalBehaviour>().element;
        }
        isColliding = true;
    }
    void OnTriggerExit(Collider other)
    {
        isColliding = false;
        transform.parent.GetComponent<PlayerBehaviour>().elementClose = Element.Air;
        transform.parent.GetComponent<PlayerBehaviour>().interactive = Element.None;
    }
}
