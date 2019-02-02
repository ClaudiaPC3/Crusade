using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Host : MonoBehaviour
{
    public NetworkManager manager;
    public Toggle checkbox;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkbox.isOn)
        {
            manager.StartHost();
        }
    }
}
