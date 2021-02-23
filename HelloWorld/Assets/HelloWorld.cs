using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int min = 1;
        int max = 100;

        Debug.Log("Welcome to number wizard, yo");
        Debug.Log("Number Wizard");
        Debug.Log($"Smallest number you can pick is {min}");
        Debug.Log($"Biggest number you can pick is {max}");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("UpArrow key press");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("DownArrow key press");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter key press");
        }

    }
}
