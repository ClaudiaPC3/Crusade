using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class EnviarIpC : MonoBehaviour
{
    // Start is called before the first frame update
    public NetworkManager manager;
    public Toggle cliente;
    public Text ip;

    public void JoinClient()
    {
        if (cliente.isOn)
        {
            manager.networkAddress = ip.text;
            manager.StartClient();
            
        }
    }

}
