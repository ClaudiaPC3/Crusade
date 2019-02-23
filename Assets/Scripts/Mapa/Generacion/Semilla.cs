using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/**
 * La clase semilla es usada para que el servidor 
 * obtenga la semilla que se usara para generar al
 * mapa.
 **/

public class Semilla : NetworkBehaviour
{
    [SyncVar]
    public int seed;
    // Start is called before the first frame update
    void Start()
    {
        if (isServer)
        {
            seed = (int)System.DateTime.Now.Ticks; //La semilla se saca del reloj del sistema
        }
    }

   
}
