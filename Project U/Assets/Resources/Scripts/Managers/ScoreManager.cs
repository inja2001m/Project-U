using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private string m_KeyString;

    [SerializeField]
    private Text m_BestScore;

    [SerializeField]
    private Text m_CurrentScore;
    
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        bool result = PlayerPrefs.HasKey(m_KeyString);

        if (!result)
            PlayerPrefs.SetInt(m_KeyString, DataManager.m_Score);
        else
        {
            int bestScore = PlayerPrefs.GetInt(m_KeyString, 0);

            if (bestScore < DataManager.m_Score)
                PlayerPrefs.SetInt(m_KeyString, DataManager.m_Score);
        }
        PlayerPrefs.Save();

        m_BestScore.text = PlayerPrefs.GetInt(m_KeyString, 0).ToString();
        m_CurrentScore.text = DataManager.m_Score.ToString();
    }
}
