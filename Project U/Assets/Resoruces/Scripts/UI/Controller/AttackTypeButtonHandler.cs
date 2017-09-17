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

    void Start()
    {
        eAttackType = Attack_Type.NORMAL;
    }

    public void ClickUpNormalType()
    {
        eAttackType = Attack_Type.NORMAL;
    }

    public void ClickUpGuidedType()
    {
        eAttackType = Attack_Type.GUIDED;
    }
}
