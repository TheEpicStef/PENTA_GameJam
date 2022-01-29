using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EndLevel : MonoBehaviour
{
    // The Trigger to load the next level
    public Collider2D endTrigger;
    // The Level to load
    public string nextScene;

    public LevelTransition transition;

    void Awake()
    {
        endTrigger = GetComponent<Collider2D>();

        transition = FindObjectOfType<LevelTransition>();
    }

    // Will load the next scene
    // At the moment transition is instant. Added an animation and delay will make it feel nicer.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            transition.DoTransition(nextScene);
        }
    }
}
