using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using Newtonsoft.Json;

public class Boton : MonoBehaviour
{
    public Text textoPanel;
    private string urlBaseDatos;
    public string epica;
    public Text id_1;
    public List<Epica> lista_epicas;

    // Metodo para cargar el texto de la base de datos
 
     IEnumerator CargarTextoBaseDatos()
    {
        urlBaseDatos = $"http://localhost:8080/api/Epic/proyecto/{epica}";
        UnityWebRequest www = UnityWebRequest.Get(urlBaseDatos);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string texto = www.downloadHandler.text;
            Debug.Log(texto);
            darformato(texto);
            lista_epicas= JsonConvert.DeserializeObject<List<Epica>>(texto);
          
            foreach (Epica epica in lista_epicas)
            {
                Debug.Log("ID: " + epica.id + ", nombre: " + epica.nombre);
            }
            completar();
        }
        else
        {
            Debug.Log(www.error);
        }
    }

    // Metodo para actualizar el texto en el panel
    public void ActualizarPanel()
    {
        StartCoroutine(CargarTextoBaseDatos());
    }

    public void completar()
    {
        int id = lista_epicas[0].id;
        string idStr = id.ToString();
        id_1.text = idStr;

    }

    private void darformato(string texto)
    {
        string Texto_nuevo = texto.Replace("}", "\n \n \n");
        Texto_nuevo = Texto_nuevo.Replace("{", " ");
        Texto_nuevo = Texto_nuevo.Replace("[", " ");
        Texto_nuevo = Texto_nuevo.Replace("]"," ");
        Texto_nuevo = Texto_nuevo.Replace( "${}" ," ");
        Texto_nuevo = Texto_nuevo.Replace(",","  ");
        Texto_nuevo = Texto_nuevo.Replace(":", ":  ");
        Texto_nuevo = Texto_nuevo.Replace(@"""", "");
        Texto_nuevo = Texto_nuevo.Replace("id:", " ");
        Texto_nuevo = Texto_nuevo.Replace("nombre:", " ");
        Texto_nuevo = Texto_nuevo.Replace("actor:", " ");
        Texto_nuevo = Texto_nuevo.Replace("valor:", " ");
        Texto_nuevo = Texto_nuevo.Replace("funcionabilidad:", " ");
        Texto_nuevo = Texto_nuevo.Replace("diferencia:", " ");
        Texto_nuevo = Texto_nuevo.Replace("mejora:", " ");
        Texto_nuevo = Texto_nuevo.Replace("cliente:", " ");
        //textoPanel.text = Texto_nuevo;

    }



    
}
