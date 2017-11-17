using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlane : BasePlane
{
    [SerializeField]
    private GameObject m_Explosion;

    private int maxHp;
    public int m_MaxHp
    {
        get
        {
            return this.maxHp;
        }
    }

    void Start()
    {
        this.maxHp = this.m_Hp;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enermy Normal Bullet")
        {
            this.GotDamage(other.GetComponent<BaseBullet>().m_Damage);
            other.GetComponent<EnermyNormalBullet>().Die();
        }
    }
    
    protected override void Die()
    {
        GameManager.Instance.m_IsGameOver = true;
        Instantiate(m_Explosion, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
