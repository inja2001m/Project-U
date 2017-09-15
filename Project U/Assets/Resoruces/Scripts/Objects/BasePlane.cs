using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlane : MonoBehaviour
{
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

    protected virtual void Attack()
    {

    }

    protected virtual void Move()
    {

    }
}
