using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EndLevel : MonoBehaviour
{
    // The Trigger to load the next level
    public Collider2D endTrigger;
    // The Level to load
    public string nextScene;

    bool hasWon = false;

    public LevelTransition transition;

    public AudioSource birdSource;
    public AudioClip winAudio;
    public AudioSource playerSource;
    public AudioClip playerWin;

    public GameObject transitionAudioThingy;

    void Awake()
    {
        endTrigger = GetComponent<Collider2D>();

        transition = FindObjectOfType<LevelTransition>();

        playerSource = FindObjectOfType<PlayerController>().GetComponent<AudioSource>();
    }

    // Will load the next scene
    // At the moment transition is instant. Added an animation and delay will make it feel nicer.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            if (!hasWon)
            {
                birdSource.PlayOneShot(winAudio, 10.0f);
                hasWon = true;
                StartCoroutine(transitionDelay());//transition.DoTransition(nextScene);
            }
        }
    }

    IEnumerator transitionDelay()
    {
        yield return new WaitForSeconds(0.5f);
        playerSource.PlayOneShot(playerWin);
        yield return new WaitForSeconds(1.5f);
        Instantiate(transitionAudioThingy);
        yield return new WaitForSeconds(0.4f);
        transition.DoTransition(nextScene);
    }
}
