using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour
{
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private Slider _soundChangeSlider;

    private void Start()
    {
        _soundChangeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1);
    }

    public void Close()
    {
        _optionsPanel.SetActive(false);
    }

    public void ChangeVolume(float volume)
    {
        _audioMixerGroup.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));

        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
}
