using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPosLore : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(70);
        SceneManager.LoadScene("Mundo Hugo");
    }
}
