using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSingleton : MonoBehaviour
{
    private void Awake() {
        var audios = FindObjectsOfType<AudioSource>();

        if (audios.Length > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            // dont destroy on load es una () => 
            // que al cargar una nueva scene el objeto no sea destruido
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
