using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Encargado de administrar las escenas

public class RegresoMenus : MonoBehaviour
{
    public string Escena;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))      //Obtiene la lectura de la tecla ESC
        {
            SceneManager.LoadScene(Escena);  //Ejecuta la escena enviada en el string del parámetro 
        }
    }



    // Update is called once per frame

}