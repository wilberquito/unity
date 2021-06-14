using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject lanzador;

    public void SetLanzador(GameObject lanzador)
    {
        this.lanzador = lanzador;
    }

    public GameObject GetLanzador()
    {
        return this.lanzador;
    }
}
