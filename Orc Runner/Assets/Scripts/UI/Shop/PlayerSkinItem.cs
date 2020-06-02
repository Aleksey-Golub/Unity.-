using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkinItem : ShopItem
{
    public enum ItemType
    {
        FirstSkin,
        SecondSkin,
        ThirdSkin
    }

    [SerializeField] private Button _activateButton;
    private bool _isActive => Type == ShopManager.ActiveSkin;

    public ItemType Type;

    public override void CheckButton()
    {
        BuyButton.gameObject.SetActive(!IsBought);
        BuyButton.interactable = CanBuy();
        BuyButton.gameObject.GetComponentInChildren<TMP_Text>().text = Cost.ToString();

        _activateButton.gameObject.SetActive(IsBought);
        _activateButton.interactable = !_isActive;
        _activateButton.gameObject.GetComponentInChildren<TMP_Text>().text = _isActive ? "Using" : "Use";
    }

    public void ActivateItem()
    {
        ShopManager.ActiveSkin = Type;
        ShopManager.CheckItemButtons();

        switch (Type)
        {
            case ItemType.FirstSkin:
                GameManager.ActiveSkinIndex = 0;
                break;
            case ItemType.SecondSkin:
                GameManager.ActiveSkinIndex = 1;
                break;
            case ItemType.ThirdSkin:
                GameManager.ActiveSkinIndex = 2;
                break;
            default:
                break;
        }

        SaveManager.Instance.SaveGame();
    }
}
