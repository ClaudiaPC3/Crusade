using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Host : MonoBehaviour
{
    public NetworkManager manager;
    public Toggle checkbox;
    private bool isCreated = false;
    ///
    private float[] noiseValues;
    private int prueba;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkbox.isOn && !isCreated)
        {
            manager.StartHost();
            isCreated = true;
            ///

            Random.seed = (int)System.DateTime.Now.Ticks;            
            noiseValues = new float[10];
            int i = 0;
            while (i < noiseValues.Length)
            {
                do
                {
                    noiseValues[i] = Random.value;
                    noiseValues[i] = noiseValues[i] * 10;
                    prueba = (int)noiseValues[i];

                } while (prueba > 5 || prueba < 0);
                Debug.Log(prueba);
                i++;
            }
        }
        
        if(!checkbox.isOn && isCreated)
        {
            manager.StopHost();
            isCreated = false;
        }
    }
}
