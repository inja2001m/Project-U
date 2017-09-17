using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlane : BasePlane
{
    [SerializeField]
    private MoveButtonHandler m_MoveButtonHandler;

    [SerializeField]
    public AttackTypeButtonHandler m_AttackTypeButtonHandler;

    [SerializeField]
    private AttackButtonHandler m_AttackButtonHandler;

    [SerializeField]
    public float m_RotateAcceleration;

    [SerializeField]
    public Transform m_CameraPosition;

    [SerializeField]
    public Transform m_BulletSpawn;

    [SerializeField]
    public GameObject m_Bullet;

    private const float m_MaxCorneringSpeed = 10.0f;

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

    private float corneringSpeed;
    public float m_CorneringSpeed
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

    void Start()
    {
        m_CurrentSpeed = 0.0f;
        m_CurrentAttackDelayTime = 0.0f;
    }

    void FixedUpdate()
    {
        switch(m_AttackButtonHandler.m_eAttackSkillType)
        {
            case AttackButtonHandler.AttackSkill_Type.NONE: break;
            case AttackButtonHandler.AttackSkill_Type.NORMAL: Attack(); break;
            case AttackButtonHandler.AttackSkill_Type.SPECIAL: SpecialAttack(); break;
        }
        
        Movement();
    }

    void OnTriggerEnter(Collider other)
    {

    }

    private void FireNormalBullet()
    {
        GameObject obj = Instantiate(m_Bullet, m_BulletSpawn.position, this.transform.rotation);
        obj.GetComponent<NormalBullet>().m_Speed = m_MaxSpeed * 2.0f;
    }

    private void FireGuidedBullet()
    {
        Debug.Log("Fire Guided Bullet");
    }

    private void SpecialAttack()
    {
        
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
        m_CurrentSpeed = m_CurrentSpeed + m_MoveAcceleration;
        this.transform.Translate(Vector3.forward * m_CurrentSpeed * Time.fixedDeltaTime);

        if (m_MoveButtonHandler.m_ePadDirection == MoveButtonHandler.Button_Direction.NO_TOUCH)
            m_CorneringSpeed = Mathf.LerpAngle(m_CorneringSpeed, 0.0f, 0.1f);
        else
            m_CorneringSpeed = m_CorneringSpeed + m_RotateAcceleration * (int)m_MoveButtonHandler.m_ePadDirection;
        
        this.transform.Rotate(new Vector3(0.0f, m_CorneringSpeed, 0.0f));
    }

    protected override void Die()
    {

    }

    protected override void GotDamage(int _damage)
    {
        m_Hp = m_Hp - _damage;
    }
}
