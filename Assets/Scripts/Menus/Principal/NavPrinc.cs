using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Encargado de administrar las escenas
using UnityEngine.UI;              //Encargado de manejar el UI

public class NavPrinc : MonoBehaviour
{
    int menor = 1;
    int mayor = 5;
    public GameObject BotJug;
    public GameObject BotPer;
    public GameObject BotHis;
    public GameObject BotCon;
    public GameObject BotSalir;
    public GameObject BotReg;
    public GameObject BotConf;
    public GameObject Pregunta;

    int seleccion = 0;

    // Start is called before the first frame update
    void Start()
    {
        Pregunta.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return))      //Obtiene la lectura de la tecla Espacio
        {
            if (seleccion == 1)
            {
                SceneManager.LoadScene("Menu Jugar");
            }

            if (seleccion == 2)
            {
                SceneManager.LoadScene("Menu Perfil");
            }

            if (seleccion == 3)
            {
                SceneManager.LoadScene("Menu Historial");
            }

            if (seleccion == 4)
            {
                SceneManager.LoadScene("Menu Controles");
            }

            if (seleccion == 5)
            {
                Pregunta.SetActive(true);
                seleccion++;
                mayor = 8;
                menor = 7;
            }

            if(seleccion == 7)
            {
                Pregunta.SetActive(false);
                Limpia();
                BotSalir.GetComponent<Image>().color = Color.grey;
                seleccion =5;
                mayor = 5;
                menor = 1;
            }

            if (seleccion == 8)
            {
                Application.Quit();
            }
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))      //Obtiene la lectura de la tecla Arriba
        {
            if (seleccion > menor)
            {
                seleccion--;
                Limpia();
            }

        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))      //Obtiene la lectura de la tecla Abajo
        {
            if (seleccion < mayor)
            {
                seleccion++;
                Limpia();
            }

        }

        switch (seleccion)
        {
            case 1:
                BotJug.GetComponent<Image>().color = Color.grey;
                break;

            case 2:
                BotPer.GetComponent<Image>().color = Color.grey;
                break;

            case 3:
                BotHis.GetComponent<Image>().color = Color.grey;
                break;

            case 4:
                BotCon.GetComponent<Image>().color = Color.grey;
                break;

            case 5:
                BotSalir.GetComponent<Image>().color = Color.grey;
                break;

            case 7:
                BotReg.GetComponent<Image>().color = Color.grey;
                break;

            case 8:
                BotConf.GetComponent<Image>().color = Color.grey;
                break;
        }
        
    }

    public void Limpia()
    {
        BotJug.GetComponent<Image>().color = Color.white;
        BotPer.GetComponent<Image>().color = Color.white;
        BotHis.GetComponent<Image>().color = Color.white;
        BotCon.GetComponent<Image>().color = Color.white;
        BotSalir.GetComponent<Image>().color = Color.white;
        BotReg.GetComponent<Image>().color = Color.white;
        BotConf.GetComponent<Image>().color = Color.white;
    }

    public void Muestra()
    {
        Pregunta.SetActive(true);
    }

    public void Oculta()
    {
        Pregunta.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }
}

