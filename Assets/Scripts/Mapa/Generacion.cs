using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Generacion : NetworkBehaviour
{
    public GameObject onexone, onextwo, onexthree, onexfour, onexfive;
    public GameObject twoxone, twoxtwo, twoxthree, twoxfour, twoxfive;
    public GameObject threexone, threextwo, threexthree, threexfour, threexfive;
    public GameObject fourxone, fourxtwo, fourxthree, fourxfour, fourxfive;
    public GameObject fivexone, fivextwo, fivexthree, fivexfour, fivexfive;
    public GameObject cofre;
    
    private int Xoffset = 168;
    private int Yoffset = -168;

    [SyncVar]
    public int seed;

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
      
    }

    casilla[,] mapa = new casilla [19,8]; //Los indices de el arreglo indica la posicion de la casilla en el cuadrante (1,0)

    // Start is called before the first frame update
    void Start()
    {
       

        if (isServer)
        {
            seed = (int)System.DateTime.Now.Ticks;
        }

        Random.seed = seed; //Generacion de semilla
        int Chests = 0;
        float RandChests = 0;
        do
        {
            RandChests = Random.value;
        } while (RandChests > 0.3 || RandChests < 0.1);
        RandChests = RandChests * 10;
        Chests = (int)RandChests;
        //to do:Algoritmo de cuenta de cofres
        for (int contChe = 0; contChe < Chests; contChe++)
        {
            int Chx = 0;
            int Chy = 0;            
            bool validChGen = false;
            
                float RandChx = 0;
                float RandChy = 0;
                bool Gen = true;
                
                    do
                    {
                        RandChx = Random.value;
                    } while (RandChx > 0.18 || RandChx < 0.01);
                    RandChx = RandChx * 100;
                    Chx = (int)RandChx;
                                                                
                    do
                    {
                        RandChy = Random.value;
                    } while (RandChy > 0.07 || RandChy < 0.01);
                    RandChy = RandChy * 100;
                    Chy = (int)RandChy;

                int Limx = Chx + 2;
                int Limy = Chy + 2;

                for (int contx=Chx-1; contx<Limx; contx++)
                {
                    for (int conty = Chy-1; conty < Limy; conty++)
                    {
                        if(mapa[contx, conty].taken)
                        {
                            Gen = false;
                        }
                    }
                }

                if (Gen)
                {
                    Llenar(cofre, Chx, Chy);
                    mapa[Chx, Chy].taken = true;
                    mapa[Chx - 1, Chy].taken = true;
                    mapa[Chx + 1, Chy].taken = true;
                    mapa[Chx, Chy + 1].taken = true;
                    mapa[Chx, Chy - 1].taken = true;
                }
                
                Debug.Log("x: "+Chx+" y: "+Chy);                
            
        }
        
        for(int conty = 0; conty<8; conty++) { 
        for(int contx = 0; contx<19; contx++)
        {
                if (!mapa[contx, conty].taken)                
            {
                    bool validPref = true;
                    do {
                        validPref = true;
                        bool validX = false;
                        bool validY = false;
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
                            if (TamXval <= 19)
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
                            //validacion 1
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
                        

                        int checky = 0;
                        do
                        {
                            int tempy = conty + checky;
                            int checkx = 0;
                            do
                            {
                                int tempx = contx + checkx;
                                if(mapa[tempx, tempy].taken)
                                {
                                    validPref = false;
                                }
                                checkx++;
                            } while (checkx < mapa[contx, conty].x);
                            checky++;
                        } while (checky < mapa[contx, conty].y);

                    } while (!validPref);
               
                    
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

                    switch (mapa[contx, conty].x)
                    {
                        case 0:
                            break;

                        case 1:
                            switch(mapa[contx, conty].y)
                            {
                                case 0:
                                    break;

                                case 1:
                                    Llenar(onexone, contx, conty); 
                                    break;

                                case 2:
                                    Llenar(onextwo, contx, conty);
                                    break;

                                case 3:
                                    Llenar(onexthree, contx, conty);
                                    break;

                                case 4:
                                    Llenar(onexfour, contx, conty);
                                    break;

                                case 5:
                                    Llenar(onexfive, contx, conty);
                                    break;
                            }
                            break;

                        case 2:
                            switch (mapa[contx, conty].y)
                            {
                                case 0:
                                    break;

                                case 1:
                                    Llenar(twoxone, contx, conty);
                                    break;

                                case 2:
                                    Llenar(twoxtwo, contx, conty);
                                    break;

                                case 3:
                                    Llenar(twoxthree, contx, conty);
                                    break;

                                case 4:
                                    Llenar(twoxfour, contx, conty);
                                    break;

                                case 5:
                                    Llenar(twoxfive, contx, conty);
                                    break;
                            }
                            break;
                            

                        case 3:
                            switch (mapa[contx, conty].y)
                            {
                                case 0:
                                    break;

                                case 1:
                                    Llenar(threexone, contx, conty);
                                    break;

                                case 2:
                                    Llenar(threextwo, contx, conty);
                                    break;

                                case 3:
                                    Llenar(threexthree, contx, conty);
                                    break;

                                case 4:
                                    Llenar(threexfour, contx, conty);
                                    break;

                                case 5:
                                    Llenar(threexfive, contx, conty);
                                    break;
                            }
                            break;

                        case 4:
                            switch (mapa[contx, conty].y)
                            {
                                case 0:
                                    break;

                                case 1:
                                    Llenar(fourxone, contx, conty);
                                    break;

                                case 2:
                                    Llenar(fourxtwo, contx, conty);
                                    break;

                                case 3:
                                    Llenar(fourxthree, contx, conty);
                                    break;

                                case 4:
                                    Llenar(fourxfour, contx, conty);
                                    break;

                                case 5:
                                    Llenar(fourxfive, contx, conty);
                                    break;
                            }
                            break;

                        case 5:
                            switch (mapa[contx, conty].y)
                            {
                                case 0:
                                    break;

                                case 1:
                                    Llenar(fivexone, contx, conty);
                                    break;

                                case 2:
                                    Llenar(fivextwo, contx, conty);
                                    break;

                                case 3:
                                    Llenar(fivexthree, contx, conty);
                                    break;

                                case 4:
                                    Llenar(fivexfour, contx, conty);
                                    break;

                                case 5:
                                    Llenar(fivexfive, contx, conty);
                                    break;
                            }
                            break;
                    }
            }
        }
        }
        /*GameObject Inst;
        Vector3 newScale;
        Inst = Instantiate(cofre, new Vector3((Xoffset + (5 * 28)), (Yoffset - (5 * 28)), 0), Quaternion.identity);
        Inst = Instantiate(cofre, new Vector3((1288 - (5 * 28)), (Yoffset - (5 * 28)), 0), Quaternion.identity);
        newScale = Inst.transform.localScale;
        newScale.x *= -1;
        Inst.transform.localScale = newScale;
        Inst = Instantiate(cofre, new Vector3((Xoffset + (5 * 28)), (-700 + (5 * 28)), 0), Quaternion.identity);
        newScale = Inst.transform.localScale;
        newScale.y *= -1;
        Inst.transform.localScale = newScale;
        Inst = Instantiate(cofre, new Vector3((1288 - (5 * 28)), (-700 + (5 * 28)), 0), Quaternion.identity);
        newScale = Inst.transform.localScale;
        newScale.x *= -1;
        newScale.y *= -1;
        Inst.transform.localScale = newScale;*/
    }


    public void Llenar(GameObject objeto,int contx,int conty)
    {
        GameObject Inst;
        Vector3 newScale;
        Inst = Instantiate(objeto, new Vector3((Xoffset + (contx * 28)), (Yoffset - (conty * 28)), 0), Quaternion.identity);
        if (objeto == cofre)
        {
            contx += 1;
        }
        Inst = Instantiate(objeto, new Vector3((1288 - (contx * 28)), (Yoffset - (conty * 28)), 0), Quaternion.identity);
        if (objeto != cofre)
        {
            newScale = Inst.transform.localScale;
            newScale.x *= -1;
            Inst.transform.localScale = newScale;
        }
        if (objeto == cofre)
        {
            contx -= 1;
            conty += 1;
        }
        Inst = Instantiate(objeto, new Vector3((Xoffset + (contx * 28)), (-700 + (conty * 28)), 0), Quaternion.identity);
        if (objeto != cofre)
        {
            newScale = Inst.transform.localScale;
            newScale.y *= -1;
            Inst.transform.localScale = newScale;
        }
        if (objeto == cofre)
        {
            contx += 1;
        }
        Inst = Instantiate(objeto, new Vector3((1288 - (contx * 28)), (-700 + (conty * 28)), 0), Quaternion.identity);
        if (objeto != cofre)
        { 
            newScale = Inst.transform.localScale;
            newScale.y *= -1;
            newScale.x *= -1;
            Inst.transform.localScale = newScale;
        }
    }
   
}
