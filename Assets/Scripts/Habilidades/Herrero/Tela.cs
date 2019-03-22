using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tela : MonoBehaviour
{
    private GameObject[] telas;
    // Start is called before the first frame update
    void Start()
    {
        telas= GameObject.FindGameObjectsWithTag("Tela");
        if (telas.Length > 4)
        {
            Destroy(telas[0]);
        }
    }

}
