using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoTextDesc : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    [TextArea(3, 3)]
    public string[] strings;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }


    // Start is called before the first frame update
    void Start()
    {
        ClearText();
    }

    void ChangeText(ShopManager.Item item)
    {
        if((int)item < strings.Length)
        {
            tmp.text = strings[(int)item];
        }
    }

    void ClearText()
    {
        tmp.text = "";
    }

    private void OnEnable()
    {
        ShopManager.onSelectItem += ChangeText;
        ShopManager.onBuyItem += ClearText;
    }

    private void OnDisable()
    {
        ShopManager.onSelectItem -= ChangeText;
        ShopManager.onBuyItem -= ClearText;
    }
}
