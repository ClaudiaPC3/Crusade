using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Semilla : NetworkBehaviour
{
    [SyncVar]
    public int seed;
    // Start is called before the first frame update
    void Start()
    {
        if (isServer)
        {
            seed = (int)System.DateTime.Now.Ticks;
        }
    }

   
}
