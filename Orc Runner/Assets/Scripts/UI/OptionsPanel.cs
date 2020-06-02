using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsPanel : MonoBehaviour
{
    [SerializeField] private GameObject _optionsPanel;
    public void Close()
    {
        _optionsPanel.SetActive(false);
    }
}
