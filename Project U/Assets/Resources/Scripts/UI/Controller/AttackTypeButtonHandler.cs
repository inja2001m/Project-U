using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTypeButtonHandler : MonoBehaviour
{
    public enum Attack_Type
    {
        NORMAL,
        GUIDED
    }
    
    private Attack_Type eAttackType;
    public Attack_Type m_eAttackType
    {
        get
        {
            return this.eAttackType;
        }
    }

    [SerializeField] private GameObject m_NormalTypePanel;
    [SerializeField] private GameObject m_GuidedTypePanel;

    void Start()
    {
        eAttackType = Attack_Type.NORMAL;
        m_NormalTypePanel.SetActive(true);
        m_GuidedTypePanel.SetActive(false);
    }

    public void ClickUpNormalType()
    {
        eAttackType = Attack_Type.NORMAL;
        m_NormalTypePanel.SetActive(true);
        m_GuidedTypePanel.SetActive(false);
    }

    public void ClickUpGuidedType()
    {
        eAttackType = Attack_Type.GUIDED;
        m_NormalTypePanel.SetActive(false);
        m_GuidedTypePanel.SetActive(true);
    }
}
