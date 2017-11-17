using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnermyAttack : BaseAttack
{
    [SerializeField] private FireBoundary m_FireBoundary;

    [SerializeField] private Transform m_BulletSpawn;

    private float m_BulletSpeed;

    void Start()
    {
        m_CurrentAttackDelayTime = 0.0f;
        m_BulletSpeed = this.GetComponent<FireEnermyMovement>().m_MaxSpeed;
    }

    void Update()
    {
        m_CurrentAttackDelayTime += Time.deltaTime;

        if (m_FireBoundary.m_IsCollision)
            NormalAttack();
    }

    protected override void NormalAttack()
    {
        if (!m_IsFire)
            return;

        GameObject obj = BulletPoolManager.Instance.GetEnermayNormalBullet();
        obj.transform.position = m_BulletSpawn.position;
        obj.transform.rotation = this.transform.rotation;
        obj.GetComponent<BaseBullet>().m_Speed = m_BulletSpeed * 2.0f;
        obj.GetComponent<BaseBullet>().m_Damage = m_AttackDamage;
        obj.SetActive(true);
    }
}
