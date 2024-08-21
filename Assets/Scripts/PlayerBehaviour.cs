using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

public class PlayerBehaviour : MonoBehaviour
{
    //Variáveis de controle de movimento
    public float cd = 0;
    public Element elementClose = Element.Air;
    public Element interactive = Element.None;
    public GameObject objectInteracting;
    public Element inUseElement = Element.Air;
    public float maxCD = 2f;
    public Directions direction = Directions.None;
    public bool luvas = false;
    public Rigidbody m_Rigidbody;
    public LayerMask wallLayer;


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    //Move o player de bloco em bloco
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            if (horizontalInput < 0 && !IsPosInsideCollider(transform.position + new Vector3(-1, 0, 0), wallLayer))
            {
                m_Rigidbody.MovePosition(transform.position + new Vector3(-1, 0, 0));
                IsPosInsideCollider(transform.position + new Vector3(-2, 0, 0), wallLayer);
                direction = Directions.West;
            }
            else if (horizontalInput > 0 && !IsPosInsideCollider(transform.position + new Vector3(1, 0, 0), wallLayer))
            {
                m_Rigidbody.MovePosition(transform.position + new Vector3(1, 0, 0));
                IsPosInsideCollider(transform.position + new Vector3(2, 0, 0), wallLayer);
                direction = Directions.East;
            }
            else if (verticalInput > 0 && !IsPosInsideCollider(transform.position + new Vector3(0, 0, 1), wallLayer))
            {
                m_Rigidbody.MovePosition(transform.position + new Vector3(0, 0, 1));
                IsPosInsideCollider(transform.position + new Vector3(0, 0, 2), wallLayer);
                direction = Directions.North;
            }
            else if (verticalInput < 0 && !IsPosInsideCollider(transform.position + new Vector3(0, 0, -1), wallLayer))
            {
                m_Rigidbody.MovePosition(transform.position + new Vector3(0, 0, -1));
                IsPosInsideCollider(transform.position + new Vector3(0, 0, -2), wallLayer);
                direction = Directions.South;
            }

            cd = maxCD;
            StartCoroutine(Cooldown());
        }
    }
    public bool IsPosInsideCollider(Vector3 _pos, LayerMask wallLayer)
    {
        Collider _hit = Physics.OverlapBox(_pos, new Vector3(.1f, .1f, .1f), Quaternion.identity, wallLayer).FirstOrDefault();
        if (_hit != null)
        {
            if (_hit.transform.gameObject.tag == "Interactive")
            {
                objectInteracting = _hit.transform.gameObject;
            }
            else if (_hit.transform.gameObject.tag == "Elemental")
            {
                elementClose = _hit.transform.gameObject.GetComponent<ElementalBehaviour>().element;
            }
        }
        else
        {
            elementClose = Element.Air;
        }
        return _hit != null;
    }

    void Update()
    {
        if (cd == 0)
        {
            Movement();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (elementClose != Element.Air && luvas)
            {
                inUseElement = elementClose;
            }

            if (interactive == Element.None && objectInteracting != null)
            {
                objectInteracting.GetComponent<InteractiveObject>().Interact(direction);
                objectInteracting = null;
                interactive = Element.None;
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
