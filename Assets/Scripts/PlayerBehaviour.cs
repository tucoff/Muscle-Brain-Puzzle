using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
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
    public GameObject particlePower;


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        particlePower = GameObject.FindWithTag("Power");
        particlePower.SetActive(false);
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
            if (_hit.transform.gameObject.GetComponent<InteractiveObject>())
            {
                objectInteracting = _hit.transform.gameObject;
            }
            
            if (_hit.transform.gameObject.GetComponent<ElementalBehaviour>())
            {
                elementClose = _hit.transform.gameObject.GetComponent<ElementalBehaviour>().element;
            }
        }
        else
        {
            objectInteracting = null;
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
                Invoke("NewElement", 0.1f);
            }

            GameObject.FindWithTag("FollowPlayer").GetComponent<FollowPlayer>().Punch();

            if (objectInteracting != null)
            {
                objectInteracting.GetComponent<InteractiveObject>().Interact(direction);
                objectInteracting = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && luvas)
        {
            inUseElement = Element.Air;
            GameObject.FindWithTag("CurrentElement").GetComponent<Image>().color = Color.white;
            particlePower.SetActive(false);
            GameObject.Find("PlayerBody").GetComponent<SpriteRenderer>().color = Color.white;
            GameObject.Find("Puncher").GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    //Tempo até que o player possa se mover novamente ("cd")
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cd);
        cd = 0;
    }

    void NewElement()
    {
        inUseElement = elementClose;
        Color c = Color.white;
        switch (inUseElement)
        {
            case Element.Fire:
                c = Color.red;
                break;
            case Element.Ice:
                c = Color.cyan;
                particlePower.SetActive(true);
                particlePower.GetComponent<ParticleSystem>().startColor = Color.cyan;
                GameObject.Find("PlayerBody").GetComponent<SpriteRenderer>().color = Color.cyan;
                GameObject.Find("Puncher").GetComponent<SpriteRenderer>().color = Color.cyan;
                break;
            case Element.Lightning:
                c = Color.yellow;
                particlePower.SetActive(true);
                particlePower.GetComponent<ParticleSystem>().startColor = Color.yellow;
                GameObject.Find("PlayerBody").GetComponent<SpriteRenderer>().color = Color.yellow;
                GameObject.Find("Puncher").GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case Element.Air:
                c = Color.white;
                particlePower.SetActive(false);
                GameObject.Find("PlayerBody").GetComponent<SpriteRenderer>().color = Color.white;
                GameObject.Find("Puncher").GetComponent<SpriteRenderer>().color = Color.white;
                break;
        }
        GameObject.FindWithTag("CurrentElement").GetComponent<Image>().color = c;
    }
}
