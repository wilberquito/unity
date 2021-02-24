using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScene : MonoBehaviour
{
    // Start is called before the first frame update

    int min = 0;
    int max = 1000;
    int guess = -1;


    void Start()
    {

        Debug.Log($"Estado inicial => min: {this.min}, max: {this.max}");

        this.guess = this.halfOf(this.min, this.max);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log($"Current min value: {this.min}, current max value: {this.max}");
            Debug.Log($"Current middle value {this.guess}");

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                this.max = this.guess;
                this.guess = this.halfOf(this.min, this.max);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                this.min = this.guess;
                this.guess = this.halfOf(this.min, this.max);
            }
            else
            {
                Debug.Log("Key not controlled");
            }
        }
    }


    // a <= b
    int halfOf(int a, int b) => Mathf.RoundToInt((a + b) / 2);
}
