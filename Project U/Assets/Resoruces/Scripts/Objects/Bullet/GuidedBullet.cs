using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedBullet : BaseBullet
{
    [SerializeField]
    private GuidedBulletDetector m_Detector;

    private GameObject m_Target;

    private Vector3 m_MoveDirection;

    void Start()
    {
        m_MoveDirection = Vector3.forward;
    }

    void FixedUpdate()
    {
        if (m_Detector != null && m_Detector.isFind)
        {
            m_Target = m_Detector.m_Target;
            Destroy(m_Detector);
        }
        else if(m_Detector == null && m_Target != null)
        {
            Vector3 tempTargetDirection = (m_Target.transform.position - this.transform.position);
            m_MoveDirection += tempTargetDirection;
            this.transform.LookAt(m_MoveDirection);
        }

        this.transform.Translate(Vector3.forward * m_Speed * Time.fixedDeltaTime);
    }
}
