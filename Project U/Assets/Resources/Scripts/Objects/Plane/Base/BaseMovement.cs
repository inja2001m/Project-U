using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed;
    public float m_MaxSpeed
    {
        set
        {
            this.maxSpeed = value;
        }
        get
        {
            return this.maxSpeed;
        }
    }
    private float currentSpeed;
    public float m_CurrentSpeed
    {
        set
        {
            if (value >= m_MaxSpeed)
                this.currentSpeed = m_MaxSpeed;
            else
                this.currentSpeed = value;
        }
        get
        {
            return this.currentSpeed;
        }
    }

    [SerializeField]
    private float moveAcceleration;
    public float m_MoveAcceleration
    {
        set
        {
            this.moveAcceleration = value;
        }
        get
        {
            return this.moveAcceleration;
        }
    }

    protected abstract void Movement();
}
