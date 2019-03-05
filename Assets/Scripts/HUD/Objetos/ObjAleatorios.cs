using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjAleatorios : MonoBehaviour
{
    public Button Obj1,Obj2,Obj3;
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

        Obj2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + numero2.ToString());
        Obj2.GetComponent<ObjetoId>().id = (int)numero2;

        Obj3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + numero3.ToString());
        Obj3.GetComponent<ObjetoId>().id = (int)numero3;

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

        Obj2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + numero2.ToString());
        Obj2.GetComponent<ObjetoId>().id = (int)numero2;

        Obj3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + numero3.ToString());
        Obj3.GetComponent<ObjetoId>().id = (int)numero3;

    }

}
