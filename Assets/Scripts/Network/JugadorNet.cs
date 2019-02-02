using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class JugadorNet : NetworkBehaviour
{

    public GameObject Mago;
    public GameObject Herrero;
    public GameObject Princesa;
    public GameObject Caballero;
    public GameObject Cierra;
    public GameObject Pelota;
    public int opcion;

    // Start is called before the first frame update
    void Start()
    {

        if (!isLocalPlayer)
        {
            return;
        }

        
        Cierra = GameObject.Find("Carga");
        opcion = GlobalData.Character;
        //lista de condiciones para ver que personaje es
        

        switch (opcion)
        {
            case 1:
                CmdSpawnPrin();
                break;

            case 2:
                CmdSpawnMago();
                break;

            case 3:
                CmdSpawnCaballero();
                break;

            case 4:
                CmdSpawnHerrero();
                break;

            default:
                break;
        }

       
    }


    // Update is called once per frame
    void Update()
    {

    }

    [Command]
    void CmdSpawnMago(){
        GameObject jugador = Instantiate(Mago);
        GameObject pel = Instantiate(Pelota);
        NetworkServer.SpawnWithClientAuthority(jugador, connectionToClient);
        NetworkServer.Spawn(pel);
    }

    [Command]
    void CmdSpawnHerrero()
    {
        GameObject jugador = Instantiate(Herrero);

        NetworkServer.SpawnWithClientAuthority(jugador, connectionToClient);
    }

    [Command]
    void CmdSpawnPrin()
    {
        GameObject jugador = Instantiate(Princesa);

        NetworkServer.SpawnWithClientAuthority(jugador, connectionToClient);
    }

    [Command]
    void CmdSpawnCaballero()
    {
        GameObject jugador = Instantiate(Caballero);

        NetworkServer.SpawnWithClientAuthority(jugador, connectionToClient);
    }
}
