using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemTitleText : MonoBehaviour
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

    void ChangeText(Item item)
    {
        tmp.text = item.Title;
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
