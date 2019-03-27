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
    public GameObject gancho;
    public GameObject tunel;
    public GameObject cemento;
    public GameObject cofreTrampa;
    public GameObject tela;
    public GameObject paredEscapeHorizontal;
    public GameObject paredEscapeVertical;
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

    



    //Se envia las pulsaciones a la tecla E a todos los clientes
    [Command]
    public void CmdisE(bool n)
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
        GameObject chiclecmd = Instantiate(chicle, posCmd, Quaternion.identity);
        
        NetworkServer.SpawnWithClientAuthority(chiclecmd, connectionToClient);
  
        RpcSetIdCh(chiclecmd, idcmd);

    }

    [Command]
    public void CmdSpawnGancho(Vector3 posCmd, int idcmd)
    {
        GameObject ganchocmd = Instantiate(gancho, posCmd, Quaternion.identity);

        NetworkServer.SpawnWithClientAuthority(ganchocmd, connectionToClient);
        
        //RpcSetIdCh(chiclecmd, idcmd);

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
    public void CmdSpawnTunel(Vector3 posCmd, int idcmd)
    {
        Debug.Log(idcmd);

        GameObject tunelcmd = Instantiate(tunel, posCmd, Quaternion.identity);
        NetworkServer.SpawnWithClientAuthority(tunelcmd, connectionToClient);
        RpcSetIdTunel(tunelcmd, idcmd);

    }

    [ClientRpc]
    public void RpcSetIdTunel(GameObject Target, int id)
    {
        Target.GetComponent<Tunel>().idCast = id;
    }

    [Command]
    public void CmdSpawnCemento(Vector3 posCmd, int idcmd)
    {
        Debug.Log(idcmd);

        GameObject cementocmd = Instantiate(cemento, posCmd, Quaternion.identity);
        NetworkServer.SpawnWithClientAuthority(cementocmd, connectionToClient);

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
    public void CmdEnem(float changex, float changey, GameObject enem)
    {
        RpcEnem(changex, changey, enem);
    }

    [ClientRpc]
    public void RpcEnem(float changex, float changey, GameObject enem)
    {
        enem.transform.position = new Vector3(enem.transform.position.x + changex, enem.transform.position.y + changey, 0);
    }

    [Command]
    public void CmdStun(bool stun, GameObject enem)
    {
        RpcStun(stun, enem);
    }

    [ClientRpc]
    public void RpcStun(bool stun, GameObject enem)
    {
        enem.GetComponent<Movimiento>().isInStun = stun;
    }

    [Command]
    public void CmdSpawnTela(Vector3 posCmd, int idcmd)
    {
        Debug.Log(idcmd);

        GameObject telacmd = Instantiate(tela, posCmd, Quaternion.identity);
        NetworkServer.SpawnWithClientAuthority(telacmd, connectionToClient);

    }

    [Command]
    public void CmdSpawnEscapeHorizontal(Vector3 posCmd, int idcmd)
    {
        Debug.Log(idcmd);

        GameObject ParedHorizontalcmd = Instantiate(paredEscapeHorizontal, posCmd, Quaternion.identity);
        NetworkServer.SpawnWithClientAuthority(ParedHorizontalcmd, connectionToClient);

    }

    [Command]
    public void CmdSpawnEscapeVertical(Vector3 posCmd, int idcmd)
    {
        Debug.Log(idcmd);

        GameObject ParedVerticalcmd = Instantiate(paredEscapeVertical, posCmd, Quaternion.identity);
        NetworkServer.SpawnWithClientAuthority(ParedVerticalcmd, connectionToClient);

    }
}
