using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    private float _savedTimeScale;

    public void Open()
    {
        _savedTimeScale = Time.timeScale;
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
    }

    public void Close()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = _savedTimeScale;
    }
}