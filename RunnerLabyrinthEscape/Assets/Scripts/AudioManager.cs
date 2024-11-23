using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;

    public AudioClip Scoring;
    public AudioClip Shield;
    public AudioClip Boom;



    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
}
