using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chalenge_1 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        List<Transform> children = GetChildren(transform);
    }

    List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();

        foreach (Transform child in parent)
        {
            children.Add(child);
        }
        return children;
    }
}
