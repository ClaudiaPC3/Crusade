using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicle : MonoBehaviour
{
    public bool Coll = false;
    public Sprite chicle;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coll = true;
        if(collision.transform.gameObject.tag == "Pared")
        {
            collision.transform.gameObject.GetComponent<SpriteRenderer>().sprite = chicle;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Coll = false;
    }

    
}
