using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedBackground : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float backgroundScrollSpeed = 0.3f;
    Material material;
    Vector2 offset;


    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(0,backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset = material.mainTextureOffset + offset*Time.deltaTime;
    }
}
