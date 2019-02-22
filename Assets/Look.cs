using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Look : MonoBehaviour
{
    public GameObject ver;
    GameObject[] plays;
    GameObject enem;
    
    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
        plays = GameObject.FindGameObjectsWithTag("jugador");

        if (NetworkServer.active)
        {
            enem = plays[1];
        }
        else
        {
            enem = plays[0];
        }

        transform.up = enem.transform.position - transform.position;
        
    }
}
