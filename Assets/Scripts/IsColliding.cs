using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class IsColliding : MonoBehaviour
{
    public string direction;
    public bool isColliding;

    void Start()
    {
        isColliding = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "IF")
        {
            if (other.gameObject.tag == "Elemental" && transform.parent.GetComponent<PlayerBehaviour>().direction.ToString() == direction)
            {
                transform.parent.GetComponent<PlayerBehaviour>().elementClose = other.gameObject.GetComponent<ElementalBehaviour>().element;
            }
            if (other.gameObject.tag == "Interactive" && transform.parent.GetComponent<PlayerBehaviour>().direction.ToString() == direction)
            {
                if (other.gameObject.GetComponent<ElementalBehaviour>())
                {
                    transform.parent.GetComponent<PlayerBehaviour>().interactive = other.gameObject.GetComponent<ElementalBehaviour>().element;
                }
                else if (other.gameObject.GetComponent<InteractiveObject>())
                {
                    transform.parent.GetComponent<PlayerBehaviour>().interactive = Element.None;
                    transform.parent.GetComponent<PlayerBehaviour>().objectInteracting = other.gameObject;
                }
            }
            isColliding = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        isColliding = false;
        transform.parent.GetComponent<PlayerBehaviour>().elementClose = Element.Air;
        transform.parent.GetComponent<PlayerBehaviour>().interactive = Element.None;
        transform.parent.GetComponent<PlayerBehaviour>().objectInteracting = null;
    }


}
