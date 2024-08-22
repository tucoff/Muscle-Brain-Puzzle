using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using TMPro;

public class InteractiveObject : MonoBehaviour
{
    public bool isQuebravel;
    public bool isLuva;
    public Element elementNeeded;
    public GameObject objectToInteract;
    public string[] interactions;
    public float interactionTime = 5f;
    TextMeshProUGUI interactionText;

    private void Start()
    {
        interactionText = GameObject.Find("InteractionText").GetComponent<TextMeshProUGUI>();
        ShowInteraction(interactions[0], 0.1f);
    }

    public void Interact(Directions direction)
    {
        if (elementNeeded == GameObject.Find("Player").GetComponent<PlayerBehaviour>().inUseElement)
        {
            //Só funciona no código da porta, precisa ser modificado posteriormente
            if (objectToInteract != null)
            {
                ShowInteraction(interactions[2], interactionTime);
                objectToInteract.SetActive(false);
            }
        }

        if (isQuebravel && GameObject.Find("Player").GetComponent<PlayerBehaviour>().luvas && GameObject.Find("Player").GetComponent<PlayerBehaviour>().inUseElement == Element.Air)
        {
            ShowInteraction(interactions[1], interactionTime);
            Destroy(this.gameObject, 0.1f);
        }
        else if (isLuva)
        {
            GameObject.Find("Player").GetComponent<PlayerBehaviour>().luvas = true;
            GameObject.FindWithTag("CurrentElement").GetComponent<Image>().color = Color.white;
            isLuva = false;
            GameObject.Find("LuvasLoucas").SetActive(false);
            ShowInteraction(interactions[1], interactionTime);
        }
        else
        {
            ShowInteraction(interactions[0], interactionTime);
        }
    }

    void ShowInteraction(string interaction, float time)
    {
        interactionText.text = interaction;
        interactionText.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = interaction;
        interactionText.gameObject.transform.parent.gameObject.SetActive(true);
        StartCoroutine(HideInteraction(interaction,time));
    }

    IEnumerator HideInteraction(string interaction, float time)
    {
        yield return new WaitForSeconds(time);
        if(interaction == interactionText.text)
        {
            interactionText.gameObject.transform.parent.gameObject.SetActive(false);
            interactionText.text = "";
            interactionText.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
        }
    }
}
