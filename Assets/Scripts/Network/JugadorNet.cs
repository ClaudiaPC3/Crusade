using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/**
 * La clase JugadorNet es el controlador del 
 * jugador en la red. Esto se refiere, no a 
 * el personaje, sino al objeto que ejecuta los
 * procesos que se requieren para realizar la
 * conexion.
 **/
public class JugadorNet : NetworkBehaviour
{
    public GameObject Mago;
    public GameObject Herrero;
    public GameObject Princesa;
    public GameObject Caballero;
    private GameObject Cierra;
    public GameObject Pelota;
    public GameObject SemGen;
    public GameObject chicle;
    public GameObject cofreTrampa;
    public GameObject[] jgsNet;
    public int id = 0;
    

    public int opcion;
    private string tempname;
    //name es la variable sincronizada en red para enviar tu username al enemigo
    [SyncVar]
    public string name;
    //isE es la variable sincronizada en red para enviar tus pulsaciones en la tecla E
    [SyncVar]
    public bool isE;

    // Start is called before the first frame update
    void Start()
    {
        jgsNet = GameObject.FindGameObjectsWithTag("Autho");
        id = jgsNet.Length;

        //Si no es jugador local, se sale de este metodo
        if (!isLocalPlayer)
        {
            return;
        }

        
        Debug.Log(id);
        GlobalData.ID = id;
        Debug.Log(GlobalData.ID);

        //Si es servidor se llama el comando para enviar la semilla al cliente
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

    //En Update se envia lo necesario para que la variable isE funcione
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            CmdisE(true);
        }
        else
        {
            CmdisE(false);
        }
    }



    //Se envia las pulsaciones a la tecla E a todos los clientes
    [Command]
    void CmdisE(bool n)
    {
        isE = n;
   
    }
    //Se hace spawn de el generador de semillas, para despues sincronizar la semilla
    [Command]
    void CmdSpawnSem()
    {
        GameObject Gen = Instantiate(SemGen);
        NetworkServer.SpawnWithClientAuthority(Gen, connectionToClient);
    }
    //Se hace spawn del mago
    [Command]
    void CmdSpawnMago(){
        GameObject jugador = Instantiate(Mago);
        GameObject pel = Instantiate(Pelota);
        NetworkServer.SpawnWithClientAuthority(jugador, connectionToClient);
        NetworkServer.Spawn(pel);
    }
    //Se hace spawn del herrero
    [Command]
    void CmdSpawnHerrero()
    {
        GameObject jugador = Instantiate(Herrero);

        NetworkServer.SpawnWithClientAuthority(jugador, connectionToClient);
    }
    //Se hace spawn de la princesa
    [Command]
    void CmdSpawnPrin()
    {
        GameObject jugador = Instantiate(Princesa);

        NetworkServer.SpawnWithClientAuthority(jugador, connectionToClient);
    }
    //Se hace spawn del caballero
    [Command]
    void CmdSpawnCaballero()
    {
        GameObject jugador = Instantiate(Caballero);

        NetworkServer.SpawnWithClientAuthority(jugador, connectionToClient);
    }
    //Se envia a todos los clientes el username
    [Command]
    void CmdObtName(string n)
    {
        name = n;
        
    }

    [Command]
    public void CmdSpawnChicle(Vector3 posCmd, int idcmd)
    {
        Debug.Log(idcmd);

        GameObject chiclecmd = Instantiate(chicle, posCmd, Quaternion.identity);
        
        //Debug.Log(chiclecmd.GetComponent<Chicle>().idCast);
        NetworkServer.SpawnWithClientAuthority(chiclecmd, connectionToClient);
        //chiclecmd.GetComponent<Chicle>().idCast = idcmd;
        RpcSetIdCh(chiclecmd, idcmd);

    }

    [ClientRpc]
    public void RpcSetIdCh(GameObject Target, int id)
    {
        Target.GetComponent<Chicle>().idCast = id;
    }


    [Command]
    public void CmdSpawnCofreTrampa(Vector3 posCmd, int idcmd)
    {
        Debug.Log(idcmd);

        GameObject cofreTrampacmd = Instantiate(cofreTrampa, posCmd, Quaternion.identity);
        NetworkServer.SpawnWithClientAuthority(cofreTrampacmd, connectionToClient);
        RpcSetIdCof(cofreTrampacmd, idcmd);

    }

    [ClientRpc]
    public void RpcSetIdCof(GameObject Target, int id)
    {
        Target.GetComponent<CofreTrampa>().idCast = id;
    }

    [Command]
    public void CmdEscalera(GameObject escal , bool val)
    {
        RpcEscalera(escal, val);
    }

    [ClientRpc]
    public void RpcEscalera(GameObject escal, bool val)
    {
        escal.GetComponent<Escalera>().active = val;
    }

    [Command]
    public void CmdEnem(float changex, float changey)
    {

    }

    [ClientRpc]
    public void RpcEnemX(float changex, float changey)
    {

    }
}
