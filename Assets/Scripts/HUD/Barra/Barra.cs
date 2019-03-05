using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour
{
    RectTransform trans;
    float counter = 0;
    float energ = 0;
    GameObject[] jugadores;
    bool check = true;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (check)
        {
            jugadores = GameObject.FindGameObjectsWithTag("jugador");
        }
        if (jugadores.Length == 2)
        {
            check = false;
            if (counter >= GlobalData.EnergSpe && GlobalData.Energ < GlobalData.EnergLim)
            {
                counter = 0;
                GlobalData.Energ++;
                BarUpd();
            }
        }
    }

    void BarUpd()
    {
        energ = GlobalData.Energ;
        energ = (energ * 100)/ GlobalData.EnergLim;
        energ = energ / 100;
        trans.localScale = new Vector3(1, energ, 1);
    }
}
