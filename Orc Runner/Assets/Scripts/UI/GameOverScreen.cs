using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private Button _bonusCoinsButton;
    [SerializeField] private Button _withoutBonusButton;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _textCoinsForRound;
    [SerializeField] private ScoreDisplay _scoreDisplay;
    
    private AdsForGold _adsForGold;
    private Animator _bonusCoinsButtonAnimator;

    private int _addingCoins = 0;

    private void Awake()
    {
        _adsForGold = FindObjectOfType<AdsForGold>();
        _bonusCoinsButtonAnimator = _bonusCoinsButton.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _player.Died += OnDied;
        _bonusCoinsButton.onClick.AddListener(OnBonusCoinsButtonClick);
        _withoutBonusButton.onClick.AddListener(OnWithoutBonusButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _bonusCoinsButton.onClick.RemoveListener(OnBonusCoinsButtonClick);
        _withoutBonusButton.onClick.RemoveListener(OnWithoutBonusButtonClick);
    }

    private void OnDied()
    {
        StartCoroutine(OnDiedCor());
        ViewAddingCoins();
    }

    IEnumerator OnDiedCor()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1f);
        _gameOverScreen.SetActive(true);
        
        if (_adsForGold.AdsIsReady)
        {
            _bonusCoinsButtonAnimator.SetTrigger("AdsIsReady");
            _bonusCoinsButton.interactable = true;
        }
    }

    private void ViewAddingCoins()
    {
        _addingCoins = _scoreDisplay.Score / 100;
        _textCoinsForRound.text = _addingCoins.ToString();
    }

    private void OnBonusCoinsButtonClick()
    {
        _adsForGold.ShowAds();
        GameManager.Instance.AddCoins(_addingCoins * 3);

        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnWithoutBonusButtonClick()
    {
        GameManager.Instance.AddCoins(_addingCoins);

        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}