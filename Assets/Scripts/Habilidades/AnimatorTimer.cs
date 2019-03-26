using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTimer : MonoBehaviour
{

    public bool isInTimerPala = false;
    private float currentTime1=0.0f;
    public bool isInTimerAtraccion = false;
    private float currentTime2 = 0.0f;
    public bool isInTimerChoque= false;
    private float currentTime3 = 0.0f;
    public bool isInTimerCantar= false;
    private float currentTime4 = 0.0f;
    public bool isInTimerGritar= false;
    private float currentTime5 = 0.0f;
    public GameObject jugador;

    // Update is called once per frame
    void Update()
    {
        if (isInTimerPala)
        {
            currentTime1 = Time.deltaTime + currentTime1;
            if (currentTime1 >= 0.570f)
            {
                isInTimerPala = false;
                currentTime1 = 0.0f;
                jugador.GetComponent<Animator>().SetBool("isInPala", false);
            }
        }
        if (isInTimerAtraccion)
        {
            currentTime2 = Time.deltaTime + currentTime2;
            if (currentTime2 >= 1.20f)
            {
                isInTimerAtraccion = false;
                currentTime2 = 0.0f;
                jugador.GetComponent<Animator>().SetBool("isInAtraccion", false);
            }
        }
        if (isInTimerChoque)
        {
            currentTime3 = Time.deltaTime + currentTime3;
            if (currentTime3 >= 0.30f)
            {
                isInTimerChoque = false;
                currentTime3 = 0.0f;
                jugador.GetComponent<Animator>().SetBool("isInChoque", false);
            }
        }
        if (isInTimerCantar)
        {
            currentTime4 = Time.deltaTime + currentTime4;
            if (currentTime4 >= 0.50f)
            {
                isInTimerCantar = false;
                currentTime4 = 0.0f;
                jugador.GetComponent<Animator>().SetBool("isInCantar", false);
            }
        }

        if (isInTimerGritar)
        {
            currentTime5 = Time.deltaTime + currentTime5;
            if (currentTime5 >= 0.35f)
            {
                isInTimerGritar = false;
                currentTime5 = 0.0f;
                jugador.GetComponent<Animator>().SetBool("isInGritar", false);
            }
        }
    }
}
