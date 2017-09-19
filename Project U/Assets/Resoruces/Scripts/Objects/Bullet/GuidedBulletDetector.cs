using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedBulletDetector : MonoBehaviour
{
    private GameObject target;
    public GameObject m_Target
    {
        get
        {
            return this.target;
        }
    }

    public bool isFind;

    void Start()
    {
        isFind = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enermy")
        {
            isFind = true;
            target = other.gameObject;
        }
    }
}
