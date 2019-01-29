using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    //Variable de la velocidad del personaje (Editable desde el prefab del personaje)
    public float speed = 4f;

    //Objeto del animador
    public Animator anim;

    //Variables de control de animaciones
    public float lastX = 0f;
    public float lastY = -1f;
    public bool isMov = false;

    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>(); // Ubica nuestro animador
    }

    // Update is called once per frame
    void Update()
    {
        //Esto es del diablo fuchi
    }

    private void FixedUpdate() //Esto es de diosito chichenol
    {
        Vector3 mov = new Vector3( //En este vector se asigna la información obtenida por perifericos
            Input.GetAxisRaw("Horizontal"), //señal X de los perifericos
            Input.GetAxisRaw("Vertical"), //señal Y de los perifericos
            0 //Z xdxd nadie te quiere
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

        transform.position = Vector3.MoveTowards( //Se le aplica al transform del jugador (obtenido desde fuera) la funcion towards (los mueve de lugar)
            transform.position, //Aqui se indica su anterior posicion 
            transform.position + mov, //Aqui su nueva
            speed); //Aqui su velocidad

        anim.SetFloat("MovX", mov.x); //Se envian las variables para las animaciones del arbol de movimientos
        anim.SetFloat("MovY", mov.y);
        anim.SetBool("Movement", isMov); //Variable de control para cambio de arboles
    }
}
