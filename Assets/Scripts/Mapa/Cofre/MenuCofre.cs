using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCofre : MonoBehaviour
{
    public GameObject Menu;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CerrarCofre()
    {
        Menu.SetActive(false);
        GlobalData.EnCofre = false;
    }
}
