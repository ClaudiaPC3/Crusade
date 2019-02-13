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
    private bool activo = true;
    private float currentTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetFloat("Estado", 1);
        posicion = GetComponent<Transform>();
        MenuCofre = GameObject.FindWithTag("Cofre");
        
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
            if (((personaje1.GetComponent<Transform>().transform.position.x <= (posicion.position.x + dist) && personaje1.GetComponent<Transform>().transform.position.x >= (posicion.position.x - dist)) && (personaje1.GetComponent<Transform>().transform.position.y <= (posicion.position.y + dist) && personaje1.GetComponent<Transform>().transform.position.y >= (posicion.position.y - dist)))&&activo)
            {
                anim.SetFloat("Estado", 2);
                if (Input.GetKeyUp(KeyCode.E))
                {
                    MenuCofre.SetActive(true);
                    GlobalData.EnCofre = true;
                    anim.SetFloat("Estado", 3);
                    activo = false;
                }
            }
            else
            {
                if (activo)
                {
                    anim.SetFloat("Estado", 1);
                }
            }
            if (!activo)
            {
                currentTime = Time.deltaTime+currentTime;
                if (currentTime >= 30.0f)
                {
                    currentTime = 0.0f;
                    activo = true;
                    anim.SetFloat("Estado", 1);
                }
            }
        }
        
        
    }
}
