using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicle : MonoBehaviour
{
    public bool cont = false;
    public Sprite chicle;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.transform.gameObject.tag == "Pared"&&!cont)
        {
            collision.transform.gameObject.GetComponent<SpriteRenderer>().sprite = chicle;
            cont = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    
}
