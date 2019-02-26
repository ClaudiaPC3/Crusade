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

    public GameObject MenuSeleccionObj;
    // Start is called before the first frame update
    void Start()
    {
        
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
                    break;
                }
            case 2:
                {
                    Objetos.Inv2 = Objetos.ObjSelec;
                    break;
                }
            case 3:
                {
                    Objetos.Inv3 = Objetos.ObjSelec;
                    break;
                }
            case 4:
                {
                    Objetos.Inv4 = Objetos.ObjSelec;
                    break;
                }
        }
    }

    
}
