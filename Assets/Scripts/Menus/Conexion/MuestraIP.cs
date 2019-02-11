using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MuestraIP : NetworkBehaviour
{
    public Text ip;
    public GameObject bot;

    // Start is called before the first frame update
    void Start()
    {
        if(NetworkServer.active && NetworkClient.active)
        { 
            ip = GetComponent<Text>();
            ip.text = LocalIPAddress();
        }
        else
        {
            bot.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = "0.0.0.0";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP;

    }
}
