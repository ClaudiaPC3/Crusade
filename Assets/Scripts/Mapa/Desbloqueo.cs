using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Desbloqueo : NetworkBehaviour
{

    public NetworkManager manager;
    public GameObject barrera;
    private int clientes = 0;

    // Update is called once per frame
    void Update()
    {
        if (NetworkServer.active)
        {
            clientes = NetworkServer.connections.Count;
           
        }

        if(clientes == 2)
        {
            GlobalData.EnCurso = true;
            CmdDestruirBarreras(barrera);
            
        }
    }

    [Command]
    void CmdDestruirBarreras(GameObject barreracmd)
    {
        NetworkServer.Destroy(barreracmd);
    }
}
