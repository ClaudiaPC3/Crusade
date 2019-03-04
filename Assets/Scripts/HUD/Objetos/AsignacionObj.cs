using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsignacionObj : MonoBehaviour
{
    public Image obj1;
    public Image obj2;
    public Image obj3;
    public Image obj4;
    public int[] stats;

    public GameObject MenuSeleccionObj;
    // Start is called before the first frame update
    void Start()
    {
        stats = new int[2];
    }

    // Update is called once per frame
    void Update()
    {
        if (Objetos.Inv1 != -1)
        {
            obj1.sprite = Resources.Load<Sprite>("Sprites/" + Objetos.Inv1.ToString());
        }
        if (Objetos.Inv2 != -1)
        {
            obj2.sprite = Resources.Load<Sprite>("Sprites/" + Objetos.Inv2.ToString());
        }
        if (Objetos.Inv3 != -1)
        {
            obj3.sprite = Resources.Load<Sprite>("Sprites/" + Objetos.Inv3.ToString());
        }
        if (Objetos.Inv4 != -1)
        {
            obj4.sprite = Resources.Load<Sprite>("Sprites/" + Objetos.Inv4.ToString());
        }
    }

    public void Asignar(int inv)
    {
        switch (inv)
        {
            case 1:
                {
                    Objetos.Inv1 = Objetos.ObjSelec;
                    stats = setStats(Objetos.Inv1);
                    Objetos.Inv1cool = stats[0];
                    Objetos.Inv1ener = stats[1];
                    break;
                }
            case 2:
                {
                    Objetos.Inv2 = Objetos.ObjSelec;
                    stats = setStats(Objetos.Inv2);
                    Objetos.Inv2cool = stats[0];
                    Objetos.Inv2ener = stats[1];
                    break;
                }
            case 3:
                {
                    Objetos.Inv3 = Objetos.ObjSelec;
                    stats = setStats(Objetos.Inv3);
                    Objetos.Inv3cool = stats[0];
                    Objetos.Inv3ener = stats[1];
                    break;
                }
            case 4:
                {
                    Objetos.Inv4 = Objetos.ObjSelec;
                    stats = setStats(Objetos.Inv4);
                    Objetos.Inv4cool = stats[0];
                    Objetos.Inv4ener = stats[1];
                    break;
                }
        }
    }

    public int[] setStats(int id)
    {
        int[] statsT;
        statsT = new int[2];

        switch (id)
        {
            case 1:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 2:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 3:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 4:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 5:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 6:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 7:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 8:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 9:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 10:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 11:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 12:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 13:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 14:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 15:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 16:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 17:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 18:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 19:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 20:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 21:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 22:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 23:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 24:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 25:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 26:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 27:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 28:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 29:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 30:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 31:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 32:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 33:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 34:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 35:
                statsT[0] = 5;
                statsT[1] = 25;
                break;
            case 36:
                //Creo que esta es una pocion jeje
                break;
        }

  
        return statsT;
    }

}
