using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonManager : MonoBehaviour
{
    public void ClickedStartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ClickedQuitButton()
    {
        Application.Quit();
    }
}
