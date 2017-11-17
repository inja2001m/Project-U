using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField]
    public float m_LifeTime;

    void Start()
    {
        Destroy(gameObject, m_LifeTime);
    }
}
