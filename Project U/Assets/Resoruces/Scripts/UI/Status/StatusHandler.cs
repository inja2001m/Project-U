using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Hp_Bar;
    private int m_CurrentHp;

    [SerializeField]
    private GameObject m_Sp_Bar;
    private float m_CurrentSp;

    [SerializeField]
    private PlayerPlane m_Player;

    void Start()
    {
        m_CurrentHp = m_Player.m_Hp;
        m_CurrentSp = m_Player.m_Sp;
    }

    void Update()
    {
        UpdateHpBar();
        UpdateSpBar();
    }

    void UpdateHpBar()
    {
        if (m_CurrentHp == m_Player.m_Hp)
            return;

        m_CurrentHp = m_Player.m_Hp;
        m_Hp_Bar.transform.localScale = new Vector3(m_CurrentHp / (float)m_Player.m_MaxHp, m_Hp_Bar.transform.localScale.y, m_Hp_Bar.transform.localScale.z);
    }
    void UpdateSpBar()
    {
        if (m_CurrentSp == m_Player.m_Sp)
            return;

        m_CurrentSp = m_Player.m_Sp;
        m_Sp_Bar.transform.localScale = new Vector3(m_CurrentSp / m_Player.m_MaxSp, m_Sp_Bar.transform.localScale.y, m_Sp_Bar.transform.localScale.z);
    }
}
