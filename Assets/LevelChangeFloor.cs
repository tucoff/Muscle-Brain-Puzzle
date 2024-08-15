using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeFloor : MonoBehaviour
{
    public int level;
    public CurrentLevel currentLevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            currentLevel.ChangeLevel(level);
        }
    }
}
