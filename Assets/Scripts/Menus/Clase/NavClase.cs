using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Encargado de administrar las escenas
using UnityEngine.UI;              //Encargado de manejar el UI

public class NavClase : MonoBehaviour
{
    public Button Bot1;
    public Button Bot2;
    public Button Bot3;
    public Button Bot4;
    public GameObject BotSalir;
    public MagoOpc Mago;
    public PrinOpc Prin;
    public HerrOpc Herr;
    public CabOpc Cab;

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
                Prin.CargaEscena("Partida");
            }

            if (seleccion == 2)
            {
                Mago.CargaEscena("Partida");
            }

            if (seleccion == 3)
            {
                Cab.CargaEscena("Partida");
            }

            if (seleccion == 4)
            {
                Herr.CargaEscena("Partida");
            }

            if (seleccion == 5)
            {
                SceneManager.LoadScene("Menu Jugar");
            }
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))      //Obtiene la lectura de la tecla Arriba
        {
            if (seleccion > 1)
            {
                seleccion--;
                Limpia();
            }

        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))      //Obtiene la lectura de la tecla Abajo
        {
            if (seleccion < 5)
            {
                seleccion++;
                Limpia();
            }

        }

        switch (seleccion)
        {
            case 1:
                ColorBlock cf = Bot1.GetComponent<Button>().colors;
                cf.normalColor = Color.grey;
                Bot1.colors = cf;
                break;

            case 2:
                ColorBlock cf1 = Bot2.GetComponent<Button>().colors;
                cf1.normalColor = Color.grey;
                Bot2.colors = cf1;
                break;

            case 3:
                ColorBlock cf2 = Bot3.GetComponent<Button>().colors;
                cf2.normalColor = Color.grey;
                Bot3.colors = cf2;
                break;

            case 4:
                ColorBlock cf3 = Bot4.GetComponent<Button>().colors;
                cf3.normalColor = Color.grey;
                Bot4.colors = cf3;
                break;

            case 5:
                BotSalir.GetComponent<Image>().color = Color.grey;
                break;
        }

    }

    public void Limpia()
    {
        ColorBlock cf = Bot1.GetComponent<Button>().colors;
        cf.normalColor = Color.white;
        Bot1.colors = cf;
        ColorBlock cf1 = Bot2.GetComponent<Button>().colors;
        cf1.normalColor = Color.white;
        Bot2.colors = cf1;
        ColorBlock cf2 = Bot3.GetComponent<Button>().colors;
        cf2.normalColor = Color.white;
        Bot3.colors = cf2;
        ColorBlock cf3 = Bot4.GetComponent<Button>().colors;
        cf3.normalColor = Color.white;
        Bot4.colors = cf3;
        BotSalir.GetComponent<Image>().color = Color.white;
    }
}
