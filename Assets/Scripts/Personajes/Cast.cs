using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    public RectTransform trans1;
    public RectTransform trans2;
    public RectTransform trans3;
    public RectTransform trans4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalData.EnPausa == false && GlobalData.EnCofre == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (GlobalData.Energ>=Objetos.Inv1ener){
                    GlobalData.Energ -= Objetos.Inv1ener;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (GlobalData.Energ >= Objetos.Inv2ener)
                {
                    GlobalData.Energ -= Objetos.Inv2ener;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (GlobalData.Energ >= Objetos.Inv3ener)
                {
                    GlobalData.Energ -= Objetos.Inv3ener;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (GlobalData.Energ >= Objetos.Inv4ener)
                {
                    GlobalData.Energ -= Objetos.Inv4ener;
                }
            }
        }
    }
}
