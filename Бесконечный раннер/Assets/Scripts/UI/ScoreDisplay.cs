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

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            _elapsedTime += Time.deltaTime;
            _score = (int) _elapsedTime * 10;
            _scoreDisplay.text = _score.ToString();
        }
    }
}
