using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    private int damage;
    public int m_Damage
    {
        get
        {
            return this.damage;
        }
    }

    public float m_Speed;

    void FixedUpdate()
    {
        this.transform.Translate(Vector3.forward * m_Speed * Time.fixedDeltaTime);
    }
}
