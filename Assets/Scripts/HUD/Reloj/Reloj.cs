using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reloj : MonoBehaviour
{
    public Text reloj;
    int segs = 10;
    int mins = 0;
    bool pre = true;
    float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalData.Desb == true)
        {
            counter += Time.deltaTime;
            reloj.fontSize = 90;
            if (counter >= 1f && pre == true)
            {
                counter = 0;
                segs--;
                if (segs == 0)
                {
                    pre = false;
                }
            }
            if (counter >= 1f && pre == false)
            {
                counter = 0;
                segs++;
                if (segs > 59)
                {
                    mins++;
                    segs = 0;
                }
            }
            reloj.text = mins + ":" + segs;
        }
        
    }
}
