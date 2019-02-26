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
        } while (numero1 < 0.01 || numero1 > 0.35);
        numero1 *= 100;
        numero1 = (int)numero1;
        do
        {
            numero2 = Random.value;
        } while (numero2 < 0.01 || numero2 > 0.35);
        numero2 *= 100;
        numero2 = (int)numero2;
        do
        {
            numero3 = Random.value;
        } while (numero3 < 0.01 || numero3 > 0.35);
        numero3 *= 100;
        numero3 = (int)numero3;
        Debug.Log(numero1+" "+numero2+" "+numero3);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InicializarCofre()
    {
        Debug.Log("wa entrar");
        Random.seed = (int)System.DateTime.Now.Ticks;
        do
        {
            numero1 = Random.value;
        } while (numero1 < 0.01 || numero1 > 0.35);
        numero1 *= 100;
        numero1 = (int)numero1;
        Debug.Log("sali del 1");
        do
        {
            numero2 = Random.value;
        } while (numero2 < 0.01 || numero2 > 0.35);
        numero2 *= 100;
        numero2 = (int)numero2;
        do
        {
            numero3 = Random.value;
        } while (numero3 < 0.01 || numero3 > 0.35);
        numero3 *= 100;
        numero3 = (int)numero3;
        Debug.Log(numero1 + " " + numero2 + " " + numero3);

    }

}
