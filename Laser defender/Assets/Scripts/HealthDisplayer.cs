using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayer : MonoBehaviour
{
    [SerializeField] Text displayer;

    private void Start()
    {

    }

    public void UpdateDisplayer(int health)
    {
        Debug.Log("udpate cs");
        displayer.text = $"health: {health}";
    }

}
