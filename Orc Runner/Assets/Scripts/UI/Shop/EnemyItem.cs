using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyItem : ShopItem
{
    public enum ItemType
    {
        FirstKnight,
        SecondKnight,
        ThirdKnight
    }

    [SerializeField] private GameObject _objectCoin;
    [SerializeField] private TMP_Text _textCost;

    public ItemType Type;

    protected override void RegisterPurchaseInGameManager()
    {
        GameManager.Instance.IsBoughtEnemies[(int)Type] = true;
    }

    public override void CheckButton()
    {
        if (IsBought)
        {
            BuyButton.interactable = false;
            _objectCoin.SetActive(false);
            _textCost.text = "Owned";

        }
        else if (CanBuy())
        {
            BuyButton.interactable = true;
            _objectCoin.SetActive(true);
            _textCost.text = Cost.ToString();
        }
        else
        {
            BuyButton.interactable = false;
            _objectCoin.SetActive(true);
            _textCost.text = Cost.ToString();
        }
    }
}
