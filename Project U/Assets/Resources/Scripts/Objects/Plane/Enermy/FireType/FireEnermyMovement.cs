using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnermyMovement : BaseMovement
{
    [HideInInspector] public Transform m_PlayerDirection;

    private Vector3 m_MoveDirection;

    void Start()
    {
        m_MoveDirection = Vector3.zero;
    }

    void FixedUpdate()
    {
        Movement();
    }

    void OnDisable()
    {
        m_MoveDirection = Vector3.zero;
    }

    protected override void Movement()
    {
        Vector3 tempTargetDirection = (m_PlayerDirection.position - this.transform.position);
        m_MoveDirection += tempTargetDirection * 2.0f;
        this.transform.LookAt(m_MoveDirection);

        m_CurrentSpeed += m_MoveAcceleration;
        this.transform.Translate(Vector3.forward * m_CurrentSpeed * Time.fixedDeltaTime);
    }
}
