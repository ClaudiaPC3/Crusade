using System.Collections;
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
    private bool cool1 = false, cool2 = false, cool3 = false, cool4 = false, check = true, activeChMo = false, activeCant = false, activeStun = false, first =true, activeAtrac = false, activeMart = false;
    public Vector3 pos, stun;


    // Start is called before the first frame update
    void Start()
    {
        barra = bar.GetComponent<Barra>();

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
            activeChMo = false;
            countg = 0;
        }

        if(countmart <= 5 && activeMart)
        {
            Stun();
            countmart += Time.deltaTime;
        }
        else
        {
            activeMart = false;
            countmart = 0;
            first = true;
        }

        if(countst <= 4 && activeStun)
        {
            Stun();
            countst += Time.deltaTime;
        }
        else
        {
            activeStun = false;
            countst = 0;
            first = true;
        }

        if(countatr <=7 && activeAtrac)
        {
            Atrac();
            countatr += Time.deltaTime;
        }
        else
        {
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

    private void HabCast(int id)
    {
        switch (id)
        {
            case 1:
                CastEscalera();
                break;

            case 2:
                if (GlobalData.IsInStair) {
                    CastTrampo(pos);
                }
                break;

            case 4:
                CastChicle(pos);
                break;

            case 6:
                if (GlobalData.IsWarning)
                {
                    activeCant = true;
                }
                break;

            case 7:
                if(GlobalData.IsWarning)
                {
                   activeChMo = true;     
                }
                break;

            case 8:
                if (GlobalData.IsWarning)
                {
                    activeStun = true;
                }
                break;

            case 26:
                if (GlobalData.IsWarning)
                {
                    activeAtrac = true;
                }
                break;
                
            case 31:
                CastCofreTrampa(pos);
                break;

            case 32:
                CastTunel(pos);
                break;

            case 34:
                if (GlobalData.IsWarning)
                {
                    activeMart = true;
                }
                break;

            default:
                break;
        }
    }

    public void Stun()
    {
        if (first)
        {
            stun = enem.transform.position;
            first = false;
        }
        
         jgnt.CmdStun(stun.x, stun.y, enem);
        
    }

    public void Atrac()
    {
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

    public void CastEscalera()
    {
        jgnt.CmdEscalera(jugador, true);
    }

    private void CastTrampo(Vector3 posMet)
    {
        if (jugador.GetComponent<Movimiento>().latY == -1)
        {
            posMet = new Vector3(jugador.transform.position.x, jugador.transform.position.y - 56, 0);
        }

        if (jugador.GetComponent<Movimiento>().latY == 1)
        {
            posMet = new Vector3(jugador.transform.position.x, jugador.transform.position.y + 56, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == -1)
        {
            posMet = new Vector3(jugador.transform.position.x - 56, jugador.transform.position.y, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == 1)
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

        if (jugador.GetComponent<Movimiento>().latY == -1)
        {
            posMet = new Vector3(jugador.transform.position.x-14, jugador.transform.position.y - 15, 0);
        }

        if (jugador.GetComponent<Movimiento>().latY == 1)
        {
            posMet = new Vector3(jugador.transform.position.x-14, jugador.transform.position.y + 35, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == -1)
        {
            posMet = new Vector3(jugador.transform.position.x - 35, jugador.transform.position.y + 14, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == 1)
        {
            posMet = new Vector3(jugador.transform.position.x + 10, jugador.transform.position.y+14, 0);
        }


        jgnt.CmdSpawnCofreTrampa(posMet, GlobalData.ID);

    }

    private void CastTunel(Vector3 posMet)
    {

        /*
        posMet = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posMet.z = 0;
        */

        if (jugador.GetComponent<Movimiento>().latY == -1)
        {
            posMet = new Vector3(jugador.transform.position.x, jugador.transform.position.y - 25, 0);
        }

        if (jugador.GetComponent<Movimiento>().latY == 1)
        {
            posMet = new Vector3(jugador.transform.position.x, jugador.transform.position.y + 25, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == -1)
        {
            posMet = new Vector3(jugador.transform.position.x - 25, jugador.transform.position.y, 0);
        }

        if (jugador.GetComponent<Movimiento>().latX == 1)
        {
            posMet = new Vector3(jugador.transform.position.x + 25, jugador.transform.position.y, 0);
        }


        jgnt.CmdSpawnTunel(posMet, GlobalData.ID);

    }



}
