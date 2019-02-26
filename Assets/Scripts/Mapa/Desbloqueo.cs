using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

/**
 *La clase desbloqueo es usada para tener control sobre las barreras
 * que bloquean las puertas de la base.
 * Las barreras son destruidas cuando ambos jugadores se conectan al servidor.
 **/


public class Desbloqueo : NetworkBehaviour
{

    public NetworkManager manager;
    public GameObject barrera;
    private int clientes = 0;
    int size;
    public GameObject[] jugadores;

    // Update is called once per frame
    /**
     * En el update se cuentan las conexiones al servidor
     * si es igual a 2, se llama al comando para destruir
     * la barrera
     **/
    void Update()
    {

        jugadores = GameObject.FindGameObjectsWithTag("jugador");
        if (jugadores.Length == 2)
        {
            if (NetworkServer.active)
            {
                CmdDestruirBarreras(barrera);
            }
            

        }
    }
    /**
     * El comando es ejecutado en el servidor
     * aqui se destruyen las barreras
     **/
    [Command]
    void CmdDestruirBarreras(GameObject barreracmd)
    {
        NetworkServer.Destroy(barreracmd);
        

    }

    
}
