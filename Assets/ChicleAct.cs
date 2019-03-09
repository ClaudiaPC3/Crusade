using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicleAct : MonoBehaviour
{
    private Vector3 jg;
    private bool act = false;
    private float cont = 0;
    public bool ischicle = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.tag == "jugador"&&ischicle)
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
