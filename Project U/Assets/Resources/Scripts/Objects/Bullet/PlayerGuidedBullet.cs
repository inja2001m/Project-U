using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuidedBullet : BaseBullet
{
    [SerializeField]
    private GameObject m_Detector;

    [HideInInspector]
    public GameObject m_Target = null;

    protected new float m_CurrentLifeTime
    {
        set
        {
            if (m_LifeTime <= value)
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
    
    private Vector3 m_MoveDirection;

    void Start()
    {
        m_MoveDirection = Vector3.forward;
        m_CurrentLifeTime = 0.0f;
    }

    void Update()
    {
        m_CurrentLifeTime += Time.deltaTime;
        Movement();
    }

    protected override void Movement()
    {
        if (m_Target != null)
        {
            Vector3 tempTargetDirection = 
                (m_Target.transform.position - this.transform.position);
            m_MoveDirection += tempTargetDirection;
            this.transform.LookAt(m_MoveDirection);
        }
        this.transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
    }

    public override void Die()
    {
        this.gameObject.SetActive(false);
        m_Detector.SetActive(true);
        BulletPoolManager.Instance.AddPlayerGuidedBullet(this.gameObject);
    }
}
