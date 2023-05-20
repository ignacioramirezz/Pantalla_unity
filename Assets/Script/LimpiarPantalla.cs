using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimpiarPantalla : MonoBehaviour
{
    public Text textPanel;

    // Start is called before the first frame update
    private void Start() 
    {
        if (textPanel != null)
        {
            textPanel = GameObject.Find("textPanel").GetComponent<Text>();
        }
      
    }

    // Update is called once per frame
    public void borrarTexto()
    {
        textPanel.text = "Ninguna Epica";
    }
}
