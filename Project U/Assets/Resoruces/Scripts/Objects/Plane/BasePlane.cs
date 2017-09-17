using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlane : MonoBehaviour
{
    [SerializeField]
    private int attPower;
    public int m_AttPower
    {
        set
        {
            this.attPower = value;
        }
        get
        {
            return this.attPower;
        }
    }

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
    private int armour;
    public int m_Armour
    {
        set
        {
            this.armour = value;
        }
        get
        {
            return this.armour;
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
    private float attackDelayTime;
    public float m_AttackDelayTime
    {
        set
        {
            this.attackDelayTime = value;
        }
        get
        {
            return this.attackDelayTime;
        }
    }

    private float currentAttackDelayTime;
    protected float m_CurrentAttackDelayTime
    {
        set
        {
            if (value >= this.m_AttackDelayTime)
                this.currentAttackDelayTime = this.m_AttackDelayTime;
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
            if (m_CurrentAttackDelayTime >= m_AttackDelayTime)
            {
                m_CurrentAttackDelayTime -= m_AttackDelayTime;
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
