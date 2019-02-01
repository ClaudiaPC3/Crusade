using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Encargado de administrar las escenas

public class CabOpc : MonoBehaviour
{
    public GameObject Capsula;
    public Vector3 eo;

    // Start is called before the first frame update
    void Start()
    {
        Capsula = GameObject.Find("Capsula");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CargaEscena(string EscenaNombre)
    {
        eo = new Vector3(3, 0, 0);
        Capsula.transform.position = eo;
        SceneManager.LoadScene(EscenaNombre);  //Ejecuta la escena enviada en el string del parámetro 
    }

    public void Salir()
    {
        Application.Quit();                    //Cierra la aplicación
    }
}
