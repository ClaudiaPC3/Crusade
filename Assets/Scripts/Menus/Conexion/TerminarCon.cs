using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TerminarCon : MonoBehaviour
{
    public NetworkManager manager;

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
    }
}
