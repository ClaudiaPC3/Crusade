using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreInteraccion : MonoBehaviour
{
    public Animator anim;
    public GameObject personaje1, personaje2;
    public GameObject MenuCofre;
    private Transform posicion;
    private bool proceso = true;
    private int dist = 30;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetFloat("Estado", 1);
        posicion = GetComponent<Transform>();
        MenuCofre.SetActive(false);
        //proceso = GlobalData.EnCurso;////////////////////////////////////////////////

    }

    // Update is called once per frame
    void Update()
    {

        if (personaje1 == null || personaje2 == null)
        {
            switch (GlobalData.Character)
            {
                case 1:
                    personaje1 = GameObject.Find("Princesa Test(Clone)");
                    personaje2 = GameObject.Find("Princesa Test(Clone)");

                    break;
                case 2:
                    personaje1 = GameObject.Find("Mago Test(Clone)");
                    personaje2 = GameObject.Find("Mago Test(Clone)");

                    break;
                case 3:
                    personaje1 = GameObject.Find("Caballero(Clone)");
                    personaje2 = GameObject.Find("Caballero(Clone)");

                    break;
                case 4:
                    personaje1 = GameObject.Find("Herrero Test(Clone)");
                    personaje2 = GameObject.Find("Herrero Test(Clone)");

                    break;
            }
        }
        if (proceso)
        {
            if ((personaje1.GetComponent<Transform>().transform.position.x <= (posicion.position.x + dist) && personaje1.GetComponent<Transform>().transform.position.x >= (posicion.position.x - dist)) && (personaje1.GetComponent<Transform>().transform.position.y <= (posicion.position.y + dist) && personaje1.GetComponent<Transform>().transform.position.y >= (posicion.position.y - dist)))
            {
                MenuCofre.SetActive(true);
                anim.SetFloat("Estado", 2);

            }
        }
        
    }

    public void CerrarCofre()
    {
        anim.SetFloat("Estado", 3);
        MenuCofre.SetActive(false);
    }
}
