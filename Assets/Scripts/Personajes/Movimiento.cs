using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movimiento : NetworkBehaviour
{
    public GameObject camara;
    public Transform transCam, propio;

    //Variable de la velocidad del personaje (Editable desde el prefab del personaje)
    private float speed = 50f;

    //Objeto del animador
    public Animator anim;

    //Objeto Rigid Body
    Rigidbody2D rg2d;

    //Variables de control de animaciones
    public float lastX = 0f;
    public float lastY = -1f;
    public bool isMov = false;

    private Vector2 mov;
    private Vector3 cam;
    private Vector3 inicio;
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>(); // Ubica nuestro animador
        rg2d = GetComponent<Rigidbody2D>();//Ubica el cuerpo
        propio = GetComponent<Transform>();
        camara = GameObject.Find("Main Camera");
        transCam = camara.GetComponent<Transform>();
          

        if (hasAuthority)
        {
            inicio = new Vector3(1349, -431, 0);
            propio.position = inicio;
        }
        else
        {
            inicio = new Vector3(111, -431, 0);
            propio.position = inicio;
        }        
                
    }

    // Update is called once per frame
    void Update()
    {
        //Esto es del diablo fuchi
    }

    private void FixedUpdate() //Esto es de diosito chichenol
    {
        if (!hasAuthority)
        {
            return;
        }
            mov = new Vector2( //En este vector se asigna la información obtenida por perifericos
            Input.GetAxisRaw("Horizontal"), //señal X de los perifericos
            Input.GetAxisRaw("Vertical") //señal Y de los perifericos
            );

        if (mov.x != 0 || mov.y != 0) //el if es usado para evitar que se le asigne 0,0 y terminar con la animacion default
        {
            lastX = mov.x; //variables que guardan el ultimo movimiento para el arbol de animaciones idle
            lastY = mov.y;
           
        }

        anim.SetFloat("LastX", lastX); //Se envia al animador las variables del ultimo movimiento
        anim.SetFloat("LastY", lastY);

        if (mov.x == 0f && mov.y == 0f) //¿El personaje esta en movimiento?
            isMov = false; //no chenol
        else
            isMov = true;  //chi chenol      

        if(mov.x == 0 || mov.y == 0) { 
            rg2d.MovePosition(rg2d.position + mov * speed * Time.deltaTime); //Esto se encarga de hacer el movimiento
        }
        else
        {
            rg2d.MovePosition(rg2d.position + mov * (speed/1.7f) * Time.deltaTime);
        }

        cam = new Vector3(propio.position.x, propio.position.y, -10);
        transCam.position = cam;
        

        anim.SetFloat("MovX", mov.x); //Se envian las variables para las animaciones del arbol de movimientos
        anim.SetFloat("MovY", mov.y);
        anim.SetBool("Movement", isMov); //Variable de control para cambio de arboles
    }
}
