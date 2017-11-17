using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{
    private bool isFind;
    public bool m_IsFind
    {
        get
        {
            return this.isFind;
        }
    }

    void Start()
    {
        isFind = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isFind = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isFind = false;
        }
    }
}
