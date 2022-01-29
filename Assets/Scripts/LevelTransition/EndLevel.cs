using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    // The Trigger to load the next level
    public Collider2D endTrigger;
    // The Level to load
    public string nextScene;

    void Awake()
    {
        endTrigger = GetComponent<Collider2D>();
    }

    // Will load the next scene
    // At the moment transition is instant. Added an animation and delay will make it feel nicer.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
