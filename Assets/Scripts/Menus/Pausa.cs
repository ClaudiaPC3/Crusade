using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject MenuPausa;   //Objeto del juego
    public int estado=1;  //Variable de control para el menu

    // Start is called before the first frame update
    void Start()
    {
        MenuPausa.SetActive(false);   //Al iniciar el menu es invisible
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))      //Obtiene la lectura de la tecla ESC
        {
            Cambio();
        }
    }

    public void Cambio()
    {
        if (estado == 1)
        {
            Pausear();
        }

        else if (estado == 0)
        {
            Continuar();
        }      
    }

    public void Pausear()
    {
        MenuPausa.SetActive(true);             //Activa el menu 
        estado = 0;                            //Modifica la variable de control
    }

    public void Continuar()
    {
        MenuPausa.SetActive(false);           //Esconde menu      
        estado = 1;                           //Modifica la variable de control          
    }
}
