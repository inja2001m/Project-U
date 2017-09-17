using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButtonHandler : MonoBehaviour
{
    public enum AttackSkill_Type
    {
        NONE,
        NORMAL,
        SPECIAL
    }

    private AttackSkill_Type eAttackSkillType;
    public AttackSkill_Type m_eAttackSkillType
    {
        get
        {
            return this.eAttackSkillType;
        }
    }

    private bool m_IsOnlyOne;

    void Start()
    {
        m_IsOnlyOne = false;
        eAttackSkillType = AttackSkill_Type.NONE;
    }

    public void ClickedNormalAttack()
    {
        if (m_IsOnlyOne)
            return;

        eAttackSkillType = AttackSkill_Type.NORMAL;
        m_IsOnlyOne = true;
    }

    public void ClickedSpecialAttack()
    {
        if (m_IsOnlyOne)
            return;

        eAttackSkillType = AttackSkill_Type.SPECIAL;
        m_IsOnlyOne = true;
    }

    public void ClickedUpButton()
    {
        m_IsOnlyOne = false;
        eAttackSkillType = AttackSkill_Type.NONE;
    }
}
