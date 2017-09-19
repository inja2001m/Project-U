using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowToPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform m_PlayerTrans;

    void FixedUpdate()
    {
        if (m_PlayerTrans == null)
        {
            Destroy(this);
            return;
        }

        this.transform.position = new Vector3(m_PlayerTrans.position.x, this.transform.position.y, m_PlayerTrans.position.z);
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, m_PlayerTrans.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z);
    }
}
