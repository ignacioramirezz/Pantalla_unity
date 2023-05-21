using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;

public class Boton : MonoBehaviour
{
    public Text textoPanel;
    private string urlBaseDatos;
    public string epica;

    // Metodo para cargar el texto de la base de datos
    private IEnumerator CargarTextoBaseDatos()
    {
        urlBaseDatos = $"http://localhost:8080/api/Epic/proyecto/{epica}";
        UnityWebRequest www = UnityWebRequest.Get(urlBaseDatos);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string texto = www.downloadHandler.text;
            darformato(texto);
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
        textoPanel.text = Texto_nuevo;
    }
}
