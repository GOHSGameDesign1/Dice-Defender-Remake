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

    [TextArea(5, 5)]
    [SerializeField] private string[] buyItemDialogue;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        scrollAmount = Mathf.Clamp(scrollAmount, 1, 200);
    }

    void StartSelectText(Item item)
    {
        StopAllCoroutines();
        StartCoroutine(ScrollText(item.Dialogue));
    }

    void StartBuyText()
    {
        if (buyItemDialogue.Length <= 0) return;

        int index = Random.Range(0, buyItemDialogue.Length);

        StartCoroutine(ScrollText(buyItemDialogue[index]));
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
        ShopManager.onBuyItem += StartBuyText;
    }

    private void OnDisable()
    {
        ShopManager.onSelectItem -= StartSelectText;
        ShopManager.onBuyItem -= StartBuyText;
    }
}
