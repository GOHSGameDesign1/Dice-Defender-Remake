using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public List<Transform> boughtItems;

    private int selectedItemIndex;
    private Transform selectedTransform;

    public delegate void OnSelectItem(Item item);
    public static event OnSelectItem onSelectItem;

    public delegate void OnBuyItem();
    public static event OnBuyItem onBuyItem;

    public enum Item
    {
        DecreaseTimer1,
        AddSubTimerDecrease,
        ExplodePowerup
    }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static ShopManager GetInstance() { return instance; }

    // Start is called before the first frame update
    void Start()
    {
        DisablePurchasedItems();
        selectedItemIndex = -1;
        selectedTransform = null;
    }


    public void SelectItem(int item)
    {
        if (selectedItemIndex != item)
        {
            selectedItemIndex = item;
            onSelectItem((Item)selectedItemIndex);
        }
    }

    public void SelectItemTransform(Transform transform)
    {
        if(selectedTransform != transform)
        {
            selectedTransform = transform;
        }
    }

    public void BuyItem()
    {
        if(selectedItemIndex < 0)
        {
            return;
        }
        AddDisabledItem(selectedTransform);
        onBuyItem();
        DisablePurchasedItems();
        switch ((Item)selectedItemIndex)
        {
            case Item.DecreaseTimer1: // Decrease Dice Timer
                GameManager.GetInstance().stats.timerDecrease += 2;
                Debug.Log("Decreased Timer Length");
                break;
            case Item.AddSubTimerDecrease: // Adding/Subtracting decreases timer more
                break;
            case Item.ExplodePowerup: // Powerup 
                break;

            default:
                break;
        }
        selectedItemIndex = -1;
        selectedTransform = null;
    }

    public void AddDisabledItem(Transform item)
    {
        if (item == null) return;
        boughtItems.Add(item);
        DisablePurchasedItems();
    }

    void DisablePurchasedItems()
    {
        if (boughtItems.Count <= 0) return;
        foreach(Transform item in boughtItems)
        {
            item.gameObject.SetActive(false);
        }
    }
}
