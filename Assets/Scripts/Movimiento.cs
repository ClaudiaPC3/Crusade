using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 4f;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 mov = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
            );

        transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position + mov,
            speed);

        anim.SetFloat("MovX", mov.x);
        anim.SetFloat("MovY", mov.y);
    }
}
