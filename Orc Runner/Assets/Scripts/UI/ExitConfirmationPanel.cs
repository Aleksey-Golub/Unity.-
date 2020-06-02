using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitConfirmationPanel : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR
        Debug.Log("Exit");
#endif
        Application.Quit();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
