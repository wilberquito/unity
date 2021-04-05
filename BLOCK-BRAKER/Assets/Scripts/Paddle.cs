using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minUnits = 0f;
    [SerializeField] float maxUnits = 16f;

    [SerializeField] float widthUnits = 16f;
    [SerializeField] float height = 0.25f;


    // Start is called before the first frame update
    void Start()
    {
        float x = Input.mousePosition.x / Screen.width * widthUnits;
        x = Mathf.Clamp(x, minUnits, maxUnits);
        SetPosition(x, height);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.mousePosition.x / Screen.width * widthUnits;
        x = Mathf.Clamp(x, minUnits, maxUnits);
        SetPosition(x, height);
    }

    void SetPosition(float x, float y)
    {
        Vector2 pos = new Vector2(x, y);
        transform.position = pos;
    }
}
