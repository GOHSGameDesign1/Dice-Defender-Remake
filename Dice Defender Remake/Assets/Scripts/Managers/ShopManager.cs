using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public List<Transform> boughtItems;

    private int selectedItemIndex;
    public Item selectedItem {  get; private set; }
    public Transform selectedTransform { get; private set; }

    public delegate void OnSelectItem(Item item);
    public static event OnSelectItem onSelectItem;

    public delegate void OnBuyItem();
    public static event OnBuyItem onBuyItem;

    public enum ItemFunc
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

    public void SelectItem(Item item)
    {
        if(selectedItem != null)
        {
            if (selectedItem == item) return;
        }

        selectedItem = item;
        onSelectItem(selectedItem);

    }

    public void SelectItemTransform(Transform transform)
    {
        if(selectedTransform != transform)
        {
            if (selectedTransform != null)
            {
                if (selectedTransform.TryGetComponent(out Image img))
                {
                    img.color = Color.white;
                }
            }
            selectedTransform = transform;
            if (selectedTransform.TryGetComponent(out Image newImg))
            {
                newImg.color = Color.yellow;
            }
        }
    }

    public void BuyItem()
    {
        if(selectedItem == null)
        {
            return;
        }

        if(GameManager.GetInstance().stats.storedMoney < selectedItem.price)
        {
            Debug.Log("Not Enough Money!!");
            return;
        }

        AddDisabledItem(selectedTransform);
        onBuyItem();
        DisablePurchasedItems();

        GameManager.GetInstance().stats.storedMoney -= selectedItem.price;

        switch (selectedItem.func)
        {
            case ItemFunc.DecreaseTimer1: // Decrease Dice Timer
                GameManager.GetInstance().stats.timerDecrease += 2;
                Debug.Log("Decreased Timer Length");
                break;
            case ItemFunc.ExplodePowerup: // Powerup 
                Debug.Log("Bought PowerUp");
                break;
            case ItemFunc.AddSubTimerDecrease: // Adding/Subtracting decreases timer more
                GameManager.GetInstance().stats.addSubtractDeacrease += 2;
                Debug.Log("Bought Cooler Math");
                break;
            default:
                break;
        }
        selectedItem = null;
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
