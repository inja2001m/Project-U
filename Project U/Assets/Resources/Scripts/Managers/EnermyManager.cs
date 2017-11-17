using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyManager : BaseSingleton<EnermyManager>
{
    [SerializeField]
    private GameObject m_Enermy;

    [SerializeField]
    private PlayerPlane m_Player;
    [SerializeField]
    private Transform m_PlayerTransform;

    [SerializeField]
    private int m_GenerateLength;
    [SerializeField]
    private float m_GerateRate;

    [SerializeField]
    private int m_FireEnermyMaxHp;

    private int currentFireEnermyAmount;
    public int m_CurrentFireEnermyAmount
    {
        set
        {
            if (EnermyPoolManager.Instance.m_FireEnermyAmount <= value)
            {
                this.currentFireEnermyAmount = EnermyPoolManager.Instance.m_FireEnermyAmount;
                this.isPossibleCreateFireEnermy = false;
            }
            else
            {
                this.currentFireEnermyAmount = value;
                this.isPossibleCreateFireEnermy = true;
            }
        }
        get
        {
            return this.currentFireEnermyAmount;
        }
    }

    private bool isPossibleCreateFireEnermy;
    public bool m_IsPossibleCreateFireEnermy
    {
        get
        {
            return isPossibleCreateFireEnermy;
        }
    }

    void Start()
    {
        m_CurrentFireEnermyAmount = 0;
        StartCoroutine(Gerate());
    }

    IEnumerator Gerate()
    {
        while (m_PlayerTransform != null)
        {
            yield return new WaitForSeconds(m_GerateRate);
            GenerateEnermy();
        }
    }

    void GenerateEnermy()
    {
        if (m_PlayerTransform == null || !m_IsPossibleCreateFireEnermy)
            return;

        ++m_CurrentFireEnermyAmount;

        Vector3 generatePosition = new Vector3(Random.Range(-180, 180), 0.0f, Random.Range(-180, 180));
        generatePosition.Normalize();
        generatePosition *= m_GenerateLength;

        GameObject obj = EnermyPoolManager.Instance.GetFireEnermy();
        obj.transform.position = m_PlayerTransform.position + generatePosition;
        obj.transform.LookAt(m_PlayerTransform);
        obj.GetComponent<FireEnermyMovement>().m_PlayerDirection = m_PlayerTransform;
        obj.GetComponent<BasePlane>().m_Hp = m_FireEnermyMaxHp;
        obj.SetActive(true);
    }
}
