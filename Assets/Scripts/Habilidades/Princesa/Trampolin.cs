using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] jugadores;
    public GameObject me, caster;
    private bool transition = false;
    private Transform pared;
    private float counter = 0f;
    private bool primy = false, primx = false, primy1 = false, primx1 = false;

    void Start()
    {
        jugadores = GameObject.FindGameObjectsWithTag("jugador");
        caster = GameObject.Find("Control de partida");
        
    }

    private void FixedUpdate()
    {
        if (transition)
        {
            counter = counter + Time.deltaTime;
            if(pared.position.x  > System.Math.Round(jugadores[GlobalData.ID - 1].transform.position.x)  && !primx)
            {
                jugadores[GlobalData.ID - 1].transform.position = new Vector3(jugadores[GlobalData.ID - 1].transform.position.x + 1.5f, jugadores[GlobalData.ID - 1].transform.position.y, 0);
                primx1 = true;
            }

            if (pared.position.x  < System.Math.Round(jugadores[GlobalData.ID - 1].transform.position.x)  && !primx1)
            {
                jugadores[GlobalData.ID - 1].transform.position = new Vector3(jugadores[GlobalData.ID - 1].transform.position.x - 1.5f, jugadores[GlobalData.ID - 1].transform.position.y, 0);
                primx = true;
            }

            if (pared.position.y  > System.Math.Round(jugadores[GlobalData.ID - 1].transform.position.y)  && !primy)
            {
                jugadores[GlobalData.ID - 1].transform.position = new Vector3(jugadores[GlobalData.ID - 1].transform.position.x, jugadores[GlobalData.ID - 1].transform.position.y + 1.5f, 0);
                primy1 = true;
            }

            if (pared.position.y  < System.Math.Round(jugadores[GlobalData.ID - 1].transform.position.y)  && !primy1)
            {
                jugadores[GlobalData.ID - 1].transform.position = new Vector3(jugadores[GlobalData.ID - 1].transform.position.x, jugadores[GlobalData.ID - 1].transform.position.y - 1.5f, 0);
                primy = true;
            }

            caster.GetComponent<Cast>().CastEscalera();
            Debug.Log(pared.position);

            if (counter > 0.9)
            {
                transition = false;
                Destroy(me);

            }
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Pared")
        {
            
            pared = me.transform;
            Debug.Log(pared.position);
            transition = true;
            
        }
    }

}
