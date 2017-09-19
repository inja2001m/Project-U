using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : BaseBullet
{
    void FixedUpdate()
    {
        this.transform.Translate(Vector3.forward * m_Speed * Time.fixedDeltaTime);
    }
}
