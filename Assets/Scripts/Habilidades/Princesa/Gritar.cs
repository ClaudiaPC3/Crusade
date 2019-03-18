using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gritar : MonoBehaviour
{
    public bool active = false;
    public GameObject me, enem, jgnt;

    public void Init(bool active, GameObject me, GameObject enem, GameObject jgnt)
    { 
       this.active = active;
       this.me = me;
       this.enem = enem;
       this.jgnt = jgnt;
    }

    void Update()
    {
        if (active)
        {
            if (me.transform.position.x >= enem.transform.position.x)
            {
                jgnt.GetComponent<JugadorNet>();
            }

            if (me.transform.position.y >= enem.transform.position.y)
            {
                jgnt.GetComponent<JugadorNet>();
            }
        }

    }
}
