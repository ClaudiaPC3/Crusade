using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Encargado de administrar las escenas
using UnityEngine.UI;              //Encargado de manejar el UI
using UnityEngine.Networking;
public class Pausa : MonoBehaviour
{
    public NetworkManager manager;
    public GameObject MenuPausa;   //Objeto del juego
    public GameObject BotReg;
    public GameObject BotSalir;
    public int estado=1;  //Variable de control para el menu
    int seleccion = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("pausado",0);
        MenuPausa.SetActive(false);   //Al iniciar el menu es invisible
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))      //Obtiene la lectura de la tecla ESC
        {
            Cambio();
        }
        if (estado == 0)
        {
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return))      //Obtiene la lectura de la tecla Espacio
            {
                if (seleccion == 1)
                {
                    Cambio();
                }

                if (seleccion == 2)
                {

                    if (NetworkServer.active && NetworkClient.active)
                    {

                        manager.StopHost();

                    }

                    if (NetworkClient.active)
                    {
                        manager.StopClient();
                    }
                    SceneManager.LoadScene("Menu principal");
                    
                }
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))      //Obtiene la lectura de la tecla Arriba
            {
                BotReg.GetComponent<Image>().color = Color.gray;
                BotSalir.GetComponent<Image>().color = Color.white;
                seleccion = 1;
            }

            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))      //Obtiene la lectura de la tecla Abajo
            {
                BotSalir.GetComponent<Image>().color = Color.gray;
                BotReg.GetComponent<Image>().color = Color.white;
                seleccion = 2;
            }
        }
    }

    public void Cambio()
    {
        if (estado == 1)
        {
            Pausear();
        }

        else if (estado == 0)
        {
            Continuar();
        }      
    }

    public void Pausear()
    {
        MenuPausa.SetActive(true);             //Activa el menu 
        estado = 0;                            //Modifica la variable de control
        PlayerPrefs.SetInt("pausado", 1);
    }

    public void Continuar()
    {
        MenuPausa.SetActive(false);           //Esconde menu      
        estado = 1;                           //Modifica la variable de control       
        PlayerPrefs.SetInt("pausado", 0);
    }
}
