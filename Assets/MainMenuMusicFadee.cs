using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusicFadee : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeAudioSource.StartFade(audioSource, 2.5f, 0.18f));
    }

    public void FadeAway()
    {
        StartCoroutine(FadeAudioSource.StartFade(audioSource, 1.0f, 0.01f));
    }
}
