using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoId : MonoBehaviour
{
    public int id;
    public int precio;

    public OpcionesAdm MenuSeleccionObj;

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
            MenuSeleccionObj.MuestraSeleccionObj();
            GlobalData.Monedas -= precio;
        }

    }
}
