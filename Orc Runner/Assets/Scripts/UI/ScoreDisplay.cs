using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreDisplay;

    private float _elapsedTime = 0;
    private int _score = 0;
    private int _scoreMultiplier = 1;

    public int Score => _score;

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            _elapsedTime += Time.deltaTime;
            _score = (int) _elapsedTime * 10 * _scoreMultiplier;
            _scoreDisplay.text = _score.ToString();

            switch (_score)
            {
                case 300:
                    GameManager.Instance.SavedTimeScale = 1.2f;
                    break;
                case 600:
                    GameManager.Instance.SavedTimeScale = 1.4f;
                    break;
                case 900:
                    GameManager.Instance.SavedTimeScale = 1.6f;
                    break;
                case 1200:
                    GameManager.Instance.SavedTimeScale = 1.8f;
                    break;
                case 1500:
                    GameManager.Instance.SavedTimeScale = 2.0f;
                    break;
                case 1800:
                    GameManager.Instance.SavedTimeScale = 2.2f;
                    break;
                case 2100:
                    GameManager.Instance.SavedTimeScale = 2.4f;
                    _scoreMultiplier = 2;
                    break;
                default:
                    break;
            }
        }
    }
}
