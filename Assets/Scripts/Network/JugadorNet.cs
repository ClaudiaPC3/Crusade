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
    private GameObject Cierra;
    public GameObject Pelota;
    public GameObject SemGen;
    public int opcion;
    private string tempname;
    [SyncVar]
    public string name;

    // Start is called before the first frame update
    void Start()
    {

        if (!isLocalPlayer)
        {
            return;
        }

        if (isServer)
        {
            CmdSpawnSem();
        }

        
        Cierra = GameObject.Find("Carga");
        opcion = GlobalData.Character;
        tempname = PlayerPrefs.GetString("Sobrenombre");
        CmdObtName(tempname);
        
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
                CmdSpawnPrin();
                break;
        }

       
    }

    [Command]
    void CmdSpawnSem()
    {
        GameObject Gen = Instantiate(SemGen);
        NetworkServer.SpawnWithClientAuthority(Gen, connectionToClient);
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

    [Command]
    void CmdObtName(string n)
    {
        name = n;
        
    }
}
