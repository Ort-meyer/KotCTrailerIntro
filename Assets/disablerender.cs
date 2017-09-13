using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disablerender : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    private void Awake()
    {
        MeshRenderer[] components = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < components.Length; i++)
        {
            components[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
