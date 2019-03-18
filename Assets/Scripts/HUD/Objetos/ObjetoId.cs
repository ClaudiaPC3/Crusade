using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoId : MonoBehaviour
{
    public int id;
    public int precio;
   

    public OpcionesAdm MenuSeleccionObj;
    public GameObject comprar,comprarSec;
    public GameObject precioTxt, precioSecTxt;

    void Start()
    {
        comprar = GameObject.FindGameObjectWithTag("Comprar");
        comprarSec = GameObject.FindGameObjectWithTag("ComprarSec");
        precioTxt = GameObject.FindGameObjectWithTag("Precio");
        precioSecTxt = GameObject.FindGameObjectWithTag("PrecioSec");
        //comprar.SetActive(false);
    }

    public void MandarId()
    {
        if (Objetos.esValido(GlobalData.Character, id))
        {
            Objetos.ObjSelec = id;
            MenuSeleccionObj.MuestraSeleccionObj();
        }

    }

    public void MandarIdTienda()
    {
        if (GlobalData.Monedas>=precio)
        {
            Objetos.ObjSelec = id;
            comprar.SetActive(true);
            comprarSec.SetActive(true);
            Objetos.PrecioSelec = precio;
            /*Objetos.ObjSelec = id;
             MenuSeleccionObj.MuestraSeleccionObj();
             GlobalData.Monedas -= precio;
             GlobalData.EnTienda = true;*/
        }
        else
        {
            comprar.SetActive(false);
            comprarSec.SetActive(false);
        }
        precioTxt.GetComponent<Text>().text = precio.ToString();
        precioSecTxt.GetComponent<Text>().text = precio.ToString();

    }

    public void OcultarCompra()
    {
        comprar.SetActive(false);
        comprarSec.SetActive(false);
    }

    
}
