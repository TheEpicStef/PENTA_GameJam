using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    bool isPaused = false;

    public LevelTransition transition;
    public AudioSource musicAudio;

    public GameObject PauseMenu;

    private void Awake()
    {
        transition = FindObjectOfType<LevelTransition>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = !isPaused ? 0 : 1;
            isPaused = !isPaused;
            if (isPaused)
            {
                PauseMenu.SetActive(true);
                musicAudio.Pause();
            }
            else
            {
                PauseMenu.SetActive(false);
                musicAudio.UnPause();
            }
        }
    }

    public void RestartLevel()
    {
        transition.DoTransition(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void GoToMenu()
    {
        transition.DoTransition("MainMenu");
        Time.timeScale = 1;
    }
}
