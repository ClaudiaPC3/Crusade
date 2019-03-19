using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Tunel : MonoBehaviour
{

    // Start is called before the first frame update
    public int idCast;
    private GameObject[] tuneles;
    private GameObject destino;
   

    void Start()
    {

        tuneles = GameObject.FindGameObjectsWithTag("Tunel");
        if (tuneles.Length > 2)
        {
            Destroy(tuneles[0]);
        }
        Debug.Log(GlobalData.ID);

        
    }
    void Update()
    {
        if (idCast != GlobalData.ID)
        {
            Destroy(GetComponent<BoxCollider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (idCast== collision.transform.gameObject.GetComponent<Movimiento>().id)
        {
            tuneles = GameObject.FindGameObjectsWithTag("Tunel");
            if (GetComponent<Transform>().position == tuneles[0].transform.position)
            {
                destino = tuneles[1];
            }
            else
            {
                destino = tuneles[0];
            }
            if (collision.transform.gameObject.tag == "jugador" && GlobalData.InTunel==0)
            {
                collision.transform.gameObject.transform.position = destino.transform.position;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GlobalData.InTunel<1)
        {
            GlobalData.InTunel++;
        }
        else
        {
            GlobalData.InTunel=0;
        }
    }
}
