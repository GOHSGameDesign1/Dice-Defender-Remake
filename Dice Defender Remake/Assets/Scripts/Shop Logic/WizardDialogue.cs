using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WizardDialogue : MonoBehaviour
{

    private TextMeshProUGUI tmp;

    [SerializeField] private float scrollDelta; // Delta between two different scrolls
    [SerializeField] private int scrollAmount; // How many characters scrolled through

    [TextArea(5, 5)]
    [SerializeField] private string[] selectItemDialogue;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        scrollAmount = Mathf.Clamp(scrollAmount, 1, 200);
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

        if ((int)item < selectItemDialogue.Length)
        {
            chosenText = selectItemDialogue[(int)item];
        }
        StopAllCoroutines();
        StartCoroutine(ScrollText(chosenText));
    }

    IEnumerator ScrollText(string targetText)
    {
        ClearText();
        char[] chars = targetText.ToCharArray();
        WaitForSeconds waitTime = new WaitForSeconds(scrollDelta);

        for(int i = 0; i < chars.Length; i += scrollAmount)
        {
            for(int j  = 0; j < scrollAmount; j++)
            {
                if (i + j >= chars.Length) break;
                tmp.text += chars[i + j];
            }
            yield return waitTime;
        }
    }

    void ClearText()
    {
        tmp.text = "";
    }

    private void OnEnable()
    {
        ShopManager.onSelectItem += StartSelectText;
    }

    private void OnDisable()
    {
        ShopManager.onSelectItem -= StartSelectText;
    }
}
