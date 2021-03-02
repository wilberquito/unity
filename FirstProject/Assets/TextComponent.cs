using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextComponent : MonoBehaviour
{

    [SerializeField] Text titleText;

    // Start is called before the first frame update
    void Start()
    {
        this.titleText.text = "This is the new title!";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
