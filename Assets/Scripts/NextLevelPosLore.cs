using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPosLore : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("Lore") == 1)
        {
            SceneManager.LoadScene("Mundo Hugo");
        }

        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(70);
        PlayerPrefs.SetInt("Lore", 1);
        SceneManager.LoadScene("Mundo Hugo");
    }
}
