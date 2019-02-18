using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CofreInteraccion : NetworkBehaviour
{
    public Animator anim;
    public GameObject personaje1;
    public GameObject MenuCofre;
    private Transform posicion;
    private bool proceso = true;
    private bool activo = true;
    private float currentTime = 0.0f;

    [SyncVar]
    public int estado=1;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetFloat("Estado", estado);
        posicion = GetComponent<Transform>();
        MenuCofre = GameObject.FindWithTag("Cofre");
        
        //proceso = GlobalData.EnCurso;////////////////////////////////////////////////

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Estado", estado);
        if (personaje1 == null)
        {
            personaje1 = GameObject.Find("Main Camera");
        }
        if (proceso)
        {
            if (((personaje1.GetComponent<Transform>().transform.position.x <= (posicion.position.x + 44) && personaje1.GetComponent<Transform>().transform.position.x >= (posicion.position.x - 16)) && (personaje1.GetComponent<Transform>().transform.position.y <= (posicion.position.y + 16) && personaje1.GetComponent<Transform>().transform.position.y >= (posicion.position.y - 42)))&&activo)
            {
                estado = 2; //command
                CmdChangeState(2);
                if (Input.GetKeyUp(KeyCode.E))
                {
                    MenuCofre.SetActive(true);
                    GlobalData.EnCofre = true;
                    estado = 3;
                    CmdChangeState(3);
                    activo = false;
                }
            }
            else
            {
                if (activo)
                {
                    estado = 1;
                    CmdChangeState(1);
                }
            }
            if (!activo)
            {
                currentTime = Time.deltaTime+currentTime;
                if (currentTime >= 30.0f)
                {
                    currentTime = 0.0f;
                    activo = true;
                    estado = 1;
                    CmdChangeState(1);
                }
            }
        }
        
        
    }

    [Command]
    void CmdChangeState(int n)
    {
        estado = n;
    }
}
