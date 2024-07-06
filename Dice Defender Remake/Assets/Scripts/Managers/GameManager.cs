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

    void Pause()
    {
        paused = true;
        Time.timeScale = 0f;
        onPause.Invoke();
    }

    void UnPause()
    {
        Time.timeScale = 1f;
        onUnPause.Invoke();
        paused = false;
    }
}
