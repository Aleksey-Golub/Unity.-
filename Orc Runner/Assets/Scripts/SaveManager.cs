using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public ShopManager ShopManager;
    public GameManager GameManager;

    string filePath;

    public static SaveManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);    // Destroy(this); может лучше так??
            return;
        }

        filePath = Application.persistentDataPath + "gamedata.gamesave";

        LoadGame();
        SaveGame();
    }

    public void LoadShop()
    {
        if (!File.Exists(filePath))
            return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);

        SaveData saveData = bf.Deserialize(fs) as SaveData;

        ShopManager.ActiveSkin = (PlayerSkinItem.ItemType)saveData.ActiveSkinIndex;

        for (int i = 0; i < saveData.BoughtPlayerSkin.Count; i++)
            ShopManager.PlayerSkinItems[i].IsBought = saveData.BoughtPlayerSkin[i];

        for (int i = 0; i < saveData.BoughtEnemy.Count; i++)
            ShopManager.EnemyItems[i].IsBought = saveData.BoughtEnemy[i];

        fs.Close();
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);

        SaveData saveData = new SaveData();

        saveData.Coins = GameManager.Coins;

        saveData.ActiveSkinIndex = (int)ShopManager.ActiveSkin;
        saveData.SaveBoughtPlayerSkin(ShopManager.PlayerSkinItems);
        saveData.SaveBoughtEnemy(ShopManager.EnemyItems);

        bf.Serialize(fs, saveData);
        fs.Close();
    }

    public void LoadGame()
    {
        if (!File.Exists(filePath))
            return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);

        SaveData saveData = bf.Deserialize(fs) as SaveData;

        ShopManager.ActiveSkin = (PlayerSkinItem.ItemType)saveData.ActiveSkinIndex;

        // загрузка купленных скинов в магазин
        for (int i = 0; i < saveData.BoughtPlayerSkin.Count; i++)
            ShopManager.PlayerSkinItems[i].IsBought = saveData.BoughtPlayerSkin[i];

        // загрузка купленных врагов в магазин
        for (int i = 0; i < saveData.BoughtEnemy.Count; i++)
            ShopManager.EnemyItems[i].IsBought = saveData.BoughtEnemy[i];

        // загрузка купленных врагов в GameManager
        for (int i = 0; i < saveData.BoughtEnemy.Count; i++)
            GameManager.Instance.IsBoughtEnemies[i] = saveData.BoughtEnemy[i];

        GameManager.AddCoins(saveData.Coins - GameManager.Coins);
        GameManager.ActiveSkinIndex = saveData.ActiveSkinIndex;

        fs.Close();
    }
}

[System.Serializable]
public class SaveData
{
    public int Coins;
    public int ActiveSkinIndex;     // сохраняет из ShopManager(т.к. устанавливается одновременно и в ShopManager, и в GameManager), загружает сразу в обоих
    public List<bool> BoughtPlayerSkin = new List<bool>();
    public List<bool> BoughtEnemy = new List<bool>();

    public void SaveBoughtPlayerSkin(List<PlayerSkinItem> items)
    {
        foreach (var item in items)
            BoughtPlayerSkin.Add(item.IsBought);
    }


    public void SaveBoughtEnemy(List<EnemyItem> items)
    {
        foreach (var item in items)
            BoughtEnemy.Add(item.IsBought);
    }
}
