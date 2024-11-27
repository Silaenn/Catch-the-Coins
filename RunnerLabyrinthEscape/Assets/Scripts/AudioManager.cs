using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource GameOver;

    public AudioClip background;
    public AudioClip Scoring;
    public AudioClip Shield;
    public AudioClip Boom;
    public AudioClip Overs;

    private void Start() {
        MusicSource.clip = background;
        MusicSource.Play();
    }

    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }

     public void Over(AudioClip clip){
        GameOver.PlayOneShot(clip);
    }
}
