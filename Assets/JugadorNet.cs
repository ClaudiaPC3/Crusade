using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JugadorNet : NetworkBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        //lista de condiciones para ver que personaje es

        CmdSpawnMago();
    }

    public GameObject Personaje;
    // Update is called once per frame
    void Update()
    {

    }

    [Command]
    void CmdSpawnMago(){
        GameObject jugador = Instantiate(Personaje);

        NetworkServer.SpawnWithClientAuthority(jugador, connectionToClient);
    }


}
