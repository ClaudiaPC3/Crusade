using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoId : MonoBehaviour
{
    public int id;
    public int precio;
   

    public OpcionesAdm MenuSeleccionObj;
    public GameObject comprar;
    public GameObject precioTxt;

    void Start()
    {
        comprar = GameObject.FindGameObjectWithTag("Comprar");
        precioTxt = GameObject.FindGameObjectWithTag("Precio");
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
            Objetos.PrecioSelec = precio;
            /*Objetos.ObjSelec = id;
             MenuSeleccionObj.MuestraSeleccionObj();
             GlobalData.Monedas -= precio;
             GlobalData.EnTienda = true;*/
        }
        else
        {
            comprar.SetActive(false);
        }
        precioTxt.GetComponent<Text>().text = precio.ToString();

    }

    public void OcultarCompra()
    {
        comprar.SetActive(false);
    }

    
}
