using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] int health = 200;
    [SerializeField] float padding = 0.5f;
    [Header("Player projectile")]
    [SerializeField] GameObject lasser;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float blastPeriod = 0.1f;

    [SerializeField] SoundFxManager soundFxManager;

    Coroutine blastCoroutine;

    [Header("SFX")]
    [SerializeField] GameObject destroyAnimation;
    [Range(0f, 1f)] [SerializeField] float dieVolum = 1f;


    // class variables
    float minX, maxX;
    float minY, maxY;

    Level sceneLoader;


    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<Level>();
        SetEdges();
    }

    void SetEdges()
    {
        var camera = Camera.main;
        minX = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        minY = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // si el dealer que me llega es diferente al mio
        var dealer = other.gameObject.GetComponent<DemageDealer>();
        if (dealer)
        {
            Hit(dealer.Demage());
            Destroy(other.gameObject);
        }
    }


    private void Hit(int demage)
    {
        health -= demage;

        if (health <= 0)
        {
            LoadEndGame();
        }
    }

    private void LoadEndGame()
    {
        DestroyPlayer();
        sceneLoader.LoadGameOver();
    }

    private void DestroyPlayer()
    {
        var vfx = Instantiate(this.destroyAnimation, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(vfx, 1f);

        if (soundFxManager && soundFxManager.HeroDeathAudio)
        {
            soundFxManager.PlayClip(soundFxManager.HeroDeathAudio, Camera.main.transform.position, dieVolum);
        }
        else
        {
            Debug.LogError("Sound mananger may is not instantiated or the hero death audio is not added in sound manager");
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveEngine();
        Fire();
    }

    void Fire()
    {
        // miro que el fire1 este activo y comienza una
        // ejecucion infinita de la corritina de blast
        if (Input.GetButtonDown("Fire1"))
        {
            blastCoroutine = StartCoroutine(BlastCoroutine());
        }

        // la corutina cogida se elimina en caso de que el fire 1 no este activo
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(blastCoroutine);
        }
    }

    //ejecucion directa
    //await
    //ejecucuion despues del await
    IEnumerator BlastCoroutine()
    {
        while (true)
        {
            var laser = Instantiate(lasser, transform.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(blastPeriod);
        }
    }

    void MoveEngine()
    {
        // to make delta x independent from velocity of frames per second
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        // to make delta x independent from velocity of frames per second
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        if (deltaX != 0)
        {
            var x = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
            transform.position = new Vector2(x, transform.position.y);

        }
        if (deltaY != 0)
        {
            var y = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);
            transform.position = new Vector2(transform.position.x, y);

        }

        // logic to horizontal movement
    }
}
