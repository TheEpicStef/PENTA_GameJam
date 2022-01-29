using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1.0f;

    public bool startTransition = false;

    public void DoTransition(string _levelName)
    {
        if (!startTransition)
        {
            StartCoroutine(LoadLevel(_levelName));
            startTransition = true;
        }
    }

    IEnumerator LoadLevel(string _levelName)
    {
        Debug.Log("Yes");
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(_levelName);
    }
}
