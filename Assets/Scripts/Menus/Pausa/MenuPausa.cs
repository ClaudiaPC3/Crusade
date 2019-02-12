using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Encargado de administrar las escenas

public class MenuPausa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargaEscena(string EscenaNombre)
    {
        SceneManager.LoadScene(EscenaNombre);  //Ejecuta la escena enviada en el string del parámetro 
        GlobalData.EnPausa = false;
    }
}
