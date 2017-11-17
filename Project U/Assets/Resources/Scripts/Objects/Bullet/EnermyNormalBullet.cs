using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyNormalBullet : BaseBullet
{
    protected new float m_CurrentLifeTime
    {
        set
        {
            if(m_LifeTime <= value)
            {
                base.m_CurrentLifeTime = 0.0f;
                this.Die();
            }
            else
                base.m_CurrentLifeTime = value;
        }
        get
        {
            return base.m_CurrentLifeTime;
        }
    }

    void Start()
    {
        m_CurrentLifeTime = 0.0f;
    }

    void Update()
    {
        m_CurrentLifeTime += Time.deltaTime;
        Movement();
    }

    protected override void Movement()
    {
        this.transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
    }

    public override void Die()
    {
        this.gameObject.SetActive(false);
        BulletPoolManager.Instance.AddEnermyNormalBullet(this.gameObject);
    }
}
