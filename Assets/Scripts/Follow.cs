using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject follow;
    //Este script se puede usar para cualquier camara, y usado para seguir cualquier objeto en sus ejes x y y
    // Start is called before the first frame update
    void Start()
    {
        //Diabolo nonono
    }

    // Update is called once per frame
    void FixedUpdate() //diosito sisis
    {
        float posX = follow.transform.position.x; //Se le asigna a las variables posX y posY la posicion de el jugador (obtenido desde fuera)
        float posy = follow.transform.position.y;

        transform.position = new Vector3(posX, posy, transform.position.z); //Se le asigna el vector con las posiciones del objeto que desea seguir a la camara
    }
}
