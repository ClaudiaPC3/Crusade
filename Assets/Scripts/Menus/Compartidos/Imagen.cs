using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Imagen : MonoBehaviour
{
    public Sprite[] frames;
    public int cantidad = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.time * cantidad) % frames.Length;
        GetComponent<Image>().sprite = frames[index];

    }
}
