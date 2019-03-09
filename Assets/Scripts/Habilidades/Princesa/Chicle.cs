using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicle : MonoBehaviour
{
    private bool cont = false, coll = false;
    private float counter = 0;
    public Sprite chicle, pared;
    public GameObject me;
    private SpriteRenderer rnd = null;
    private GameObject[] chicles;

    private void Start()
    {
        chicles = GameObject.FindGameObjectsWithTag("Chicle");
        if (chicles.Length > 4)
        {
            Destroy(chicles[0]);
        }
    }

    private void Update()
    {
        if (!coll)
        {
            counter += Time.deltaTime;
            if(counter >= 1)
            {
                Destroy(me);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.transform.gameObject.tag == "Pared"&&!cont)
        {
            rnd = collision.transform.gameObject.GetComponent<SpriteRenderer>();
            rnd.sprite = chicle;
            coll = true;
            collision.transform.gameObject.GetComponent<ChicleAct>().ischicle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(me);
    }

    private void OnDestroy()
    {
        if(rnd != null)
        {
            rnd.sprite = pared;
        }
    }

}
