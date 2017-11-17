using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedBulletDetector : MonoBehaviour
{
    [SerializeField]
    private PlayerGuidedBullet m_Bullet;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Enermy"))
        {
            m_Bullet.m_Target = other.gameObject;
            this.gameObject.SetActive(false);
        }
    }
}
