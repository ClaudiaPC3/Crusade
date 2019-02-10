using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TerminarCon : NetworkBehaviour
{
    public NetworkManager manager;
    private int clientes = 0;

    void Update()
    {
        if (NetworkServer.active)
        {
            clientes = NetworkServer.connections.Count;

        }
        if ((clientes==2)||(manager.IsClientConnected()&& !NetworkServer.active))
        {

            GlobalData.EnCurso = true;

        }
        else
        {
            GlobalData.EnCurso = false;
        }    
  
    }
     
    public void Terminar()
    {
        if (NetworkServer.active && NetworkClient.active)
        {
            
           manager.StopHost();
            
        }

        if (NetworkClient.active)
        {
            manager.StopClient();
        }
        GlobalData.EnCurso = false;
    }

}
