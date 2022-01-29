using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherAudio : MonoBehaviour
{
    public AudioClip motherAudio;
    public AudioSource audioSource;

    public float cooDelay;
    public float cooTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        GetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        cooTimer += Time.deltaTime;

        if (cooTimer >= cooDelay)
        {
            cooTimer = 0.0f;
            audioSource.PlayOneShot(motherAudio);

            GetRandomTime();
        }
    }

    void GetRandomTime()
    {
        cooDelay = Random.Range(2.0f, 10.0f);
    }
}
