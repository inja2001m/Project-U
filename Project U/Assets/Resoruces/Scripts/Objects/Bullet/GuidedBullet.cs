using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedBullet : MonoBehaviour
{
    [SerializeField]
    public GameObject target;

    public float m_Speed;

    private int damage;
    public int m_Damage
    {
        get
        {
            return this.damage;
        }
    }

    void FixedUpdate()
    {
        this.transform.Translate(Vector3.forward * m_Speed * Time.fixedDeltaTime);
    }
}
