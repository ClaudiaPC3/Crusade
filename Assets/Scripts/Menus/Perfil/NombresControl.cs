using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NombresControl : MonoBehaviour
{
    public GameObject Nombre;
    public GameObject Sobrenombre;
    public GameObject GuarNom;
    public GameObject GuarSobr;
    public Button EditNom;
    public Button EditSobr;
    public Text TxtNom;
    public Text TxtSobr;
    // Start is called before the first frame update
    void Start()
    {
        Nombre.SetActive(false);
        Sobrenombre.SetActive(false);
        GuarNom.SetActive(false);
        GuarSobr.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TxtNom.text = PlayerPrefs.GetString("Nombre");
        TxtSobr.text = PlayerPrefs.GetString("Sobrenombre");
    }

    public void MostrarNom()
    {
        Nombre.SetActive(true);
        GuarNom.SetActive(true);
    }
    public void MostrarSobr()
    {
        Sobrenombre.SetActive(true);
        GuarSobr.SetActive(true);
    }
    public void GuardarNom()
    {
        if (Nombre.GetComponent<InputField>().text != "")
        {
            PlayerPrefs.SetString("Nombre", Nombre.GetComponent<InputField>().text);
            Nombre.SetActive(false);
            GuarNom.SetActive(false);
        }      
    }
    public void GuardarSobr()
    {
        if(Sobrenombre.GetComponent<InputField>().text != "")
        {
            PlayerPrefs.SetString("Sobrenombre", Sobrenombre.GetComponent<InputField>().text);
            Sobrenombre.SetActive(false);
            GuarSobr.SetActive(false);
        }
    }
}
