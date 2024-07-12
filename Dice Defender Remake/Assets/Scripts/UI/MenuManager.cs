using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject titlePanel;
    public GameObject standbyePanel;
    public GameObject shopPanel;
    public GameObject optionsPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleTitlePanel()
    {
        titlePanel.SetActive(!titlePanel.activeInHierarchy);
    }

    public void ToggleStandbyePanel()
    {
        standbyePanel.SetActive(!standbyePanel.activeInHierarchy);
    }

    public void ToggleShopPanel()
    {
        shopPanel.SetActive(!shopPanel.activeInHierarchy);
    }

    public void ToggleOptionsPanel()
    {
        optionsPanel.SetActive(!optionsPanel.activeInHierarchy);
    }
}
