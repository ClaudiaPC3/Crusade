using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavConexion : MonoBehaviour
{
    public Toggle Crear;
    public Toggle Unir;
    public GameObject Entrar;
    // Start is called before the first frame update
    void Start()
    {
        Entrar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Crear.isOn||Crear.isOn)
        {
            Entrar.SetActive(true);
        }
        
    }
}
