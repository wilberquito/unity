using UnityEngine;
using System.Collections;


public class Enemy : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] int health = 100;
    [SerializeField] float minTimeShots = 0.2f;
    [SerializeField] float maxTimeShots = 1f;
    [SerializeField] float laserSpeed = 4f;
    [SerializeField] int reward = 1;

    [Header("Cached objects")]
    [SerializeField] GameObject laser;

    [Header("SFX")]
    [SerializeField] GameObject destroyAnimation;
    [SerializeField] SoundFxManager soundFxManager;
    [SerializeField] [Range(0f, 1f)] float dieVolum = 1f;
    [SerializeField] [Range(0f, 1f)] float shootVolum = 1f;

    float countDown;

    void Start()
    {
        countDown = Random.Range(minTimeShots, maxTimeShots);
    }

    private void Update()
    {
        TriggerFire();
    }

    private void TriggerFire()
    {
        countDown -= Time.deltaTime;

        if (countDown <= 0)
        {
            var trigger = Random.Range(0, 2) == 0;
            if (trigger)
            {
                StartCoroutine(Fire());
            }
            countDown = Random.Range(minTimeShots, maxTimeShots);
        }
    }
    IEnumerator Fire()
    {
        var laser = Instantiate(this.laser, gameObject.transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -laserSpeed);

        if (soundFxManager && soundFxManager.EnemyShootingAudio)
        {
            soundFxManager.PlayClip(soundFxManager.EnemyShootingAudio, Camera.main.transform.position, shootVolum);
        }

        yield return new WaitForSeconds(0.1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var laser = other.gameObject.GetComponent<DemageDealer>();
        if (laser)
        {
            health -= laser.Demage();
            if (health <= 0)
            {
                UpdatePlayerScore();
                DestroyEnemy();
            }
        }
    }

    private void UpdatePlayerScore() {
        var gameScore = FindObjectOfType<GameScore>();
        gameScore.IncreaseScore(reward);
    }

    private void DestroyEnemy()
    {
        var vfx = Instantiate(this.destroyAnimation, gameObject.transform.position, Quaternion.identity);

        if (soundFxManager && soundFxManager.EnemyDeathAudio)
        {
            soundFxManager.PlayClip(soundFxManager.EnemyDeathAudio, Camera.main.transform.position, dieVolum);
        }
        else
        {
            Debug.LogError("Sound mananger may is not instantiated or the enemy death audio is not added in sound manager");
        }
        Destroy(gameObject);
        Destroy(vfx, 1f);
    }

}