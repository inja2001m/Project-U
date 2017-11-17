using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoundary : MonoBehaviour
{
    private bool isCollision;
    public bool m_IsCollision
    {
        get
        {
            return this.isCollision;
        }
    }

    void Start()
    {
        isCollision = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isCollision = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isCollision = false;
        }
    }
}
