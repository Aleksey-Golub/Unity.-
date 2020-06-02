using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsDisplay : MonoBehaviour
{
    private TMP_Text _text;

    private void OnEnable()
    {
        GameManager.CoinsChanged += OnCoinsChanged;
    }

    private void OnDisable()
    {
        GameManager.CoinsChanged -= OnCoinsChanged;
    }

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        OnCoinsChanged();
    }

    private void OnCoinsChanged()
    {
        _text.text = GameManager.Instance.Coins.ToString();
    }
}
