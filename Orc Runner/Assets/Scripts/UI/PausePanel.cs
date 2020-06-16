using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private AudioMixerSnapshot _normal;
    [SerializeField] private AudioMixerSnapshot _pause;

    private float _savedTimeScale;

    public void Open()
    {
        _savedTimeScale = Time.timeScale;
        Time.timeScale = 0;
        _pausePanel.SetActive(true);

        _pause.TransitionTo(1f);
    }

    public void Close()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = _savedTimeScale;

        _normal.TransitionTo(1f);
    }
}