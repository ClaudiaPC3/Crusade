using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cemento : MonoBehaviour
{
    private GameObject[] cementos;

    void Start()
    {
        cementos = GameObject.FindGameObjectsWithTag("Cemento");
        if (cementos.Length > 5)
        {
            Destroy(cementos[0]);
        }

    }

}
