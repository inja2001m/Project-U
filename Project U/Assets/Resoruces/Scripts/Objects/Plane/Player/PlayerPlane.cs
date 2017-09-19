using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlane : BasePlane
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
    private float GuidedAttackDelayTime;
    public float m_GuidedAttackDelayTime
    {
        set
        {
            this.GuidedAttackDelayTime = value;
        }
        get
        {
            return this.GuidedAttackDelayTime;
        }
    }

    [SerializeField]
    private float m_MaxCorneringSpeed;

    [SerializeField]
    public float m_CorneringAcceleration;  

    [SerializeField]
    private MoveButtonHandler m_MoveButtonHandler;

    [SerializeField]
    public AttackTypeButtonHandler m_AttackTypeButtonHandler;

    [SerializeField]
    private AttackButtonHandler m_AttackButtonHandler;

    [SerializeField]
    public Transform m_CameraPosition;

    [SerializeField]
    public Transform m_BulletSpawn;

    [SerializeField]
    public GameObject m_NormalBullet;

    [SerializeField]
    public GameObject m_GuidedBullet;

    [SerializeField]
    private GameObject m_Explosion;

    [SerializeField]
    private GameObject m_SpecialAttackExplosion;

    [SerializeField]
    private GameManager m_GameManager;

    private float currentAttackDelayTime;
    protected new float m_CurrentAttackDelayTime
    {
        set
        {
            switch(m_AttackTypeButtonHandler.m_eAttackType)
            {
                case AttackTypeButtonHandler.Attack_Type.NORMAL:
                    if (value >= this.m_NormalAttackDelayTime)
                        this.currentAttackDelayTime = m_NormalAttackDelayTime;
                    else
                        this.currentAttackDelayTime = value;
                    break;

                case AttackTypeButtonHandler.Attack_Type.GUIDED:
                    if (value >= this.m_GuidedAttackDelayTime)
                        this.currentAttackDelayTime = m_GuidedAttackDelayTime;
                    else
                        this.currentAttackDelayTime = value;
                    break;
            }
        }
        get
        {
            return this.currentAttackDelayTime;
        }
    }

    public new bool m_IsFire
    {
        get
        {
            switch (m_AttackTypeButtonHandler.m_eAttackType)
            {
                case AttackTypeButtonHandler.Attack_Type.NORMAL:
                    if (m_CurrentAttackDelayTime >= m_NormalAttackDelayTime)
                    {
                        m_CurrentAttackDelayTime -= m_NormalAttackDelayTime;
                        return true;
                    }
                    break;

                case AttackTypeButtonHandler.Attack_Type.GUIDED:
                    if (m_CurrentAttackDelayTime >= m_GuidedAttackDelayTime)
                    {
                        m_CurrentAttackDelayTime -= m_GuidedAttackDelayTime;
                        return true;
                    }
                    break;
            }
            return false;
        }
    }

    private float corneringSpeed;
    private float m_CorneringSpeed
    {
        set
        {
            if (value >= m_MaxCorneringSpeed)
                this.corneringSpeed = m_MaxCorneringSpeed;
            else if(value <= -m_MaxCorneringSpeed)
                this.corneringSpeed = -m_MaxCorneringSpeed;
            else
                this.corneringSpeed = value;
        }
        get
        {
            return this.corneringSpeed;
        }
    }

    private float Sp;
    public float m_Sp
    {
        set
        {
            if (value >= this.m_MaxSp)
            {
                this.Sp = this.m_MaxSp;
                this.m_IsReadySpecialAttack = true;
            }
            else
                this.Sp = value;
        }
        get
        {
            return this.Sp;
        }
    }

    private int maxHp;
    public int m_MaxHp
    {
        get
        {
            return this.maxHp;
        }
    }

    private bool m_IsReadySpecialAttack;
    private bool isOnSpecialAttack;
    public bool m_IsOnSpecialAttack
    {
        set
        {
            this.isOnSpecialAttack = value;
        }
        get
        {
            return this.isOnSpecialAttack;
        }
    }

    private float specialAttackDurationTime;
    private float m_SpecialAttackDurationTime
    {
        set
        {
            if (value >= 1.0f)
            {
                this.specialAttackDurationTime = 0.0f;
                m_IsOnSpecialAttack = false;
            }
            else
                this.specialAttackDurationTime = value;
        }
        get
        {
            return this.specialAttackDurationTime;
        }
    }

    void Start()
    {
        maxHp = m_Hp;
        m_SpecialAttackDurationTime = 0.0f;
        m_CurrentSpeed = 0.0f;
        m_CurrentAttackDelayTime = 0.0f;
        m_Sp = 0.0f;
        m_IsReadySpecialAttack = false;
        m_IsOnSpecialAttack = false;
    }

    void Update()
    {
        m_Sp += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if(m_IsOnSpecialAttack)
            m_SpecialAttackDurationTime += Time.fixedDeltaTime;

        switch (m_AttackButtonHandler.m_eAttackSkillType)
        {
            case AttackButtonHandler.AttackSkill_Type.NONE: break;
            case AttackButtonHandler.AttackSkill_Type.NORMAL: Attack(); break;
            case AttackButtonHandler.AttackSkill_Type.SPECIAL: SpecialAttack(); break;
        }
        
        Movement();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enermy Bullet")
        {
            GotDamage(other.GetComponent<BaseBullet>().m_Damage);
            Destroy(other.gameObject);
        }
    }

    private void FireNormalBullet()
    {
        GameObject obj = Instantiate(m_NormalBullet, m_BulletSpawn.position, this.transform.rotation);
        obj.GetComponent<BaseBullet>().m_Speed = m_MaxSpeed * 2.0f;
        obj.GetComponent<BaseBullet>().m_Damage = m_AttackDamage;
    }

    private void FireGuidedBullet()
    {
        GameObject obj = Instantiate(m_GuidedBullet, m_BulletSpawn.position, this.transform.rotation);
        obj.GetComponent<BaseBullet>().m_Speed = m_MaxSpeed * 2.0f;
        obj.GetComponent<BaseBullet>().m_Damage = m_AttackDamage * 2;
    }

    private void SpecialAttack()
    {
        if (!m_IsReadySpecialAttack)
            return;

        m_Sp = 0.0f;
        m_IsReadySpecialAttack = false;
        m_IsOnSpecialAttack = true;

        Instantiate(m_SpecialAttackExplosion, this.transform);
    }

    protected override void Attack()
    {
        m_CurrentAttackDelayTime += Time.fixedDeltaTime;

        if (!m_IsFire)
            return;

        switch(m_AttackTypeButtonHandler.m_eAttackType)
        {
            case AttackTypeButtonHandler.Attack_Type.NORMAL: FireNormalBullet();  break;
            case AttackTypeButtonHandler.Attack_Type.GUIDED: FireGuidedBullet(); break;
            default: break;
        }
    }

    protected override void Movement()
    {
        m_CurrentSpeed += m_MoveAcceleration;
        this.transform.Translate(Vector3.forward * m_CurrentSpeed * Time.fixedDeltaTime);

        if (m_MoveButtonHandler.m_ePadDirection == MoveButtonHandler.Button_Direction.NO_TOUCH)
            m_CorneringSpeed = Mathf.LerpAngle(m_CorneringSpeed, 0.0f, 0.1f);
        else
            m_CorneringSpeed += m_CorneringAcceleration * (int)m_MoveButtonHandler.m_ePadDirection;
        
        this.transform.Rotate(new Vector3(0.0f, m_CorneringSpeed, 0.0f));
    }

    protected override void Die()
    {
        m_GameManager.m_IsGameOver = true;
        Instantiate(m_Explosion, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

    protected override void GotDamage(int _damage)
    {
        m_Hp -= _damage;
    }
}
