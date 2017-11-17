using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusHandler : MonoBehaviour
{
    [SerializeField]
    private Slider m_HP_Bar;
    private int m_CurrentHp;

    [SerializeField]
    private Slider m_SP_Bar;
    private float m_CurrentSp;

    [SerializeField] private PlayerPlane m_PlayerScript;
    [SerializeField] private PlayerAttack m_PlayerAttackScript;

    void Start()
    {
        m_CurrentHp = m_PlayerScript.m_Hp;
        m_CurrentSp = m_PlayerAttackScript.m_Sp;
    }

    void Update()
    {
        if (GameManager.Instance.m_IsGameOver)
        {
            m_HP_Bar.value = 0.0f;
            return;
        } 

        UpdateHpBar();
        UpdateSpBar();
    }

    void UpdateHpBar()
    {
        if (m_CurrentHp == m_PlayerScript.m_Hp)
            return;

        m_CurrentHp = m_PlayerScript.m_Hp;
        m_HP_Bar.value = m_CurrentHp / (float)m_PlayerScript.m_MaxHp;
    }
    void UpdateSpBar()
    {
        if (m_CurrentSp == m_PlayerAttackScript.m_Sp)
            return;

        m_CurrentSp = m_PlayerAttackScript.m_Sp;
        m_SP_Bar.value = m_CurrentSp / m_PlayerAttackScript.m_MaxSp;
    }
}
