using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoZoom : MonoBehaviour
{
    public bool hacer = false;
    private float currentTime = 0.0f;
    private float camSize = 58;
    public Camera camara;
    private bool paso1=true, paso2=false,paso3=false;
    private int velocidad1=250, velocidad2=350;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hacer)
        {
            if (paso1&&camSize < 700)
            {
                currentTime = Time.deltaTime + currentTime;
                camSize = (currentTime * velocidad1)+58;
                camara.orthographicSize = camSize;
            }
            else
            {
                if (paso1)
                {
                    paso1 = false;
                    paso2 = true;
                    currentTime = 0;
                }
            }
            if (paso2&&currentTime<2)
            {
                currentTime = Time.deltaTime + currentTime;

            }else
            {
                if (paso2)
                {
                    paso2 = false;
                    paso3 = true;
                    currentTime = 0;
                }
            }
            if (paso3 && camSize > 58)
            {
                currentTime = Time.deltaTime + currentTime;
                camSize = 700-(currentTime * velocidad2);
                camara.orthographicSize = camSize;
            }
            else
            {
                if (paso3)
                {
                    paso1 = true;
                    paso2 = false;
                    paso3 = false;
                    hacer = false;
                    currentTime = 0;
                }
            }
        }
    }
}
