using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generacion : MonoBehaviour
{
    public GameObject onexone, onextwo, onexthree, onexfour, onexfive;
    public GameObject twoxone, twoxtwo, twoxthree, twoxfour, twoxfive;
    public GameObject threexone, threextwo, threexthree, threexfour, threexfive;
    public GameObject fourxone, fourxtwo, fourxthree, fourxfour, fourxfive;
    public GameObject fivexone, fivextwo, fivexthree, fivexfour, fivexfive;

    private int Xoffset;
    private int Yoffset;

    public struct casilla
    {
        public bool taken;
        public sbyte x, y, id; // x y y NO son sus posiciones, son el tamaño del prefab que esta ocupando esta casilla
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
        Random.seed = 1; //Provisional
        for(int i = 0; i<19; i++)
        {
            if (!mapa[i, 0].taken)
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
