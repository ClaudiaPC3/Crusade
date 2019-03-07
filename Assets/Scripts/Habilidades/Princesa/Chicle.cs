using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicle : MonoBehaviour
{
    public bool Coll = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coll = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Coll = false;
    }

    
}
