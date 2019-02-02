using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Encargado de administrar las escenas

public class MagoOpc : MonoBehaviour
{
    public void CargaEscena(string EscenaNombre)
    {        
        GlobalData.Character = 2;
        SceneManager.LoadScene(EscenaNombre);  //Ejecuta la escena enviada en el string del parámetro 
    }

    public void Salir()
    {
        Application.Quit();                    //Cierra la aplicación
    }
}
