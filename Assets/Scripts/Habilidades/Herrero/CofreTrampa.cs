using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CofreTrampa : NetworkBehaviour
{
    public int idCast = 0;
    public Animator anim;
    public GameObject personaje1;
    public GameObject MenuCofre;
    private Transform posicion;
    private bool proceso = true;
    private bool activo = true;
    private float currentTime = 0.0f;
    public GameObject[] jugadores;
    public GameObject[] jugadoresNet;
    public GameObject jugadorNetC;
    public GameObject jugadorS;
    public GameObject jugadorC;
    public GameObject jugadorCofre;
    public GameObject me;

    public int estado = 1;

    // Start is called before the first frame update
    void Start()
    {
        jugadores = GameObject.FindGameObjectsWithTag("jugador");
        if (idCast == 1)
        {
            jugadorCofre = jugadores[0];
        }
        else
        {
            jugadorCofre = jugadores[1];
        }
        anim.SetFloat("Estado", estado);
        posicion = GetComponent<Transform>();
        MenuCofre = GameObject.FindWithTag("Cofre");

        //proceso = GlobalData.EnCurso;////////////////////////////////////////////////

    }

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
            anim.SetFloat("Estado", estado);
            if (personaje1 == null)
            {
                personaje1 = GameObject.Find("Main Camera");
            }

            if (proceso)
            {
                //cambiar
                if (NetworkServer.connections.Count == 2)
                {
                    jugadores = GameObject.FindGameObjectsWithTag("jugador");
                    jugadoresNet = GameObject.FindGameObjectsWithTag("Autho");
                    jugadorNetC = jugadoresNet[1];
                    jugadorS = jugadores[0];
                    jugadorC = jugadores[1];
                }

                if ((((jugadorCofre.GetComponent<Transform>().transform.position.x <= (posicion.position.x + 44) && jugadorCofre.GetComponent<Transform>().transform.position.x >= (posicion.position.x - 16)) && (jugadorCofre.GetComponent<Transform>().transform.position.y <= (posicion.position.y + 16) && jugadorCofre.GetComponent<Transform>().transform.position.y >= (posicion.position.y - 42)))) && activo)
                {
                    estado = 2;
                    if (Input.GetKeyUp(KeyCode.E))
                    {
                        GlobalData.EnCofre = true;
                        estado = 3;
                        activo = false;
                    }


                }
                else
                {
                    if (activo)
                    {
                        estado = 1;
                    }
                }
                if (((jugadorCofre.GetComponent<Transform>().transform.position.x <= (posicion.position.x + 44) && jugadorCofre.GetComponent<Transform>().transform.position.x >= (posicion.position.x - 16)) && (jugadorCofre.GetComponent<Transform>().transform.position.y <= (posicion.position.y + 16) && jugadorCofre.GetComponent<Transform>().transform.position.y >= (posicion.position.y - 42))) && activo)
                {
                    estado = 2;
                    bool isE = jugadorNetC.GetComponent<JugadorNet>().isE;

                    if (isE)
                    {      //posiblemente el servidor esta entrando aqui                                       
                        estado = 3;
                        activo = false;
                    }
                }
                /*else
                {
                    if (activo)
                    {
                        estado = 1;
                    }
                }*/
                if (!activo)
                {
                    currentTime = Time.deltaTime + currentTime;
                    if (currentTime >= 4.0f)
                    {
                        currentTime = 0.0f;
                        activo = true;
                        estado = 1;
                        GlobalData.EnCofre = false;
                        Destroy(me);
                    }
                }
            }
        }
        else
        {
            if (personaje1 == null)
            {
                personaje1 = GameObject.Find("Main Camera");
            }

            if (proceso)
            {
                //cambiar
                jugadores = GameObject.FindGameObjectsWithTag("jugador");
                jugadoresNet = GameObject.FindGameObjectsWithTag("Autho");
                jugadorNetC = jugadoresNet[0];
                jugadorS = jugadores[0];
                jugadorC = jugadores[1];


                if ((((jugadorCofre.GetComponent<Transform>().transform.position.x <= (posicion.position.x + 44) && jugadorCofre.GetComponent<Transform>().transform.position.x >= (posicion.position.x - 16)) && (jugadorCofre.GetComponent<Transform>().transform.position.y <= (posicion.position.y + 16) && jugadorCofre.GetComponent<Transform>().transform.position.y >= (posicion.position.y - 42))) || (jugadorCofre.GetComponent<Transform>().transform.position.x <= (posicion.position.x + 44) && jugadorCofre.GetComponent<Transform>().transform.position.x >= (posicion.position.x - 16)) && (jugadorCofre.GetComponent<Transform>().transform.position.y <= (posicion.position.y + 16) && jugadorCofre.GetComponent<Transform>().transform.position.y >= (posicion.position.y - 42))) && activo)
                {
                    if (Input.GetKeyUp(KeyCode.E))
                    {
                        GlobalData.EnCofre = true;
                        activo = false;
                    }

                    bool isE = jugadorNetC.GetComponent<JugadorNet>().isE;

                    if (isE)
                    {
                        activo = false;
                    }

                }

                if (!activo)
                {
                    currentTime = Time.deltaTime + currentTime;
                    if (currentTime >= 4.0f)
                    {
                        GlobalData.EnCofre = false;
                        currentTime = 0.0f;
                        activo = true;
                        Destroy(me);
                    }
                }


            }
        }




    }

}
