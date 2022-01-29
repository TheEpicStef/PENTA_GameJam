using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1.0f;

    public bool startTransition = false;

    public PauseGame pauseGame;

    // Public function to handle the transition
    public void DoTransition(string _levelName)
    {
        // Will only activate once.
        if (!startTransition)
        {
            StartCoroutine(LoadLevel(_levelName));
            startTransition = true;
        }
    }

    IEnumerator LoadLevel(string _levelName)
    {
        transition.SetTrigger("Start");

        PauseGame pause = FindObjectOfType<PauseGame>();
        pause.canPause = false;

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(_levelName);
    }


}
