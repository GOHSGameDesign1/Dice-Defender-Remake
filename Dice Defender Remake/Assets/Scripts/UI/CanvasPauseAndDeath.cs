using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPauseAndDeath : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject deathPanel;

    public float deathPointDuration;


    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        deathPanel.SetActive(false);
    }

    void Pause()
    {
        pausePanel.SetActive(true);
    }

    void Resume()
    {
        pausePanel.SetActive(false);
    }

    void EnableDeathPanel()
    {
        StartCoroutine(DeathPanel());
    }

    IEnumerator DeathPanel()
    {
        GameObject[] children = new GameObject[deathPanel.transform.childCount];
        for(int i = 0; i < deathPanel.transform.childCount; i++){
            deathPanel.transform.GetChild(i).gameObject.SetActive(false);
            children[i] = deathPanel.transform.GetChild(i).gameObject;
        }
        deathPanel.SetActive(true);

        children[0].SetActive(true);



        yield return new WaitForSeconds(deathPointDuration);

        for(int i = 1; i<= children.Length - 1; i++)
        {
            children[i].SetActive(true);
        }
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
