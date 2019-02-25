using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reloj : MonoBehaviour
{
    public Text reloj;
    int segs = 45;
    int mins = 0;
    string segsS;
    string minsS;
    bool pre = true;
    float counter = 0;
    GameObject[] jugadores;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jugadores = GameObject.FindGameObjectsWithTag("jugador");
        if (jugadores.Length==2)
        {
            counter += Time.deltaTime;
            reloj.fontSize = 90;
            if (counter >= 1f && pre == true)
            {
                counter = 0;
                segs--;
                if (segs == 0)
                {
                    pre = false;
                }
            }
            if (counter >= 1f && pre == false)
            {
                counter = 0;
                segs++;
                if (segs > 59)
                {
                    mins++;
                    segs = 0;
                }
            }
            if (segs < 10)
            {
                segsS = "0" + segs;
            }
            else
            {
                segsS = "" + segs;
            }
            if (mins < 10)
            {
                minsS = "0" + mins;
            }
            else
            {
                minsS = "" + mins;
            }
            reloj.text = minsS + ":" + segsS;
        }
        
    }
}
