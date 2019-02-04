using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Encargado de administrar las escenas
using UnityEngine.UI;              //Encargado de manejar el UI

public class NavPrinc : MonoBehaviour
{
    public GameObject BotJug;
    public GameObject BotPer;
    public GameObject BotHis;
    public GameObject BotCon;
    public GameObject BotSalir;

    int seleccion = 0;

    // Start is called before the first frame update
    void Start()
    {

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
                Application.Quit();
            }
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))      //Obtiene la lectura de la tecla Arriba
        {
            if (seleccion > 1)
            {
                seleccion--;
                Limpia();
            }

        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))      //Obtiene la lectura de la tecla Abajo
        {
            if (seleccion != 5)
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
        }
        
    }

    public void Limpia()
    {
        BotJug.GetComponent<Image>().color = Color.white;
        BotPer.GetComponent<Image>().color = Color.white;
        BotHis.GetComponent<Image>().color = Color.white;
        BotCon.GetComponent<Image>().color = Color.white;
        BotSalir.GetComponent<Image>().color = Color.white;
    }
}

