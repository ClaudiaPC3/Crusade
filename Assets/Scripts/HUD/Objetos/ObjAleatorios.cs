using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjAleatorios : MonoBehaviour
{
    public Button Obj1,Obj2,Obj3;
    public Image Per1, Per2, Per3;
    private float numero1,numero2,numero3;

    // Start is called before the first frame update
    void Start()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;
        do
        { 
            numero1 = Random.value;
        } while (numero1 < 0.00 || numero1 > 0.47);
        numero1 *= 100;
        numero1 = (int)numero1;
        do
        {
            numero2 = Random.value;
        } while (numero2 < 0.00 || numero2 > 0.47);
        numero2 *= 100;
        numero2 = (int)numero2;
        do
        {
            numero3 = Random.value;
        } while (numero3 < 0.00 || numero3 > 0.47);
        numero3 *= 100;
        numero3 = (int)numero3;
        Debug.Log(numero1+" "+numero2+" "+numero3);

        Obj1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + numero1.ToString());
        Obj1.GetComponent<ObjetoId>().id = (int)numero1;
        switch (PersonajeIdPorObjeto((int)numero1))
        {
            case 1:
                {
                    Per1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "princesa");
                    break;
                }
            case 2:
                {
                    Per1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "mago");
                    break;
                }
            case 3:
                {
                    Per1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "caballero");
                    break;
                }
            case 4:
                {
                    Per1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "herrero");
                    break;
                }
            default:
                {
                    Per3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "vacio");
                    break;
                }
        }

        Obj2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + numero2.ToString());
        Obj2.GetComponent<ObjetoId>().id = (int)numero2;
        switch (PersonajeIdPorObjeto((int)numero2))
        {
            case 1:
                {
                    Per2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "princesa");
                    break;
                }
            case 2:
                {
                    Per2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "mago");
                    break;
                }
            case 3:
                {
                    Per2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "caballero");
                    break;
                }
            case 4:
                {
                    Per2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "herrero");
                    break;
                }
            default:
                {
                    Per3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "vacio");
                    break;
                }
        }

        Obj3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + numero3.ToString());
        Obj3.GetComponent<ObjetoId>().id = (int)numero3;
        switch (PersonajeIdPorObjeto((int)numero3))
        {
            case 1:
                {
                    Per3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "princesa");
                    break;
                }
            case 2:
                {
                    Per3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "mago");
                    break;
                }
            case 3:
                {
                    Per3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "caballero");
                    break;
                }
            case 4:
                {
                    Per3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "herrero");
                    break;
                }
            default:
                {
                    Per3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "vacio");
                    break;
                }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InicializarCofre()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;
        do
        {
            numero1 = Random.value;
        } while (numero1 < 0.00 || numero1 > 0.47);
        numero1 *= 100;
        numero1 = (int)numero1;
        do
        {
            numero2 = Random.value;
        } while (numero2 < 0.00 || numero2 > 0.47);
        numero2 *= 100;
        numero2 = (int)numero2;
        do
        {
            numero3 = Random.value;
        } while (numero3 < 0.00 || numero3 > 0.47);
        numero3 *= 100;
        numero3 = (int)numero3;
        Debug.Log(numero1 + " " + numero2 + " " + numero3);

        Obj1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + numero1.ToString());
        Obj1.GetComponent<ObjetoId>().id = (int)numero1;
        switch (PersonajeIdPorObjeto((int)numero1))
        {
            case 1:
                {
                   Per1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "princesa");
                    break;
                }
            case 2:
                {
                    Per1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "mago");
                    break;
                }
            case 3:
                {
                    Per1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "caballero");
                    break;
                }
            case 4:
                {
                    Per1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "herrero");
                    break;
                }
            default:
                {
                    Per3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "vacio");
                    break;
                }
        }

        Obj2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + numero2.ToString());
        Obj2.GetComponent<ObjetoId>().id = (int)numero2;
        switch (PersonajeIdPorObjeto((int)numero2))
        {
            case 1:
                {
                    Per2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "princesa");
                    break;
                }
            case 2:
                {
                    Per2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "mago");
                    break;
                }
            case 3:
                {
                    Per2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "caballero");
                    break;
                }
            case 4:
                {
                    Per2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "herrero");
                    break;
                }
            default:
                {
                    Per3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "vacio");
                    break;
                }
        }

        Obj3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + numero3.ToString());
        Obj3.GetComponent<ObjetoId>().id = (int)numero3;
        switch (PersonajeIdPorObjeto((int)numero3))
        {
            case 1:
                {
                    Per3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "princesa");
                    break;
                }
            case 2:
                {
                    Per3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "mago");
                    break;
                }
            case 3:
                {
                    Per3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "caballero");
                    break;
                }
            case 4:
                {
                    Per3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "herrero");
                    break;
                }
            default:
                {
                    Per3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + "vacio");
                    break;
                }
        }
    }

    public int PersonajeIdPorObjeto(int objeto)
    {
        int personaje = 0;
        if (objeto < 9)
        {
            personaje = 1;
        }
        if (objeto >= 9 && objeto <= 17)
        {
            personaje = 2;
        }
        if (objeto >= 18 && objeto <= 26)
        {
            personaje = 3;
        }
        if (objeto >= 27 && objeto <= 36)
        {
            personaje = 4;
        }
        return personaje;
    }

}
