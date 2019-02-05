using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Linq;

public class MeterPartida : MonoBehaviour
{
    GameObject[] Partida = new GameObject[100];
    public GameObject Prefab;
    public int cantidad;

    // Start is called before the first frame update
    void Start()
    {
        List<Dictionary<string, string>> allTextDic = parseFile();
        Dictionary<string, string> dic = allTextDic[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<Dictionary<string, string>> parseFile()
    {
        GameObject nuevo;
        TextAsset txtXmlAsset = Resources.Load<TextAsset>("Partidas");
        var doc = XDocument.Parse(txtXmlAsset.text);

        var allDict = doc.Element("document").Elements("Partida");
        List<Dictionary<string, string>> allTextDic = new List<Dictionary<string, string>>();
        foreach (var oneDict in allDict)
        {
            var cadenas = oneDict.Elements("string");
            XElement element1 = cadenas.ElementAt(0);
            XElement element2 = cadenas.ElementAt(1);
            XElement element3 = cadenas.ElementAt(2);
            XElement element4 = cadenas.ElementAt(3);
            XElement element5 = cadenas.ElementAt(4);
            XElement element6 = cadenas.ElementAt(5);
            string uno = element1.ToString().Replace("<string>", "").Replace("</string>", "");
            string dos = element2.ToString().Replace("<string>", "").Replace("</string>", "");
            string tres = element3.ToString().Replace("<string>", "").Replace("</string>", "");
            string cuatro = element4.ToString().Replace("<string>", "").Replace("</string>", "");
            string cinco = element5.ToString().Replace("<string>", "").Replace("</string>", "");
            string seis = element6.ToString().Replace("<string>", "").Replace("</string>", "");

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("nombre", uno);
            dic.Add("resultado", dos);
            dic.Add("tipo", tres);
            dic.Add("punt1", cuatro);
            dic.Add("punt2", cinco);
            dic.Add("fecha", seis);

            nuevo = (GameObject)Instantiate(Prefab, transform);
            Text[] lista = nuevo.GetComponent<Image>().GetComponentsInChildren<Text>();
            lista[0].text = uno;
            lista[1].text = dos;
            lista[2].text = tres;
            lista[3].text = cuatro;
            lista[4].text = cinco;
            lista[5].text = seis;

            allTextDic.Add(dic);
        }

        return allTextDic;

    }

    public void Generar()
    {
        List<Dictionary<string, string>> allTextDic = parseFile();
        Dictionary<string, string> dic = allTextDic[0];
        GameObject nuevo;

        for (int i = 0; i < cantidad; i++)
        {
            nuevo = (GameObject)Instantiate(Prefab, transform);
            Text[] lista = nuevo.GetComponent<Image>().GetComponentsInChildren<Text>();
            lista[0].text = i.ToString() + "Nombre";
            lista[1].text = i.ToString() + "Resultado";
            lista[2].text = i.ToString() + "Tipo";
            lista[3].text = i.ToString() + "Puntuación propia";
            lista[4].text = i.ToString() + "Puntuación enemiga";
            lista[5].text = i.ToString() + "Fecha";
        }
    }
}

