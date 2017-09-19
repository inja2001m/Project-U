using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Enermy;

    [SerializeField]
    private PlayerPlane m_Player;

    [SerializeField]
    private Transform m_PlayerTrans;

    [SerializeField]
    private int m_GenerateLength;

    [SerializeField]
    private float m_GerateRate;
    private float currentRateTime;
    private float m_CurrentRateTime
    {
        set
        {
            if (value >= m_GerateRate)
            {
                this.currentRateTime -= m_GerateRate;
                Generate();
            }
            else
                this.currentRateTime = value;
        }
        get
        {
            return this.currentRateTime;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        m_CurrentRateTime += Time.deltaTime;
    }

    void Generate()
    {
        if (m_PlayerTrans == null)
            return;

        Vector3 generatePosition = new Vector3(
            Random.Range((int)m_PlayerTrans.position.x - m_GenerateLength, (int)m_PlayerTrans.position.x + m_GenerateLength),
            0.0f,
            Random.Range((int)m_PlayerTrans.position.z - m_GenerateLength, (int)m_PlayerTrans.position.z + m_GenerateLength)
            );
        Quaternion generateDirection = Quaternion.Euler(m_PlayerTrans.position - this.transform.position);

        GameObject obj = Instantiate(m_Enermy, generatePosition, generateDirection);
        FireEnermyPlane tempScript = obj.GetComponent<FireEnermyPlane>();
        tempScript.m_PlayerDirection = m_PlayerTrans;
        tempScript.m_Player = m_Player;
    }
}
