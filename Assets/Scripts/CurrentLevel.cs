using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLevel : MonoBehaviour
{
    public int currentLevel = 1;
    public Transform[] levelsCameraPositions;
    public GameObject[] levelBlocks;

    void Start()
    {
        ChangeLevel(1);
    }

    public void ChangeLevel(int n)
    {
        if (currentLevel != n)
        {
            if (currentLevel != 0) { levelBlocks[currentLevel - 1].gameObject.SetActive(false); }
            currentLevel = n;
            Camera.main.transform.position = levelsCameraPositions[currentLevel - 1].position;
            Camera.main.transform.rotation = levelsCameraPositions[currentLevel - 1].rotation;
            levelBlocks[currentLevel - 1].gameObject.SetActive(true);
        }
    }
}
