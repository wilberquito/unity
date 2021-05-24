using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockComponent : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject destroyAnimation;
    [SerializeField] Sprite[] sprites;

    TrackerComponents tracker;

    int hitsReseived = 0;



    private void Start()
    {
        tracker = FindObjectOfType<TrackerComponents>();

        if (gameObject.tag == "Breakable")
        {
            tracker.AddBlock();
        }

    }

    public void RunAnimation(GameObject animation, Vector3 position)
    {
        Instantiate(animation, position, Quaternion.identity);
    }

    private void PlayClip(AudioClip clip, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(clip, position);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (gameObject.tag == "Breakable")
        {
            hitsReseived++;
            PlayClip(breakSound, Camera.main.transform.position);

            int maxHits = sprites.Length + 1;
            if (hitsReseived >= maxHits)
            {
                RunAnimation(destroyAnimation, gameObject.transform.position);
                Destroy(gameObject, 0f);

                tracker.SubstractBlock();
            }
            else
            {
                NextHitSprite(hitsReseived);
            }
        }
    }

    private void NextHitSprite(int hitsReceived)
    {
        if (hitsReceived >= 1 && hitsReceived <= sprites.Length)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[hitsReceived - 1];
        }
        else if (hitsReseived >= 1 && sprites.Length > 0)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[sprites.Length - 1];
        }
        else
        {   
            Debug.LogError($"The object; {gameObject.name}, has no sprites to use");
        }
    }

}

