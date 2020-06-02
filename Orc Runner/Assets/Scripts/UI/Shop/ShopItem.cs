using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ShopItem : MonoBehaviour
{
    [SerializeField] protected int Cost;
    [SerializeField] protected Button BuyButton;
    [SerializeField] protected ShopManager ShopManager;
    
    protected GameManager GameManager;

    public bool IsBought;

    public abstract void CheckButton();

    protected bool CanBuy()
    {
        return GameManager.Coins >= Cost;
    }

    public void InitGameManager()
    {
        GameManager = GameManager.Instance;
    }

    public void BuyItem()
    {
        if (CanBuy() == false)
            return;

        IsBought = true;
        GameManager.WithdrowCoins(Cost);

        RegisterPurchaseInGameManager();

        CheckButton();

        SaveManager.Instance.SaveGame();
    }

    protected virtual void RegisterPurchaseInGameManager()
    {
    }
}
