using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item")]
public class Item : ScriptableObject
{
    public ShopManager.ItemFunc func;

    public int price;

    public string Title;
    public string Description;

    [TextArea(5, 5)]
    public string Dialogue;
}
