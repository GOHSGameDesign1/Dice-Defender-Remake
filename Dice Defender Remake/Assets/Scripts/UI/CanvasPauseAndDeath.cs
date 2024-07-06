using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPauseAndDeath : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject deathPanel;


    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        deathPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Pause()
    {
        pausePanel.SetActive(true);
        
        for(int i = 0; i < pausePanel.transform.childCount; i++)
        {
            if(pausePanel.transform.GetChild(i).TryGetComponent(out PanelUIElement element))
            {
                Debug.Log("Found element");
                element.StartSpawnAnim();
            }
        }
    }

    void Resume()
    {
        pausePanel.SetActive(false);
    }

    void EnableDeathPanel()
    {
        deathPanel.SetActive(true);
    }

    private void OnEnable()
    {
        GameManager.onPause += Pause;
        GameManager.onUnPause += Resume;
        GameManager.onDeath += EnableDeathPanel;
    }

    private void OnDisable()
    {
        GameManager.onPause -= Pause;
        GameManager.onUnPause -= Resume;
        GameManager.onDeath -= EnableDeathPanel;
    }
}
