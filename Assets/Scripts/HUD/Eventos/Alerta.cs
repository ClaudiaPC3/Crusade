using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Alerta : MonoBehaviour
{
    private bool encontrado = false;
    public GameObject[] jugadores;
    public GameObject signoAlerta;
    private float distx = 90,disty=67;
    
    // Start is called before the first frame update
    void Start()
    {
        signoAlerta.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        while (!encontrado)
        {
            jugadores = GameObject.FindGameObjectsWithTag("jugador");
            if (jugadores[1] != null)
            {
                encontrado = true;
            }
        }
        if(((jugadores[0].GetComponent<Transform>().transform.position.x - jugadores[1].GetComponent<Transform>().transform.position.x)<distx && (jugadores[0].GetComponent<Transform>().transform.position.x - jugadores[1].GetComponent<Transform>().transform.position.x) > -distx)   &&   ((jugadores[0].GetComponent<Transform>().transform.position.y - jugadores[1].GetComponent<Transform>().transform.position.y) < disty && (jugadores[0].GetComponent<Transform>().transform.position.y - jugadores[1].GetComponent<Transform>().transform.position.y) > -disty))
        {
            GlobalData.IsWarning = true;
            signoAlerta.SetActive(true);


            if (signoAlerta.GetComponent<Image>().transform.localScale.x<2)
            {
                signoAlerta.GetComponent<Image>().transform.localScale=new Vector3(0.2f+ signoAlerta.GetComponent<Image>().transform.localScale.x, 0.2f + signoAlerta.GetComponent<Image>().transform.localScale.y,1);
            }


        }
        else
        {
            GlobalData.IsWarning = false;
            signoAlerta.GetComponent<Image>().transform.localScale = new Vector3(1,1,1);
            signoAlerta.SetActive(false);
        }
    }
}
