using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttack : MonoBehaviour
{
    [SerializeField]
    private int attackDamage;
    public int m_AttackDamage
    {
        set
        {
            this.attackDamage = value;
        }
        get
        {
            return this.attackDamage;
        }
    }

    [SerializeField]
    private float normalAttackDelayTime;
    public float m_NormalAttackDelayTime
    {
        set
        {
            this.normalAttackDelayTime = value;
        }
        get
        {
            return this.normalAttackDelayTime;
        }
    }

    private float currentAttackDelayTime;
    protected float m_CurrentAttackDelayTime
    {
        set
        {
            if (value >= this.m_NormalAttackDelayTime)
                this.currentAttackDelayTime = this.m_NormalAttackDelayTime;
            else
                this.currentAttackDelayTime = value;
        }
        get
        {
            return this.currentAttackDelayTime;
        }
    }

    public bool m_IsFire
    {
        get
        {
            if (m_CurrentAttackDelayTime >= m_NormalAttackDelayTime)
            {
                m_CurrentAttackDelayTime -= m_NormalAttackDelayTime;
                return true;
            }

            return false;
        }
    }

    protected abstract void NormalAttack();
}
