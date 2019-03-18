using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsignaObjSec : MonoBehaviour
{
    public Button[] obj;
    public Text Monedas;
    // Start is called before the first frame update
    void Start()
    {
        switch (GlobalData.Character)
        {
            case 1:
                {
                    for (int i = 0; i <= 2; i++)
                    {
                        obj[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + (i*3).ToString());
                        //obj[i].GetComponentInChildren<Text>().text = Precios.ObjPrecios(i).ToString();
                        obj[i].GetComponent<ObjetoId>().id = (i * 3);
                        obj[i].GetComponent<ObjetoId>().precio = Precios.ObjPrecios((i * 3));
                    }
                    break;
                }
            case 2:
                {
                    for (int i = 0; i <= 2; i++)
                    {
                        obj[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + ((i * 3) + 9).ToString());
                        //obj[i].GetComponentInChildren<Text>().text = Precios.ObjPrecios(i+9).ToString();
                        obj[i].GetComponent<ObjetoId>().id = (i * 3) + 9;
                        obj[i].GetComponent<ObjetoId>().precio = Precios.ObjPrecios((i * 3) + 9);
                    }
                    break;
                }
            case 3:
                {
                    for (int i = 0; i <= 2; i++)
                    {
                        obj[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + ((i * 3) + 18).ToString());
                        //obj[i].GetComponentInChildren<Text>().text = Precios.ObjPrecios(i+18).ToString();
                        obj[i].GetComponent<ObjetoId>().id = (i * 3) + 18;
                        obj[i].GetComponent<ObjetoId>().precio = Precios.ObjPrecios((i * 3) + 18);
                    }
                    break;
                }
            case 4:
                {
                    for (int i = 0; i <= 2; i++)
                    {
                        obj[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + ((i * 3) + 27).ToString());
                        //obj[i].GetComponentInChildren<Text>().text = Precios.ObjPrecios(i+27).ToString();
                        obj[i].GetComponent<ObjetoId>().id = (i * 3) + 27;
                        obj[i].GetComponent<ObjetoId>().precio = Precios.ObjPrecios((i * 3) + 27);
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
        for (int i = 3; i < 9; i++)
        {
            obj[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + ((i*2) + 30).ToString());
            //obj[i].GetComponentInChildren<Text>().text = Precios.ObjPrecios(i+27).ToString();
            obj[i].GetComponent<ObjetoId>().id = (i * 2) + 30;
            obj[i].GetComponent<ObjetoId>().precio = Precios.ObjPrecios((i * 2) + 30);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Monedas.text = "X " + GlobalData.Monedas.ToString();
    }


}
