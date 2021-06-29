using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sound fx manager")]
public class SoundFxManager : ScriptableObject
{
    [SerializeField] AudioClip heroShootingAudio;
    [SerializeField] AudioClip heroDeathAudio;
    [SerializeField] AudioClip enemyShootingAudio;
    [SerializeField] AudioClip enemyDeathAudio;

    public AudioClip HeroShootingAudio { get => heroShootingAudio; set => heroShootingAudio = value; }
    public AudioClip HeroDeathAudio { get => heroDeathAudio; set => heroDeathAudio = value; }
    public AudioClip EnemyShootingAudio { get => enemyShootingAudio; set => enemyShootingAudio = value; }
    public AudioClip EnemyDeathAudio { get => enemyDeathAudio; set => enemyDeathAudio = value; }


    public void PlayClip(AudioClip clip, Vector3 position, float volumen = 1f) {
        AudioSource.PlayClipAtPoint(clip, position, volumen);
    }
}
