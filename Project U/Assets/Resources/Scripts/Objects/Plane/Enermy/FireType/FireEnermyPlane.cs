using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnermyPlane : BasePlane
{
    [SerializeField] private GameObject m_Explosion;

    void Update()
    {
        if (GameManager.Instance.m_IsGameOver)
            DieMyself();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player Normal Bullet")
        {
            GotDamage(other.GetComponent<BaseBullet>().m_Damage);
            other.GetComponent<PlayerNormalBullet>().Die();
        }
        else if(other.tag == "Player Guided Bullet")
        {
            GotDamage(other.GetComponent<BaseBullet>().m_Damage);
            other.GetComponent<PlayerGuidedBullet>().Die();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player Spacial Attack Boundary") && 
            GameManager.Instance.m_IsOnSpecialAttack)
            Die();
    }

    private void DieMyself()
    {
        Instantiate(m_Explosion, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

    protected override void Die()
    {
        Instantiate(m_Explosion, this.transform.position, this.transform.rotation);
        this.gameObject.SetActive(false);
        DataManager.m_Score += 100;
        EnermyManager.Instance.m_CurrentFireEnermyAmount -= 1;
        EnermyPoolManager.Instance.AddFireEnermy(this.gameObject);
    }
}
