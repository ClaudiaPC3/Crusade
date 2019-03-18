using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ControlTiendas : MonoBehaviour
{
    private bool encontrado = false;
    private int[] xT1,xT2,xT3,xT4,yT1,yT2,yT3,yT4; 
    public GameObject[] jugadores;
    public GameObject jugador;
    public ObjetoId comprar,comprarSec;
    public OpcionesAdm MenuTienda,MenuTiendaSec;
    public GameObject PresionaE;
    private float currentTime=0;
    private bool estadoAnim = true;


    // Start is called before the first frame update
    void Start()
    {
        xT1 = new int[2];
        xT2 = new int[2];
        yT1 = new int[2];
        yT2 = new int[2];
        xT3 = new int[2];
        xT4 = new int[2];
        yT3 = new int[2];
        yT4 = new int[2];
        xT1[0] = 658;
        xT1[1] = 770;
        yT1[0] = -42;
        yT1[1] = -154;
        xT2[0] = 658;
        xT2[1] = 770;
        yT2[0] = -686;
        yT2[1] = -798;

        xT3[0] = 28;
        xT3[1] = 168;
        yT3[0] = -364;
        yT3[1] = -504;
        xT4[0] = 1288;
        xT4[1] = 1428;
        yT4[0] = -364;
        yT4[1] = -504;

        PresionaE.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        while (!encontrado)
        {
            jugadores = GameObject.FindGameObjectsWithTag("jugador");
            if (NetworkServer.active)
            {
                jugador = jugadores[0];
            }
            else
            {
                jugador = jugadores[1];
            }
            if (jugadores[1] != null)
            {
                encontrado = true;
            }
        }
        if ((jugador.GetComponent<Transform>().transform.position.x <= (xT1[1]) && jugador.GetComponent<Transform>().transform.position.x >= (xT1[0]) && jugador.GetComponent<Transform>().transform.position.y >= (yT1[1]) && jugador.GetComponent<Transform>().transform.position.y <= (yT1[0]))|| (jugador.GetComponent<Transform>().transform.position.x <= (xT2[1]) && jugador.GetComponent<Transform>().transform.position.x >= (xT2[0]) && jugador.GetComponent<Transform>().transform.position.y >= (yT2[1]) && jugador.GetComponent<Transform>().transform.position.y <= (yT2[0])))
        {  
            currentTime = Time.deltaTime + currentTime;
            if (currentTime >= 0.5f)
            {
                estadoAnim =!estadoAnim;
                PresionaE.SetActive(estadoAnim);
                currentTime = 0.0f;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                MenuTienda.MuestraTiendaPrin();
                comprar.OcultarCompra();
                PresionaE.SetActive(false);
            }
        }
        else
        {
            if((jugador.GetComponent<Transform>().transform.position.x <= (xT3[1]) && jugador.GetComponent<Transform>().transform.position.x >= (xT3[0]) && jugador.GetComponent<Transform>().transform.position.y >= (yT3[1]) && jugador.GetComponent<Transform>().transform.position.y <= (yT3[0])) || (jugador.GetComponent<Transform>().transform.position.x <= (xT4[1]) && jugador.GetComponent<Transform>().transform.position.x >= (xT4[0]) && jugador.GetComponent<Transform>().transform.position.y >= (yT4[1]) && jugador.GetComponent<Transform>().transform.position.y <= (yT4[0])))
            {

            }
            else
            {
                MenuTienda.OcultaTiendaPrin();
                PresionaE.SetActive(false);
                if (GlobalData.EnTienda)
                {
                    MenuTienda.OcultaSeleccionObj();
                    MenuTienda.RegresarMon();
                    GlobalData.EnTienda = false;
                }
            }
            
        }
        if ((jugador.GetComponent<Transform>().transform.position.x <= (xT3[1]) && jugador.GetComponent<Transform>().transform.position.x >= (xT3[0]) && jugador.GetComponent<Transform>().transform.position.y >= (yT3[1]) && jugador.GetComponent<Transform>().transform.position.y <= (yT3[0])) || (jugador.GetComponent<Transform>().transform.position.x <= (xT4[1]) && jugador.GetComponent<Transform>().transform.position.x >= (xT4[0]) && jugador.GetComponent<Transform>().transform.position.y >= (yT4[1]) && jugador.GetComponent<Transform>().transform.position.y <= (yT4[0])))
        {
            currentTime = Time.deltaTime + currentTime;
            if (currentTime >= 0.5f)
            {
                estadoAnim = !estadoAnim;
                PresionaE.SetActive(estadoAnim);
                currentTime = 0.0f;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                PresionaE.SetActive(false);
                MenuTienda.MuestraTiendaSec();
                comprar.OcultarCompra();
            }
        }
        else
        {
            if((jugador.GetComponent<Transform>().transform.position.x <= (xT1[1]) && jugador.GetComponent<Transform>().transform.position.x >= (xT1[0]) && jugador.GetComponent<Transform>().transform.position.y >= (yT1[1]) && jugador.GetComponent<Transform>().transform.position.y <= (yT1[0])) || (jugador.GetComponent<Transform>().transform.position.x <= (xT2[1]) && jugador.GetComponent<Transform>().transform.position.x >= (xT2[0]) && jugador.GetComponent<Transform>().transform.position.y >= (yT2[1]) && jugador.GetComponent<Transform>().transform.position.y <= (yT2[0])))
            {

            }
            else
            {
                MenuTienda.OcultaTiendaSec();
                PresionaE.SetActive(false);
                if (GlobalData.EnTienda)
                {
                    MenuTienda.OcultaSeleccionObj();
                    MenuTienda.RegresarMon();
                    GlobalData.EnTienda = false;
                }
            }
            
        }
    }
}
