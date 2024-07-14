using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoTextDesc : MonoBehaviour
{
    private TextMeshProUGUI tmp;

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
        Debug.Log("Called");
        switch (item)
        {
            case (ShopManager.Item.DecreaseTimer1):
                tmp.text = "Decrease dice refresh timer by 2 seconds.";
                break;
            default:
                break;
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
