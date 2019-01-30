using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regresa : MonoBehaviour 
{
    public Pausa Regresar;  //Objeto Regresar del tipo Pausa (Otro script)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Salir()
    {
        Regresar.Cambio();   //Invoca La función Cambio() del script Pausa
    }

    // Update is called once per frame
    
}