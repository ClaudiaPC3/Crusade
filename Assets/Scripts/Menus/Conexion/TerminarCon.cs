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
        if (manager.IsClientConnected())
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
