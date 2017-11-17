using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlane : MonoBehaviour
{
    [SerializeField]
    private int hp;
    public int m_Hp
    {
        set
        {
            if (value <= 0)
            {
                this.hp = 0;
                this.Die();
            }
            else
                this.hp = value;
        }
        get
        {
            return this.hp;
        }
    }

    protected abstract void Die();

    protected void GotDamage(int _damage)
    {
        m_Hp -= _damage;
    }
}
