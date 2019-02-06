﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generacion : MonoBehaviour
{
    public GameObject onexone, onextwo, onexthree, onexfour, onexfive;
    public GameObject twoxone, twoxtwo, twoxthree, twoxfour, twoxfive;
    public GameObject threexone, threextwo, threexthree, threexfour, threexfive;
    public GameObject fourxone, fourxtwo, fourxthree, fourxfour, fourxfive;
    public GameObject fivexone, fivextwo, fivexthree, fivexfour, fivexfive;

    private int Xoffset = 168;
    private int Yoffset = -168;

    public struct casilla
    {
        public bool taken;
        public sbyte x, y, id; // x y y NO son sus posiciones, son el tamaño del prefab que esta ocupando esta casilla, Ej 1 y 5, o 3 y 2
        public casilla(sbyte x, sbyte y, sbyte id, bool taken)
        {
            this.x = x;
            this.y = y;
            this.id = id;
            this.taken = taken;
        }
        /*
         Random.seed = (int)System.DateTime.Now.Ticks;            
            noiseValues = new float[10];
            int i = 0;
            while (i < noiseValues.Length)
            {
                do
                {
                    noiseValues[i] = Random.value;
                    noiseValues[i] = noiseValues[i] * 10;
                    prueba = (int)noiseValues[i];

                } while (prueba > 5 || prueba < 0);
                Debug.Log(prueba);
                i++;
            }
         */
    }

    casilla[,] mapa = new casilla [19,8]; //Los indices de el arreglo indica la posicion de la casilla en el cuadrante (1,0)

    // Start is called before the first frame update
    void Start()
    {
        Random.seed = (int)System.DateTime.Now.Ticks; //Provisional
        for(int conty = 0; conty<8; conty++) { 
        for(int contx = 0; contx<19; contx++)
        {
            bool validX = false;
            bool validY = false;
            
            
            if (!mapa[contx, conty].taken)                
            {
                do
                {
                    int TamXval = 0;
                    //Asignacion de x
                    float randx;
                    do
                    {
                        randx = Random.value;
                    } while (randx > 0.6 || randx < 0);
                    randx = randx * 10;
                    mapa[contx, conty].x = (sbyte)randx;                    
                    //validacion
                    TamXval = contx + mapa[contx, conty].x;
                    if(TamXval <= 19)
                    {                        
                        validX = true;
                    }
                    else
                    {
                        validX = false;
                    }
                } while (!validX);
                do
                {
                    int TamYval = 0;
                    //Asignacion de y
                    float randy;
                    do
                    {
                        randy = Random.value;
                    } while (randy > 0.6 || randy < 0);
                    randy = randy * 10;
                    mapa[contx, conty].y = (sbyte)randy;
                    //validacion
                    TamYval = conty + mapa[contx, conty].y;//aqui ira la variable del segundo for
                    if (TamYval <= 8)
                    {
                        validY = true;
                    }
                    else
                    {
                        validY = false;
                    }
                } while (!validY);
                Debug.Log("en " + contx + ","+ conty + " x " + mapa[contx, conty].x + " y " + mapa[contx, conty].y);
                    
                    int taky = 0;
                    do
                    {
                        int tempy = conty + taky;
                        int takx = 0;
                        do
                        {
                            int tempx = contx + takx;
                            mapa[tempx, tempy].taken = true;
                            takx++;
                        } while (takx < mapa[contx, conty].x);
                        taky++;
                    } while (taky < mapa[contx, conty].y);
            }
        }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
