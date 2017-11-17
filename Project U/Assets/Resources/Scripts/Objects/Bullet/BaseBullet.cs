using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    public float m_Speed;

    private int damage;
    public int m_Damage
    {
        set
        {
            this.damage = value;
        }
        get
        {
            return this.damage;
        }
    }

    [SerializeField]
    private float lifeTime;
    protected float m_LifeTime
    {
        get
        {
            return this.lifeTime;
        }
    }
    private float currentLifeTime;
    protected float m_CurrentLifeTime
    {
        set
        {
            this.currentLifeTime = value;
        }
        get
        {
            return this.currentLifeTime;
        }
    }

    protected virtual void Movement()
    {

    }

    public virtual void Die()
    {

    }
}
