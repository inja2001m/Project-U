using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : BaseAttack
{
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
    private float maxSp;
    public float m_MaxSp
    {
        get
        {
            return this.maxSp;
        }
    }

    [SerializeField] public Transform m_BulletSpawn;

    [SerializeField] private AttackButtonHandler m_AttackButtonHandler;
    [SerializeField] public AttackTypeButtonHandler m_AttackTypeButtonHandler;

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

    private float sp;
    public float m_Sp
    {
        set
        {
            if (value >= this.m_MaxSp)
            {
                this.sp = this.m_MaxSp;
                this.m_IsReadySpecialAttack = true;
            }
            else
                this.sp = value;
        }
        get
        {
            return this.sp;
        }
    }

    private float _currentAttackDelayTime;
    protected new float m_CurrentAttackDelayTime
    {
        set
        {
            switch (m_AttackTypeButtonHandler.m_eAttackType)
            {
                case AttackTypeButtonHandler.Attack_Type.NORMAL:
                    if (value >= this.m_NormalAttackDelayTime)
                        this._currentAttackDelayTime = m_NormalAttackDelayTime;
                    else
                        this._currentAttackDelayTime = value;
                    break;

                case AttackTypeButtonHandler.Attack_Type.GUIDED:
                    if (value >= this.m_GuidedAttackDelayTime)
                        this._currentAttackDelayTime = m_GuidedAttackDelayTime;
                    else
                        this._currentAttackDelayTime = value;
                    break;
            }
        }
        get
        {
            return this._currentAttackDelayTime;
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
                GameManager.Instance.m_IsOnSpecialAttack = false;
            }
            else
                this.specialAttackDurationTime = value;
        }
        get
        {
            return this.specialAttackDurationTime;
        }
    }

    private bool m_IsReadySpecialAttack;

    private float m_BulletSpeed;

    void Start()
    {
        m_Sp = 0.0f;
        m_SpecialAttackDurationTime = 0.0f;
        m_CurrentAttackDelayTime = 0.0f;
        m_IsReadySpecialAttack = false;
        m_BulletSpeed = this.GetComponent<PlayerMovement>().m_MaxSpeed;
    }

    void Update()
    {
        m_Sp += Time.deltaTime;

        if (GameManager.Instance.m_IsOnSpecialAttack)
            m_SpecialAttackDurationTime += Time.fixedDeltaTime;

        switch (m_AttackButtonHandler.m_eAttackSkillType)
        {
            case AttackButtonHandler.AttackSkill_Type.NONE: break;
            case AttackButtonHandler.AttackSkill_Type.NORMAL: NormalAttack(); break;
            case AttackButtonHandler.AttackSkill_Type.SPECIAL: SpecialAttack(); break;
        }
    }

    private void FireNormalBullet()
    {
        GameObject obj = BulletPoolManager.Instance.GetPlayerNormalBullet();
        obj.transform.position = m_BulletSpawn.position;
        obj.transform.rotation = this.transform.rotation;
        obj.GetComponent<BaseBullet>().m_Speed = m_BulletSpeed * 2.0f;
        obj.GetComponent<BaseBullet>().m_Damage = m_AttackDamage;
        obj.SetActive(true);
    }

    private void FireGuidedBullet()
    {
        GameObject obj = BulletPoolManager.Instance.GetPlayerGuidedBullet();
        obj.transform.position = m_BulletSpawn.position;
        obj.transform.rotation = this.transform.rotation;
        obj.GetComponent<BaseBullet>().m_Speed = m_BulletSpeed * 2.0f;
        obj.GetComponent<BaseBullet>().m_Damage = m_AttackDamage * 2;
        obj.SetActive(true);
    }

    private void SpecialAttack()
    {
        if (!m_IsReadySpecialAttack)
            return;

        m_Sp = 0.0f;
        m_IsReadySpecialAttack = false;
        GameManager.Instance.m_IsOnSpecialAttack = true;
        GameManager.Instance.m_IsOnEffect = true;
        this.GetComponent<AudioSource>().Play();
    }

    protected override void NormalAttack()
    {
        m_CurrentAttackDelayTime += Time.fixedDeltaTime;

        if (!m_IsFire)
            return;

        switch (m_AttackTypeButtonHandler.m_eAttackType)
        {
            case AttackTypeButtonHandler.Attack_Type.NORMAL: FireNormalBullet(); break;
            case AttackTypeButtonHandler.Attack_Type.GUIDED: FireGuidedBullet(); break;
            default: break;
        }
    }
}
;