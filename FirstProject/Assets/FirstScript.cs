using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScrispt : MonoBehaviour
{

    /// <summary>
    /// inicialización de variables
    /// </summary>
    /// 

    int min = 1;
    int max = 1000;

    // Start is called before the first frame update
    void Start()
    {


        Debug.Log($"First state => min: {this.min}, max: {this.max}");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
