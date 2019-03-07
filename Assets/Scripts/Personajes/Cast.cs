using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    public GameObject bar;
    private Barra barra;
    public RectTransform trans1;
    public RectTransform trans2;
    public RectTransform trans3;
    public RectTransform trans4;
    float cou1=0, cou2=0, cou3=0, cou4=0;
    int seg1 = 0, seg2 = 0, seg3 = 0, seg4 = 0;
    bool cool1 = false, cool2 = false, cool3 = false, cool4 = false;
    // Start is called before the first frame update
    void Start()
    {
        barra = bar.GetComponent<Barra>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalData.EnPausa == false && GlobalData.EnCofre == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (GlobalData.Energ>=Objetos.Inv1ener&&!cool1&&Objetos.Inv1!=-1){
                    GlobalData.Energ -= Objetos.Inv1ener;
                    barra.BarUpd();
                    cool1 = true;
                    trans1.localScale = new Vector3(1, 1, 1);
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)&&!cool2 && Objetos.Inv2 != -1)
            {
                if (GlobalData.Energ >= Objetos.Inv2ener)
                {
                    GlobalData.Energ -= Objetos.Inv2ener;
                    barra.BarUpd();
                    cool2 = true;
                    trans2.localScale = new Vector3(1, 1, 1);
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && !cool3 && Objetos.Inv3 != -1)
            {
                if (GlobalData.Energ >= Objetos.Inv3ener)
                {
                    GlobalData.Energ -= Objetos.Inv3ener;
                    barra.BarUpd();
                    cool3 = true;
                    trans3.localScale = new Vector3(1, 1, 1);
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && !cool4 && Objetos.Inv4 != -1)
            {
                if (GlobalData.Energ >= Objetos.Inv4ener)
                {
                    GlobalData.Energ -= Objetos.Inv4ener;
                    barra.BarUpd();
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
                cou1 = 0;
                seg1++;
                trans1.localScale = new Vector3(1, 1-((float)seg1/(float)Objetos.Inv1cool), 1);
                if(seg1>= Objetos.Inv1cool)
                {
                    cool1 = false;
                    seg1 = 0;
                }
            }
        }

        if (cool2)
        {
            cou2 += Time.deltaTime;
            if (cou2 >= 1f)
            {
                cou2 = 0;
                seg2++;
                trans2.localScale = new Vector3(1, 1 - ((float)seg2 / (float)Objetos.Inv2cool), 1);
                if (seg2 >= Objetos.Inv2cool)
                {
                    cool2 = false;
                    seg2 = 0;
                }
            }
        }

        if (cool3)
        {
            cou3 += Time.deltaTime;
            if (cou3 >= 1f)
            {
                cou3 = 0;
                seg3++;
                trans3.localScale = new Vector3(1, 1 - ((float)seg3 / (float)Objetos.Inv3cool), 1);
                if (seg3 >= Objetos.Inv3cool)
                {
                    cool3 = false;
                    seg3 = 0;
                }
            }
        }

        if (cool4)
        {
            cou4 += Time.deltaTime;
            if (cou4 >= 1f)
            {
                cou4 = 0;
                seg4++;
                trans4.localScale = new Vector3(1, 1 - ((float)seg4 / (float)Objetos.Inv4cool), 1);
                if (seg4 >= Objetos.Inv4cool)
                {
                    cool4 = false;
                    seg4 = 0;
                }
            }
        }

    }
}
