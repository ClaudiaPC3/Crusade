using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavConexion : MonoBehaviour
{
    public Toggle Crear;
    public Toggle Unir;
    public GameObject Entrar;
    public GameObject IpTexto;
    // Start is called before the first frame update
    void Start()
    {
        Entrar.SetActive(false);
        IpTexto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Crear.isOn||Unir.isOn)
        {
            Entrar.SetActive(true);
        }
        else
        {
            Entrar.SetActive(false);

        }
        
    }

    public void CrearOn()
    {
        if (Crear.isOn)
        {
            Unir.isOn = false;
            IpTexto.SetActive(false);
        }
    }

    public void UnirOn()
    {
        if (!Unir.isOn)
        {
            IpTexto.SetActive(false);
        }
        if (Unir.isOn)
        {
            Crear.isOn = false;
            IpTexto.SetActive(true);
        }
    }

    public void Mostrar()
    {
        Entrar.SetActive(true);
    }
}
