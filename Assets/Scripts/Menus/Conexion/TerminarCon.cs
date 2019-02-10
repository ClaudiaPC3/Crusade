using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TerminarCon : MonoBehaviour
{
    public NetworkManager manager;

    void Update()
    {
        if (NetworkServer.active && NetworkClient.active)
        {
            GlobalData.EnCurso = true;
        }
        if (!NetworkServer.active && NetworkClient.active)
        {
            GlobalData.EnCurso = true;
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
