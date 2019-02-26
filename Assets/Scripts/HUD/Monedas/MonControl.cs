using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonControl : MonoBehaviour
{
    public Text cantmon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cantmon.text = GlobalData.Monedas.ToString();
    }

    public void AumentaMon()
    {
        GlobalData.Monedas++;
    }
}
