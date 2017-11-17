using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaseMovement
{
    [SerializeField]
    private float m_MaxCorneringSpeed;

    [SerializeField]
    public float m_CorneringAcceleration;

    [SerializeField]
    private MoveButtonHandler m_MoveButtonHandler;

    private float corneringSpeed;
    private float m_CorneringSpeed
    {
        set
        {
            if (value >= m_MaxCorneringSpeed)
                this.corneringSpeed = m_MaxCorneringSpeed;
            else if (value <= -m_MaxCorneringSpeed)
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
    }

    void FixedUpdate()
    {
        Movement();
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
}
