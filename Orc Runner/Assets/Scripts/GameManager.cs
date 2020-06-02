using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _coins = 10;

    [HideInInspector] public float SavedTimeScale;
    /// <summary>
    /// список, куплены ли враги в магазине
    /// </summary>
    public List<bool> IsBoughtEnemies;

    public static GameManager Instance;
    public int Coins => _coins;
    public int ActiveSkinIndex = 0;
    public ShopManager ShopManager;

    public static event UnityAction CoinsChanged;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
    }

    public void AddCoins(int num)
    {
        _coins += num;

        CoinsChanged?.Invoke();
    }

    public void WithdrowCoins(int num)
    {
        if (_coins >= num)
            _coins -= num;

        CoinsChanged?.Invoke();
    }
}
