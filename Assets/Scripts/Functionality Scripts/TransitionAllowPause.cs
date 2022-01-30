using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAllowPause : MonoBehaviour
{
    /// <summary>
    /// PLEASE DO NOT ASK WHY I NEED THIS. I AM TOO LAZY TO FIX MY JANKNESS SO WE HAVE TO SUFFER :)
    /// </summary>

    public PauseGame pauseGame;
    // Start is called before the first frame update
    void Start()
    {
        pauseGame = FindObjectOfType<PauseGame>();
    }
    public void setPause()
    {
        if(pauseGame != null)
        {
            pauseGame.canPause = true;
        }
    }
}
