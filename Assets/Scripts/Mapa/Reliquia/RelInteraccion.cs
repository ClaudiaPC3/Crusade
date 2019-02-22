using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RelInteraccion : MonoBehaviour
{
    public GameObject[] jugadores;
    public GameObject jugadorS, jugadorC;
    public GameObject[] reliquias;
    public GameObject reliquiaS, reliquiaC;
    public int ubicacion;
    private Vector3 nuevo;
    private int distancia=30;
    public Text TxtP1, TxtP2;
    public GameObject reliquia;
    public GameObject flecha;
    public EfectoZoom llamada;


    private bool pasa = false;

    // Start is called before the first frame update
    void Start()
    {
        //Antizoom();
        
        reliquia.SetActive(false);
        flecha.SetActive(false);
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

        if((jugadorS.GetComponent<Transform>().transform.position.x <= (reliquiaS.GetComponent<Transform>().position.x + distancia) && jugadorS.GetComponent<Transform>().transform.position.x >= (reliquiaS.GetComponent<Transform>().position.x - distancia))&& (jugadorS.GetComponent<Transform>().transform.position.y <= (reliquiaS.GetComponent<Transform>().position.y + distancia) && jugadorS.GetComponent<Transform>().transform.position.y >= (reliquiaS.GetComponent<Transform>().position.y - distancia)))
        {
            nuevo = new Vector3(70, -432, 0);
            reliquiaS.GetComponent<Transform>().position = nuevo;
        }
        if ((jugadorS.GetComponent<Transform>().transform.position.x <= (reliquiaC.GetComponent<Transform>().position.x + distancia) && jugadorS.GetComponent<Transform>().transform.position.x >= (reliquiaC.GetComponent<Transform>().position.x - distancia)) && (jugadorS.GetComponent<Transform>().transform.position.y <= (reliquiaC.GetComponent<Transform>().position.y + distancia) && jugadorS.GetComponent<Transform>().transform.position.y >= (reliquiaC.GetComponent<Transform>().position.y - distancia)))
        {

            nuevo = new Vector3(0, 0, 2);
            reliquiaC.GetComponent<Transform>().position = nuevo;
            GlobalData.Srel=true;
            if (NetworkServer.active)
            {
                reliquia.SetActive(true);
            }
            else
            {
               
                Antizoom();
                flecha.SetActive(true);
            }
            
        }
        if ((jugadorC.GetComponent<Transform>().transform.position.x <= (reliquiaC.GetComponent<Transform>().position.x + distancia) && jugadorC.GetComponent<Transform>().transform.position.x >= (reliquiaC.GetComponent<Transform>().position.x - distancia)) && (jugadorC.GetComponent<Transform>().transform.position.y <= (reliquiaC.GetComponent<Transform>().position.y + distancia) && jugadorC.GetComponent<Transform>().transform.position.y >= (reliquiaC.GetComponent<Transform>().position.y - distancia)))
        {
            nuevo = new Vector3(1386, -432, 0);
            reliquiaC.GetComponent<Transform>().position = nuevo;
        }
        if ((jugadorC.GetComponent<Transform>().transform.position.x <= (reliquiaS.GetComponent<Transform>().position.x + distancia) && jugadorC.GetComponent<Transform>().transform.position.x >= (reliquiaS.GetComponent<Transform>().position.x - distancia)) && (jugadorC.GetComponent<Transform>().transform.position.y <= (reliquiaS.GetComponent<Transform>().position.y + distancia) && jugadorC.GetComponent<Transform>().transform.position.y >= (reliquiaS.GetComponent<Transform>().position.y - distancia)))
        {
            nuevo = new Vector3(0, 0, 2);
            reliquiaS.GetComponent<Transform>().position = nuevo;
            GlobalData.Crel = true;
            if (!NetworkServer.active)
            {
                reliquia.SetActive(true);
            }
            else
            {
                flecha.SetActive(true);
                Antizoom();
            }
        }

        if (GlobalData.Srel)
        {
            if((jugadorS.GetComponent<Transform>().transform.position.x <= (100) && jugadorS.GetComponent<Transform>().transform.position.x >= (50)) && (jugadorS.GetComponent<Transform>().transform.position.y <= (-402) && jugadorS.GetComponent<Transform>().transform.position.y >= (-462)))
            {
                nuevo = new Vector3(1386, -432, 0);
                reliquiaC.GetComponent<Transform>().position = nuevo;
                GlobalData.Srel = false;
                GlobalData.Punt1++;
                TxtP1.text = GlobalData.Punt1.ToString();
                if (NetworkServer.active)
                {
                    reliquia.SetActive(false);
                }
                else
                {
                    flecha.SetActive(false);
                }

            }
        }
        if (GlobalData.Crel)
        {
            if ((jugadorC.GetComponent<Transform>().transform.position.x <= (1416) && jugadorC.GetComponent<Transform>().transform.position.x >= (1347)) && (jugadorC.GetComponent<Transform>().transform.position.y <= (-402) && jugadorC.GetComponent<Transform>().transform.position.y >= (-462)))
            {
                nuevo = new Vector3(70, -432, 0);
                reliquiaS.GetComponent<Transform>().position = nuevo;
                GlobalData.Crel = false;
                GlobalData.Punt2++;
                TxtP2.text = GlobalData.Punt2.ToString();
                if (!NetworkServer.active)
                {
                    reliquia.SetActive(false);
                }
                else
                {
                    flecha.SetActive(false);
                }
            }
        }

    }

    public void SueltaServ(int posx,int posy)
    {
        GlobalData.Srel = false;
        //Introducri codigo para soltar reliquia

    }

    public void SueltaClien(int posx,int posy)
    {
        GlobalData.Crel = false;
        //Introducri codigo para soltar reliquia

    }

    public void Antizoom()
    {
        llamada.hacer = true;
    }

}
