using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
   [SerializeField] private string nomeDoLevelDeJogo;
   [SerializeField] private GameObject painelMenuInicial;
   [SerializeField] private GameObject painelOpcoes;

   public bool worldSelector;

   private void Start() {
      if(worldSelector && PlayerPrefs.GetInt("World2") == 1)
      {
         painelMenuInicial.transform.GetChild(1).gameObject.GetComponent<UnityEngine.UI.Button>().interactable = true;
      }
      
      if(worldSelector && PlayerPrefs.GetInt("World3") == 1)
      {
         painelMenuInicial.transform.GetChild(2).gameObject.GetComponent<UnityEngine.UI.Button>().interactable = true;
      }
   }

   public void Jogar()
   {
    SceneManager.LoadScene(nomeDoLevelDeJogo);
   }

   public void AbrirOpcoes()
   {
    painelMenuInicial.SetActive(false);
    painelOpcoes.SetActive(true);
   }

   public void FecharOpcoes()
   {
    painelOpcoes.SetActive(false);
    painelMenuInicial.SetActive(true);
   }

   public void SairJogo()
   {
    Debug.Log("Sair do Jogo");
    Application.Quit();
   }
}
