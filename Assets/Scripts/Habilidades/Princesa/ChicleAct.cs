using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicleAct : MonoBehaviour
{
    private Vector3 jg;
    private bool act = false;
    private float cont = 0;
    public bool ischicle = false;
    public int jugCast = 0;
    public GameObject miChi;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.tag == "jugador"&&ischicle&& collision.transform.gameObject.GetComponent<Movimiento>().id!=jugCast)
        {
            jg = collision.transform.transform.position;
            act = true;
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (act)
        {
            collision.transform.gameObject.transform.position = jg;
        }
        cont += Time.deltaTime;
        if (cont >= 4)
        {
            act = false;
            cont = 0;
            Destroy(miChi);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Chicle")
        {
            ischicle = false;
        }
    }

}
