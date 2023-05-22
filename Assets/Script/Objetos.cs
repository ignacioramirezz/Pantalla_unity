using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Epica
{
    public int id;
    public string nombre;
    public string actor;
    public string valor;
    public string funcionabilidad;
    public string diferencia;
    public string mejora;
    public string cliente;
}

[System.Serializable]
public class Epicas
{
    public Epica[] lista_epicas;
}

