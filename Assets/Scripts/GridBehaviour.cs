using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehaviour : MonoBehaviour
{
    void Awake()
    {
        for (int i = this.transform.childCount; i > 0; i--)
        {
            GameObject child = this.transform.GetChild(i - 1).gameObject;
            Vector3 nextPosition = new Vector3(Mathf.Round(child.transform.position.x), Mathf.Round(child.transform.position.y), Mathf.Round(child.transform.position.z));
            child.transform.position = nextPosition;
        }
    }
}
