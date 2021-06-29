using UnityEngine;
using System.Collections;


public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] float minTimeShots = 0.2f;
    [SerializeField] float maxTimeShots = 1f;
    [SerializeField] GameObject laser;
    [SerializeField] float laserSpeed = 4f;

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

        if (soundFxManager && soundFxManager.EnemyShootingAudio) {
            soundFxManager.PlayClip(soundFxManager.EnemyShootingAudio, gameObject.transform.position, shootVolum);
        }

        yield return new WaitForSeconds(0.1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var laser = other.gameObject.GetComponent<DemageDealer>();
        if (laser)
        {
            Hit(laser.Demage());
            Destroy(other.gameObject);
        }
    }

    private void Hit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        var vfx = Instantiate(this.destroyAnimation, gameObject.transform.position, Quaternion.identity);
        if (soundFxManager && soundFxManager.EnemyDeathAudio)
        {
            soundFxManager.PlayClip(soundFxManager.EnemyDeathAudio, gameObject.transform.position, dieVolum);
        }
        else
        {
            Debug.LogError("Sound mananger may is not instantiated or the enemy death audio is not added in sound manager");
        }
        Destroy(gameObject);
        Destroy(vfx,1f);
    }

}
