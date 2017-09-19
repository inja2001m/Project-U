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
}
