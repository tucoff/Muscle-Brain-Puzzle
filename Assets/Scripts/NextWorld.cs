using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextWorld : MonoBehaviour
{
    public int nextWorld = 0; 

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (nextWorld == 2)
            {
                PlayerPrefs.SetInt("World2", 1);
            }
            else if (nextWorld == 3)
            {
                PlayerPrefs.SetInt("World3", 1);
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
