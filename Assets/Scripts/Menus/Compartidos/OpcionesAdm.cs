using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Encargado de administrar las escenas

public class OpcionesAdm : MonoBehaviour
{
    
    public GameObject Cierra,MenuCofre,MenuSeleccionObj,MenuTiendaPrin,comprar;

    // Start is called before the first frame update
    void Start()
    {
        MenuSeleccionObj.SetActive(false);
        MenuTiendaPrin.SetActive(false);
        //comprar.SetActive(false);

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

        GlobalData.EnCurso = false;
        GlobalData.EnPausa = false;
        GlobalData.EnCofre = false;
        GlobalData.Monedas = 0;
        GlobalData.Srel = false;
        GlobalData.Crel = false;
        GlobalData.Punt1 = 0;
        GlobalData.Punt2 = 0;
        GlobalData.Desb = false;
        GlobalData.Energ = 0;
        GlobalData.EnergLim = 100f;
        GlobalData.EnergSpe = 1f;
        Objetos.Inv1 = 4;
        Objetos.Inv2 = -1;
        Objetos.Inv3 = -1;
        Objetos.Inv4 = -1;
        Objetos.ObjSelec = 0;

       
}

    public void MuestraSeleccionObj()
    {
        MenuSeleccionObj.SetActive(true);               
    }

    public void OcultaSeleccionObj()
    {
        MenuSeleccionObj.SetActive(false);
    }

    public void MuestraTiendaPrin()
    {
        MenuTiendaPrin.SetActive(true);
    }

    public void OcultaTiendaPrin()
    {
        MenuTiendaPrin.SetActive(false);
    }

    public void RegresarMon()
    {
        if (GlobalData.EnTienda)
        {
            GlobalData.Monedas += Precios.ObjPrecios(Objetos.ObjSelec);
        }
        GlobalData.EnTienda = false;

    }
    public void SaleTienda()
    {

        GlobalData.EnTienda = false;
    }
    public void Comprar()
    {
        comprar.SetActive(false);
        MuestraSeleccionObj();
        GlobalData.Monedas -= Objetos.PrecioSelec;
        GlobalData.EnTienda = true;
        
    }
}
