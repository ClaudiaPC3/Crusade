﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Cast : NetworkBehaviour
{
    public Movimiento movani;
    public GameObject bar, tramp;
    public GameObject[] jugadores;
    public GameObject[] nets;
    private GameObject jugador, enem;
    private Barra barra;
    private JugadorNet jgnt;
    public RectTransform trans1;
    public RectTransform trans2;
    public RectTransform trans3;
    public RectTransform trans4;
    private float cou1 = 0, cou2 = 0, cou3 = 0, cou4 = 0, countc = 0, countg = 0, countst = 0, countatr = 0, countmart = 0;
    private int seg1 = 0, seg2 = 0, seg3 = 0, seg4 = 0;
    private bool cool1 = false, cool2 = false, cool3 = false, cool4 = false, check = true, activeChMo = false, activeCant = false, activeStun = false, activeAtrac = false, activeMart = false;
    public Vector3 pos, stun;
    public AnimatorTimer controlAnim;
    private bool firstAtrac = true,firstMart=true, firstCantar = true, firstGritar = true;

    // Start is called before the first frame update
    void Start()
    {
        barra = bar.GetComponent<Barra>();
        controlAnim = GetComponent<AnimatorTimer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (check)
        {
            jugadores = GameObject.FindGameObjectsWithTag("jugador");
            nets = GameObject.FindGameObjectsWithTag("Autho");

            if (jugadores.Length == 2)
            {
                if (NetworkServer.active)
                {
                    jugador = jugadores[0];
                    enem = jugadores[1];
                    pos = jugadores[0].transform.position;
                    movani = jugadores[0].GetComponent<Movimiento>();
                    jgnt = nets[0].GetComponent<JugadorNet>();


                }
                else
                {
                    jugador = jugadores[1];
                    enem = jugadores[0];
                    pos = jugadores[1].transform.position;
                    movani = jugadores[1].GetComponent<Movimiento>();
                    jgnt = nets[1].GetComponent<JugadorNet>();

                }
                check = true;
            }
        }

        if (GlobalData.EnPausa == false && GlobalData.EnCofre == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (GlobalData.Energ >= Objetos.Inv1ener && !cool1 && Objetos.Inv1 != -1)
                {
                    GlobalData.Energ -= Objetos.Inv1ener;
                    barra.BarUpd();
                    HabCast(Objetos.Inv1);
                    cool1 = true;
                    trans1.localScale = new Vector3(1, 1, 1);
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && !cool2 && Objetos.Inv2 != -1)
            {
                if (GlobalData.Energ >= Objetos.Inv2ener)
                {
                    GlobalData.Energ -= Objetos.Inv2ener;
                    barra.BarUpd();
                    HabCast(Objetos.Inv2);
                    cool2 = true;
                    trans2.localScale = new Vector3(1, 1, 1);
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && !cool3 && Objetos.Inv3 != -1)
            {
                if (GlobalData.Energ >= Objetos.Inv3ener)
                {
                    GlobalData.Energ -= Objetos.Inv3ener;
                    barra.BarUpd();
                    HabCast(Objetos.Inv3);
                    cool3 = true;
                    trans3.localScale = new Vector3(1, 1, 1);
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && !cool4 && Objetos.Inv4 != -1)
            {
                if (GlobalData.Energ >= Objetos.Inv4ener)
                {
                    GlobalData.Energ -= Objetos.Inv4ener;
                    barra.BarUpd();
                    HabCast(Objetos.Inv4);
                    cool4 = true;
                    trans4.localScale = new Vector3(1, 1, 1);
                }
            }
        }

        if (cool1)
        {
            cou1 += Time.deltaTime;
            if (cou1 >= 1f)
            {
                cou1 = 0;
                seg1++;
                trans1.localScale = new Vector3(1, 1 - ((float)seg1 / (float)Objetos.Inv1cool), 1);
                if (seg1 >= Objetos.Inv1cool)
                {
                    cool1 = false;
                    seg1 = 0;
                }
            }
        }

        if (cool2)
        {
            cou2 += Time.deltaTime;
            if (cou2 >= 1f)
            {
                cou2 = 0;
                seg2++;
                trans2.localScale = new Vector3(1, 1 - ((float)seg2 / (float)Objetos.Inv2cool), 1);
                if (seg2 >= Objetos.Inv2cool)
                {
                    cool2 = false;
                    seg2 = 0;
                }
            }
        }

        if (cool3)
        {
            cou3 += Time.deltaTime;
            if (cou3 >= 1f)
            {
                cou3 = 0;
                seg3++;
                trans3.localScale = new Vector3(1, 1 - ((float)seg3 / (float)Objetos.Inv3cool), 1);
                if (seg3 >= Objetos.Inv3cool)
                {
                    cool3 = false;
                    seg3 = 0;
                }
            }
        }

        if (cool4)
        {
            cou4 += Time.deltaTime;
            if (cou4 >= 1f)
            {
                cou4 = 0;
                seg4++;
                trans4.localScale = new Vector3(1, 1 - ((float)seg4 / (float)Objetos.Inv4cool), 1);
                if (seg4 >= Objetos.Inv4cool)
                {
                    cool4 = false;
                    seg4 = 0;
                }
            }
        }

        if (countc <= 0.5 && !activeChMo && activeCant)
        {
            Cantar();
            countc += Time.deltaTime;
        }
        else
        {
            firstCantar = true;
            activeCant = false;
            countc = 0;
        }


        if (countg <= 1 && activeChMo && !activeCant)
        {
            Gritar();
            countg += Time.deltaTime;
        }
        else
        {
            firstGritar = true;
            activeChMo = false;
            countg = 0;
        }

        if(countst <= 4 && activeStun)
        {
            jgnt.CmdStun(true, enem);
            countst += Time.deltaTime;
        }
        else
        {
            activeStun = false;
            countst = 0;
            jgnt.CmdStun(false, enem);
        }

        if (countmart <= 5 && activeMart)
        {
            
            countmart += Time.deltaTime;
            jgnt.CmdStun(true, enem);
            if (firstMart)
            {
                
                jugador.GetComponent<Animator>().SetBool("isInChoque", true);
                controlAnim.jugador = jugador;
                controlAnim.isInTimerChoque = true;
                firstMart = false;
            }
        }
        else
        {
            firstMart = true;
            activeMart = false;
            countmart = 0;
            jgnt.CmdStun(false, enem);
        }

        if (countatr <=7 && activeAtrac)
        {
            Atrac();
            countatr += Time.deltaTime;

        }
        else
        {
            firstAtrac = true;
            activeAtrac = false;
            countatr = 0;
        }

        if (Input.GetKey(KeyCode.E))
        {
            jgnt.CmdisE(true);
        }
        else
        {
            jgnt.CmdisE(false);
        }

      

    }

    /*
     [0-8] = PRINCESA OP
     [9 - 17] = MAGO
     [18 - 26] = CABALLERO
     [27 - 35] = HERRERO
     [] = POCIONES
     [] = PIEDRAS
     */

    private void HabCast(int id)
    {
        switch (id)
        {
            case 1: //Princesa:Escalera
                CastEscalera();
                break;

            case 2://Princesa.Trampolin
                if (GlobalData.IsInStair) {
                    CastTrampo(pos);
                }
                break;

            case 4://Princesa.Chicle
                CastChicle(pos);
                break;

            case 5: //Princesa.Miel

                break;

            case 6://Princesa.Cantar
                if (GlobalData.IsWarning)
                {
                    activeCant = true;
                }
                break;

            case 7://Princesa.Gritar
                if (GlobalData.IsWarning)
                {
                   activeChMo = true;     
                }
                break;

            case 8://Princesa.CuentaCuentos
                if (GlobalData.IsWarning)
                {
                    activeStun = true;
                }
                break;

            case 18://Caballero.Gancho
                CastGancho(pos);
                break;

            case 19://Caballero.GanchoBotas
                break;

            case 26://Caballero.Atraccion
                if (GlobalData.IsWarning)
                {
                    activeAtrac = true;
                }
                break;

            case 27://Herrero.Cemento
                CastCemento(pos);
                break;

            case 30://Herrero.Pared
                CastTela(pos);
                break;

            case 31://Herrero.CofreTrampa
                CastCofreTrampa(pos);
                break;

            case 32://Herrero.Tunel
                CastTunel(pos);
                break;

            case 33: //Herrero.Escape
                if (GlobalData.IsWarning)
                {
                    CastEscape(pos);
                }
                break;
                

            case 34://Herrero.ChoqueMartillos
                if (GlobalData.IsWarning)
                {
                    activeMart = true;
                }
                break;

            default:
                break;
        }
    }

    public void Atrac()
    {
        if (firstAtrac)
        {
            jugador.GetComponent<Animator>().SetBool("isInAtraccion", true);
            controlAnim.jugador = jugador;
            controlAnim.isInTimerAtraccion = true;
            firstAtrac = false;
        }
        
        float x, y;
        if (activeAtrac)
        {
            if (jugador.transform.position.x - 18 >= enem.transform.position.x)
            {
                x = 0.1f;
            }
            else
            {
                x = -0.1f;
            }

            if (jugador.transform.position.y - 18 >= enem.transform.position.y)
            {
                y = 0.1f;
            }
            else
            {
                y = -0.1f;
            }

            jgnt.CmdEnem(x, y, enem);
        }
    }

    public void Cantar()
    {
        if (firstCantar)
        {
            jugador.GetComponent<Animator>().SetBool("isInCantar", true);
            controlAnim.jugador = jugador;
            controlAnim.isInTimerCantar = true;
            firstCantar = false;
        }

        float x, y;
        if (activeCant)
        {
            if (jugador.transform.position.x - 18 >= enem.transform.position.x)
            {
                x = 1;
            }
            else
            {
                x = -1;
            }

            if (jugador.transform.position.y - 18 >= enem.transform.position.y)
            {
                y = 1;
            }
            else
            {
                y = -1;
            }

            jgnt.CmdEnem(x, y, enem);
        }
    }

    public void Gritar()
    {

        if (firstGritar)
        {
            jugador.GetComponent<Animator>().SetBool("isInGritar", true);
            controlAnim.jugador = jugador;
            controlAnim.isInTimerGritar = true;
            firstGritar = false;
        }

        float x, y;
        if (activeChMo)
        {
            if (jugador.transform.position.x >= enem.transform.position.x)
            {
                x = -1;
            }
            else
            {
                x = 1;
            }

            if (jugador.transform.position.y >= enem.transform.position.y)
            {
                y = -1;
            }
            else
            {
                y = 1;
            }

            jgnt.CmdEnem(x, y, enem);
        }
    }

    private void CastGancho(Vector3 posMet)
    {
        if (jugador.GetComponent<Movimiento>().latY == -1)
        {
            posMet = new Vector3(jugador.transform.position.x, jugador.transform.position.y - 15, 0);
        }

        if (jugador.GetComponent<Movimiento>().latY == 1)
        {
            posMet = new Vector3(jugador.transform.position.x, jugador.transform.position.y + 15, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == -1)
        {
            posMet = new Vector3(jugador.transform.position.x - 15, jugador.transform.position.y, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == 1)
        {
            posMet = new Vector3(jugador.transform.position.x + 15, jugador.transform.position.y, 0);
        }

        jgnt.CmdSpawnGancho(posMet, GlobalData.ID);
    }

    public void CastEscalera()
    {
        jgnt.CmdEscalera(jugador, true);
    }

    private void CastTrampo(Vector3 posMet)
    {
    

        if (jugador.GetComponent<Movimiento>().latY == -1)//ABAJO
        {
            posMet = new Vector3(jugador.transform.position.x, jugador.transform.position.y - 56, 0);
        }

        if (jugador.GetComponent<Movimiento>().latY == 1)//ARRIBA
        {
            posMet = new Vector3(jugador.transform.position.x, jugador.transform.position.y + 56, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == -1)//IZQUIERDA
        {
            posMet = new Vector3(jugador.transform.position.x - 56, jugador.transform.position.y, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == 1)//DERECHA
        {
            posMet = new Vector3(jugador.transform.position.x + 56, jugador.transform.position.y, 0);
        }

        Instantiate(tramp, posMet, Quaternion.identity);
    }

    private void CastChicle(Vector3 posMet)
    {

        /*
        posMet = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posMet.z = 0;
        */

        if (jugador.GetComponent<Movimiento>().latY == -1)
        {
            posMet = new Vector3(jugador.transform.position.x, jugador.transform.position.y - 15, 0);
        }

        if (jugador.GetComponent<Movimiento>().latY == 1)
        {
            posMet = new Vector3(jugador.transform.position.x, jugador.transform.position.y + 15, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == -1)
        {
            posMet = new Vector3(jugador.transform.position.x - 15, jugador.transform.position.y, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == 1)
        {
            posMet = new Vector3(jugador.transform.position.x + 15, jugador.transform.position.y, 0);
        }


        jgnt.CmdSpawnChicle(posMet, GlobalData.ID);

    }

    private void CastCofreTrampa(Vector3 posMet)
    {

        Vector3 locajugador = Redondeo(jugador.transform.position);
        if (jugador.GetComponent<Movimiento>().latY == -1)
        {
            posMet = new Vector3(locajugador.x, locajugador.y - 28, 0);
        }

        if (jugador.GetComponent<Movimiento>().latY == 1)
        {
            posMet = new Vector3(locajugador.x, locajugador.y + 28, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == -1)
        {
            posMet = new Vector3(locajugador.x - 28, locajugador.y, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == 1)
        {
            posMet = new Vector3(locajugador.x + 28, locajugador.y, 0);
        }


        jgnt.CmdSpawnCofreTrampa(posMet, GlobalData.ID);

    }

    private void CastTunel(Vector3 posMet)
    {
        jugador.GetComponent<Animator>().SetBool("isInPala",true);
        controlAnim.jugador = jugador;
        controlAnim.isInTimerPala = true;
       
        
        Vector3 locajugador = Redondeo(jugador.transform.position);
        if (jugador.GetComponent<Movimiento>().latY == -1)
        {
            posMet = new Vector3(locajugador.x, locajugador.y - 28, 0);
        }

        if (jugador.GetComponent<Movimiento>().latY == 1)
        {
            posMet = new Vector3(locajugador.x, locajugador.y + 28, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == -1)
        {
            posMet = new Vector3(locajugador.x - 28, locajugador.y, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == 1)
        {
            posMet = new Vector3(locajugador.x + 28, locajugador.y, 0);
        }


        jgnt.CmdSpawnTunel(posMet, GlobalData.ID);

    }

    private void CastCemento(Vector3 posMet)
    {

        Vector3 locajugador = Redondeo(jugador.transform.position);
        if (jugador.GetComponent<Movimiento>().latY == -1)
        {
            posMet = new Vector3(locajugador.x, locajugador.y - 28, 0);
        }

        if (jugador.GetComponent<Movimiento>().latY == 1)
        {
            posMet = new Vector3(locajugador.x, locajugador.y + 28, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == -1)
        {
            posMet = new Vector3(locajugador.x - 28, locajugador.y, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == 1)
        {
            posMet = new Vector3(locajugador.x + 28, locajugador.y, 0);
        }


        jgnt.CmdSpawnCemento(posMet, GlobalData.ID);

    }

    private void CastTela(Vector3 posMet)
    {
        Vector3 locajugador = Redondeo(jugador.transform.position);
        if (jugador.GetComponent<Movimiento>().latY == -1)
        {
            posMet = new Vector3(locajugador.x, locajugador.y - 28, 0);
        }

        if (jugador.GetComponent<Movimiento>().latY == 1)
        {
            posMet = new Vector3(locajugador.x, locajugador.y + 28, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == -1)
        {
            posMet = new Vector3(locajugador.x - 28, locajugador.y, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == 1)
        {
            posMet = new Vector3(locajugador.x+28, locajugador.y, 0);
        }

        Debug.Log(posMet.x+"    "+posMet.y);
        jgnt.CmdSpawnTela(posMet, GlobalData.ID);

    }

    private void CastEscape(Vector3 posMet)
    {
        Vector3 locajugador = Redondeo(jugador.transform.position);


        if (jugador.GetComponent<Movimiento>().latY == -1)
        {
            posMet = new Vector3(locajugador.x, locajugador.y - 28, 0);
        }

        if (jugador.GetComponent<Movimiento>().latY == 1)
        {
            posMet = new Vector3(locajugador.x, locajugador.y + 28, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == -1)
        {
            posMet = new Vector3(locajugador.x - 28, locajugador.y, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == 1)
        {
            posMet = new Vector3(locajugador.x + 28, locajugador.y, 0);
        }

        if(jugador.GetComponent<Movimiento>().latX == 1 || jugador.GetComponent<Movimiento>().latX == -1)
        {
            jgnt.CmdSpawnEscapeVertical(posMet, GlobalData.ID);
        }

        if (jugador.GetComponent<Movimiento>().latY == 1 || jugador.GetComponent<Movimiento>().latY == -1)
        {
            jgnt.CmdSpawnEscapeHorizontal(posMet, GlobalData.ID);
        }

    }


    private Vector3 Redondeo(Vector3 Jugador_pos_actual)
    {

        float x, y;
        float resx, resy;

        x = Jugador_pos_actual.x;
        resx = Jugador_pos_actual.x % 28f;
        y = Jugador_pos_actual.y;
        resy = Jugador_pos_actual.y % 28f;
        Debug.Log(x + "    " + y);
        x -= (resx);
        y -= (resy);


        x = (int)x;
        y = (int)y;

        Debug.Log(x + "    " + y);
        return new Vector3(x, y, 0);
         
    }

    private Vector3 Redondeando(Vector3 Jugador_pos_actual)
    {
        float x, y;

        x = Jugador_pos_actual.x;
        y = Jugador_pos_actual.y; 



        return new Vector3(x, y, 0);
    }



}
