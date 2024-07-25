using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonSelect : MonoBehaviour
{
    private Image img;
    private RectTransform rect;
    private void Awake()
    {
        img = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        img.color = Color.white;
    }

    void CheckForSelect(ShopManager.ItemFunc item)
    {
        //if(ShopManager.GetInstance().selectedTransform == transform)
        //{
        //    img.color = Color.yellow;
        //} else
        //{
        //    img.color = Color.red;
        //}
    }

//    private void OnEnable()
//    {
//        ShopManager.onSelectItem += CheckForSelect;
//    }

//    private void OnDisable()
//    {
//        ShopManager.onSelectItem -= CheckForSelect;
//    }
}
