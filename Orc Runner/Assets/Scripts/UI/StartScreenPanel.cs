using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenPanel : MonoBehaviour
{
    [SerializeField] private GameObject _exitConfirmationPanel;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _optionsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenExitConfirmationPanel()
    {
        _exitConfirmationPanel.SetActive(true);
    }

    public void OpenOptionsPanel()
    {
        _optionsPanel.SetActive(true);
    }
}
