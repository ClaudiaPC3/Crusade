using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    public RectTransform trans1;
    public RectTransform trans2;
    public RectTransform trans3;
    public RectTransform trans4;
    float cou1=0, cou2=0, cou3=0, cou4=0;
    bool cool1 = false, cool2 = false, cool3 = false, cool4 = false;
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
                if (GlobalData.Energ>=Objetos.Inv1ener&&!cool1){
                    GlobalData.Energ -= Objetos.Inv1ener;
                    cool1 = true;
                    trans1.localScale = new Vector3(1, 1, 1);
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)&&!cool2)
            {
                if (GlobalData.Energ >= Objetos.Inv2ener)
                {
                    GlobalData.Energ -= Objetos.Inv2ener;
                    cool2 = true;
                    trans2.localScale = new Vector3(1, 1, 1);
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && !cool3)
            {
                if (GlobalData.Energ >= Objetos.Inv3ener)
                {
                    GlobalData.Energ -= Objetos.Inv3ener;
                    cool3 = true;
                    trans3.localScale = new Vector3(1, 1, 1);
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && !cool4)
            {
                if (GlobalData.Energ >= Objetos.Inv4ener)
                {
                    GlobalData.Energ -= Objetos.Inv4ener;
                    cool4 = true;
                    trans4.localScale = new Vector3(1, 1, 1);
                }
            }
        }

        if (cool1)
        {
            cou1 += Time.deltaTime;
            if (cou1 >= 1f)
            {

            }
        }

    }
}
