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
    public Sprite[] emotions;
    public float interactionTime = 5f;
    Text interactionText;
    Image emotionsImg;
    public AudioClip audioClip = null;

    private void Start()
    {
        interactionText = GameObject.Find("InteractionText").GetComponent<Text>();
        emotionsImg = GameObject.Find("EmotionImg").GetComponent<Image>();
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
                emotionsImg.sprite = emotions[2];
                GameObject.Find("Player").GetComponent<PlayerBehaviour>().inUseElement = Element.Air;
                GameObject.FindWithTag("CurrentElement").GetComponent<Image>().color = Color.white;
                objectToInteract.SetActive(false);
            }
        }

        if (isQuebravel && GameObject.Find("Player").GetComponent<PlayerBehaviour>().luvas && GameObject.Find("Player").GetComponent<PlayerBehaviour>().inUseElement == Element.Air)
        {
            ShowInteraction(interactions[1], interactionTime);
            emotionsImg.sprite = emotions[1];
            Destroy(this.gameObject, 0.1f);
        }
        else if (isLuva)
        {
            GameObject.Find("Player").GetComponent<PlayerBehaviour>().luvas = true;
            GameObject.FindWithTag("CurrentElement").GetComponent<Image>().color = Color.white;
            isLuva = false;
            GameObject.Find("LuvasLoucas").SetActive(false);
            ShowInteraction(interactions[1], interactionTime);
            emotionsImg.sprite = emotions[1];
        }
        else
        {
            ShowInteraction(interactions[0], interactionTime);
            emotionsImg.sprite = emotions[0];
        }
    }

    bool firstTime = true;
    void ShowInteraction(string interaction, float time)
    {
        interactionText.text = interaction;
        interactionText.gameObject.transform.parent.gameObject.SetActive(true);
        StartCoroutine(HideInteraction(interaction,time));
        if (!firstTime)
        {
            GameObject.Find("PlayerBody").GetComponent<AudioSource>().clip = audioClip;
            GameObject.Find("PlayerBody").GetComponent<AudioSource>().Play();
        }
        else { firstTime = false; } 
    }

    IEnumerator HideInteraction(string interaction, float time)
    {
        yield return new WaitForSeconds(time);
        if(interaction == interactionText.text)
        {
            interactionText.gameObject.transform.parent.gameObject.SetActive(false);
            interactionText.text = "";
        }
    }
}
