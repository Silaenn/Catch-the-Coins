using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;

    public AudioClip Scoring;


    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
}
