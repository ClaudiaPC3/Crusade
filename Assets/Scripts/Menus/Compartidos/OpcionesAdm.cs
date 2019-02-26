using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Encargado de administrar las escenas

public class OpcionesAdm : MonoBehaviour
{
    
    public GameObject Cierra,MenuCofre;

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
    }

    public void Salir()
    {
        Application.Quit();                    //Cierra la aplicación
    }

    public void Ocultar()
    {
        Cierra.SetActive(false);
        MenuCofre.SetActive(false);
    }

    public void Reinicio()
    {
        GlobalData.Crel = false;
        GlobalData.EnCurso = false;
        GlobalData.EnPausa = false;
        GlobalData.EnCofre = false;
        GlobalData.Monedas = 0;
        GlobalData.Srel = false;
        GlobalData.Crel = false;
        GlobalData.Punt1 = 0;
        GlobalData.Punt2 = 0;
        GlobalData.Desb = false;
    }

}
