using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Encargado de administrar las escenas
using UnityEngine.UI;              //Encargado de manejar el UI

public class NavJug : MonoBehaviour
{
    public GameObject Bot1;
    public GameObject Bot2;
    public GameObject BotSalir;
    public string ir1,ir2,ir3;

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
                SceneManager.LoadScene(ir1);
            }

            if (seleccion == 2)
            {
                SceneManager.LoadScene(ir2);
            }

            if (seleccion == 3)
            {
                SceneManager.LoadScene(ir3);
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
            if (seleccion < 3)
            {
                seleccion++;
                Limpia();
            }

        }

        switch (seleccion)
        {
            case 1:
                Bot1.GetComponent<Image>().color = Color.grey;
                break;

            case 2:
                Bot2.GetComponent<Image>().color = Color.grey;
                break;

            case 3:
                BotSalir.GetComponent<Image>().color = Color.grey;
                break;
        }

    }

    public void Limpia()
    {
        Bot1.GetComponent<Image>().color = Color.white;
        Bot2.GetComponent<Image>().color = Color.white;
        BotSalir.GetComponent<Image>().color = Color.white;
    }
}

