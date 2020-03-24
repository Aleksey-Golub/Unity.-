using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _gameStartGroup;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    public event UnityAction StartButtonClicked;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    void Start()
    {
        _gameStartGroup = GetComponent<CanvasGroup>();
        _gameStartGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnStartButtonClick()
    {
        Time.timeScale = 1;
        _gameStartGroup.alpha = 0;
        StartButtonClicked?.Invoke();
        gameObject.SetActive(false);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
