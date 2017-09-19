using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    private bool isGameOver;
    public bool m_IsGameOver
    {
        set
        {
            this.isGameOver = value;
        }
        get
        {
            return this.isGameOver;
        }
    }

    private float sceneChangeTime;
    private float m_SceneChangeTime
    {
        set
        {
            if (value >= 3.0f)
                GoToResultScene();
            else
                this.sceneChangeTime = value;
        }
        get
        {
            return this.sceneChangeTime;
        }
    }

    void Start()
    {
        m_IsGameOver = false;
        m_SceneChangeTime = 0.0f;
    }

    void Update()
    {
        if (m_IsGameOver)
            m_SceneChangeTime += Time.deltaTime;
    }

    void GoToResultScene()
    {
        SceneManager.LoadScene("Result");
    }
}
