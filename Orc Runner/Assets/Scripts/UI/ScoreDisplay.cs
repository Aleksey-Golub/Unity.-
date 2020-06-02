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

    public int Score => _score;

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            _elapsedTime += Time.deltaTime;
            _score = (int) _elapsedTime * 10;
            _scoreDisplay.text = _score.ToString();

            switch (_score)
            {
                case 300:
                    GameManager.Instance.SavedTimeScale = 1.1f;
                    break;
                case 600:
                    GameManager.Instance.SavedTimeScale = 1.2f;
                    break;
                case 900:
                    GameManager.Instance.SavedTimeScale = 1.3f;
                    break;
                case 1200:
                    GameManager.Instance.SavedTimeScale = 1.4f;
                    break;
                case 1500:
                    GameManager.Instance.SavedTimeScale = 1.5f;
                    break;
                default:
                    break;
            }
        }
    }
}
