using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnermyPlane : BasePlane
{
    [SerializeField]
    public new int m_Hp
    {
        set
        {
            if (value <= 0)
            {
                base.m_Hp = 0;
                this.Die();
            }
            else
                base.m_Hp = value;
        }
        get
        {
            return base.m_Hp;
        }

    }

    [SerializeField]
    private FireBoundary m_FireBoundary;

    [SerializeField]
    private Transform m_BulletSpawn;

    [SerializeField]
    private GameObject m_Bullet;

    [SerializeField]
    private GameObject m_Explosion;

    private PlayerPlane player;
    public PlayerPlane m_Player
    {
        set
        {
            this.player = value;
        }
        get
        {
            return this.player;
        }
    }

    private Transform playerDirection;
    public Transform m_PlayerDirection
    {
        set
        {
            this.playerDirection = value;
        }
        get
        {
            return this.playerDirection;
        }
    }

    private Vector3 m_MoveDirection;
    
    void Start()
    {
        m_CurrentSpeed = 0.0f;
        m_CurrentAttackDelayTime = 0.0f;
        m_MoveDirection = Vector3.zero;
    }

    void FixedUpdate()
    {
        m_CurrentAttackDelayTime += Time.fixedDeltaTime;
        if (m_PlayerDirection == null)
        {
            Die();
            return;
        }

        Movement();
        if (m_FireBoundary.m_IsCollision)
            Attack();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player Bullet")
        {
            GotDamage(other.GetComponent<BaseBullet>().m_Damage);
            Destroy(other.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player Spacial Attack Boundary" && m_Player.m_IsOnSpecialAttack)
            GotDamage(m_Hp);
    }

    protected override void Attack()
    {
        if (!m_IsFire)
            return;

        GameObject obj = Instantiate(m_Bullet, m_BulletSpawn.position, m_BulletSpawn.rotation);
        obj.GetComponent<BaseBullet>().m_Speed = m_MaxSpeed * 2.0f;
        obj.GetComponent<BaseBullet>().m_Damage = m_AttackDamage;
    }

    protected override void Movement()
    {
        Vector3 tempTargetDirection = (m_PlayerDirection.position - this.transform.position);
        m_MoveDirection += tempTargetDirection * 2.0f;
        this.transform.LookAt(m_MoveDirection);

        m_CurrentSpeed += m_MoveAcceleration;
        this.transform.Translate(Vector3.forward * m_CurrentSpeed * Time.fixedDeltaTime);
    }

    protected override void Die()
    {
        Instantiate(m_Explosion, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

    protected override void GotDamage(int _damage)
    {
        m_Hp -= _damage;
    }
}
