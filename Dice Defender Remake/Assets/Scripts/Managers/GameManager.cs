using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public delegate void OnPause();
    public static event OnPause onPause;

    public delegate void OnUnPause();
    public static event OnUnPause onUnPause;

    public delegate void OnDeath();
    public static event OnDeath onDeath;

    private bool paused;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("Multiple GameManagers found in the scene!");
            Destroy(gameObject);
            return;
        }
        Instance = this;

        paused = false;
    }

    public static GameManager GetInstance()
    {
        return Instance;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        paused = true;
        Time.timeScale = 0f;
        onPause.Invoke();
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
        onUnPause.Invoke();
        paused = false;
    }

    public void GameOver()
    {
        Debug.Log("Game Over!!!");
        onDeath.Invoke();
    }

    public void Restart()
    {
        Debug.Log("Restarting Game...");
    }
}
