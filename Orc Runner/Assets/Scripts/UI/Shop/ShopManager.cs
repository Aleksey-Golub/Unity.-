using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _skinsPanel;
    [SerializeField] private GameObject _enemiesPanel;
    [SerializeField] private Button _skinsBtn;
    [SerializeField] private Button _enemiesBtn;

    public List<PlayerSkinItem> PlayerSkinItems;
    public List<EnemyItem> EnemyItems;

    public PlayerSkinItem.ItemType ActiveSkin;

    private void Start()
    {
        GameManager.Instance.ShopManager = this;
        SaveManager.Instance.ShopManager = this;
        SaveManager.Instance.LoadShop();
        SaveManager.Instance.SaveGame();
    }

    public void Close()
    {
        _shopPanel.SetActive(false);
    }

    public void OpenShopPanel()
    {
        CheckItemButtons();
        _shopPanel.SetActive(true);
    }

    public void CheckItemButtons()
    {
        foreach (PlayerSkinItem item in PlayerSkinItems)
        {
            item.InitGameManager();
            item.CheckButton();
        }

        foreach (EnemyItem item in EnemyItems)
        {
            item.InitGameManager();
            item.CheckButton();
        }
    }
    public void OpenSkinPanel()
    {
        _enemiesPanel.SetActive(false);
        _skinsPanel.SetActive(true);
        _skinsBtn.interactable = false;
        _enemiesBtn.interactable = true;
    }

    public void OpenEnemiesPanel()
    {
        _enemiesPanel.SetActive(true);
        _skinsPanel.SetActive(false);
        _skinsBtn.interactable = true;
        _enemiesBtn.interactable = false;
    }
}
