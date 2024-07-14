using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WizardDialogue : MonoBehaviour
{

    private TextMeshProUGUI tmp;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartSelectText(ShopManager.Item item)
    {
        string chosenText = "";

        switch(item)
        {
            default:
                break;
        }
    }

    IEnumerator ScrollText(string targetText)
    {
        ClearText();
        char[] chars = targetText.ToCharArray();

        foreach (char c in chars)
        {
            tmp.text += c;
            yield return null;
        }
    }

    void ClearText()
    {
        tmp.text = "";
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
