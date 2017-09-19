using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlane : MonoBehaviour
{
    [SerializeField]
    private int hp;
    public int m_Hp
    {
        set
        {
            this.hp = value;
        }
        get
        {
            return this.hp;
        }
    }

    [SerializeField]
    private float maxSp;
    public float m_MaxSp
    {
        get
        {
            return this.maxSp;
        }
    }

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
    private float maxSpeed;
    public float m_MaxSpeed
    {
        set
        {
            this.maxSpeed = value;
        }
        get
        {
            return this.maxSpeed;
        }
    }
    private float currentSpeed;
    public float m_CurrentSpeed
    {
        set
        {
            if (value >= m_MaxSpeed)
                this.currentSpeed = m_MaxSpeed;
            else
                this.currentSpeed = value;
        }
        get
        {
            return this.currentSpeed;
        }
    }

    [SerializeField]
    private float moveAcceleration;
    public float m_MoveAcceleration
    {
        set
        {
            this.moveAcceleration = value;
        }
        get
        {
            return this.moveAcceleration;
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

    protected virtual void Attack()
    {

    }

    protected virtual void Movement()
    {

    }

    protected virtual void Die()
    {

    }

    protected virtual void GotDamage(int _damage)
    {
        m_Hp -= _damage;
    }
}
