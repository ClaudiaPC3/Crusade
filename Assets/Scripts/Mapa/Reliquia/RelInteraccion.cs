using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RelInteraccion : MonoBehaviour
{
    public GameObject[] jugadores;
    public GameObject jugadorS, jugadorC;
    public GameObject[] reliquias;
    public GameObject reliquiaS, reliquiaC;
    public int ubicacion;
    private Vector3 nuevo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reliquias = GameObject.FindGameObjectsWithTag("reliquia");
        reliquiaS = reliquias[0];
        reliquiaC = reliquias[1];

        jugadores = GameObject.FindGameObjectsWithTag("jugador");
        jugadorS = jugadores[0];
        jugadorC = jugadores[1];

        if((jugadorS.GetComponent<Transform>().transform.position.x <= (reliquiaS.GetComponent<Transform>().position.x + 30) && jugadorS.GetComponent<Transform>().transform.position.x >= (reliquiaS.GetComponent<Transform>().position.x - 30))&& (jugadorS.GetComponent<Transform>().transform.position.y <= (reliquiaS.GetComponent<Transform>().position.y + 30) && jugadorS.GetComponent<Transform>().transform.position.y >= (reliquiaS.GetComponent<Transform>().position.y - 30)))
        {
            nuevo = new Vector3(70, -432, 0);
            reliquiaS.GetComponent<Transform>().position = nuevo;
        }
        if ((jugadorS.GetComponent<Transform>().transform.position.x <= (reliquiaC.GetComponent<Transform>().position.x + 30) && jugadorS.GetComponent<Transform>().transform.position.x >= (reliquiaC.GetComponent<Transform>().position.x - 30)) && (jugadorS.GetComponent<Transform>().transform.position.y <= (reliquiaC.GetComponent<Transform>().position.y + 30) && jugadorS.GetComponent<Transform>().transform.position.y >= (reliquiaC.GetComponent<Transform>().position.y - 30)))
        {
            nuevo = new Vector3(0, 0, 0);
            reliquiaC.GetComponent<Transform>().position = nuevo;
            GlobalData.Srel=true;
        }
        if ((jugadorC.GetComponent<Transform>().transform.position.x <= (reliquiaC.GetComponent<Transform>().position.x + 30) && jugadorC.GetComponent<Transform>().transform.position.x >= (reliquiaC.GetComponent<Transform>().position.x - 30)) && (jugadorC.GetComponent<Transform>().transform.position.y <= (reliquiaC.GetComponent<Transform>().position.y + 30) && jugadorC.GetComponent<Transform>().transform.position.y >= (reliquiaC.GetComponent<Transform>().position.y - 30)))
        {
            nuevo = new Vector3(1386, -432, 0);
            reliquiaC.GetComponent<Transform>().position = nuevo;
        }
        if ((jugadorC.GetComponent<Transform>().transform.position.x <= (reliquiaS.GetComponent<Transform>().position.x + 30) && jugadorC.GetComponent<Transform>().transform.position.x >= (reliquiaS.GetComponent<Transform>().position.x - 30)) && (jugadorC.GetComponent<Transform>().transform.position.y <= (reliquiaS.GetComponent<Transform>().position.y + 30) && jugadorC.GetComponent<Transform>().transform.position.y >= (reliquiaS.GetComponent<Transform>().position.y - 30)))
        {
            nuevo = new Vector3(0, 0, 0);
            reliquiaS.GetComponent<Transform>().position = nuevo;
            GlobalData.Crel = true;
        }

    }
}
