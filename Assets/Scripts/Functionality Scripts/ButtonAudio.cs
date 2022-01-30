using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ButtonAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public AudioMixer mixer;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
    }

    public void PressSound()
    {
        audioSource.PlayOneShot(audioClip, 0.1f);
    }
}
