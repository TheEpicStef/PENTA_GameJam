using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public bool canPause = false;
    bool isPaused = false;

    public LevelTransition transition;
    public AudioSource musicAudio;

    public GameObject PauseMenu;

    public bool PAUSEOVERRIDE = false;

    private void Awake()
    {
        transition = FindObjectOfType<LevelTransition>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PAUSEOVERRIDE) return;
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (!canPause) return;
            Time.timeScale = !isPaused ? 0 : 1;
            isPaused = !isPaused;
            if (isPaused)
            {
                Cursor.visible = true;
                PauseMenu.SetActive(true);
                musicAudio.Pause();
            }
            else
            {
                Cursor.visible = false;
                PauseMenu.SetActive(false);
                musicAudio.UnPause();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
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
