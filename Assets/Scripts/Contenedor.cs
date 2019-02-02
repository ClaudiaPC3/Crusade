using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contenedor: MonoBehaviour
{
    public int opcion = 0;
    static Contenedor Instance;
    public Transform mio;
    
    // Start is called before the first frame update
    void Start()
    {
        mio = GetComponent<Transform>();
        mio.position = new Vector3(opcion, 0, 0);

        if(Instance != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    
}
