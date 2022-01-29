using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeAudio : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying)
        {
            Destroy(this);
        }
    }
}
