using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    struct casilla
    {
        public bool taken;
        public int x, y, id;
        public casilla(int x, int y, int id, bool taken)
        {
            this.x = x;
            this.y = y;
            this.id = id;
            this.taken = taken;
        }
    }

    casilla[,] mapa = new casilla [19,8];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
