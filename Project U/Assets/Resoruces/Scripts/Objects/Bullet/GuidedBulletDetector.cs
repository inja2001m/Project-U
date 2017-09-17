using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedBulletDetector : MonoBehaviour
{
    public GameObject m_Target;

    private bool m_IsFirst;

    void Start()
    {
        m_IsFirst = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enermy")
        {
            m_Target = other.gameObject;
            Destroy(this);
        }
    }
}
