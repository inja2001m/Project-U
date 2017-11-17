using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyPoolManager : BaseSingleton<EnermyPoolManager>
{
    [SerializeField]
    private int fireEnermyAmount;
    public int m_FireEnermyAmount
    {
        get
        {
            return fireEnermyAmount;
        }
    }

    private GameObject m_FireEnermy;
    private List<GameObject> m_FireEnermyList;

    private GameObject m_FireEnermyPool;

    void Awake()
    {
        m_FireEnermy = Resources.Load("Prefabs/Enermies/Done_Enemy Ship") as GameObject;
    }

    void Start()
    {
        int i;

        m_FireEnermyList = new List<GameObject>();

        m_FireEnermyPool = new GameObject("FireEnermyPool");

        for (i = 0; i < m_FireEnermyAmount; ++i)
        {
            GameObject obj = CreateObject(m_FireEnermy);
            obj.transform.SetParent(m_FireEnermyPool.transform);
            m_FireEnermyList.Add(obj);
        }
    }

    GameObject CreateObject(GameObject _obj)
    {
        GameObject obj = Instantiate(_obj);
        obj.SetActive(false);
        return obj;
    }

    public GameObject GetFireEnermy()
    {
        GameObject obj;

        if (m_FireEnermyList.Count == 0)
        {
            obj = CreateObject(m_FireEnermy);
            m_FireEnermyList.Add(obj);
            m_FireEnermyList.RemoveAt(0);
            return obj;
        }

        obj = m_FireEnermyList[0];
        m_FireEnermyList.RemoveAt(0);
        return obj;
    }
    public void AddFireEnermy(GameObject _obj)
    {
        m_FireEnermyList.Add(_obj);
    }
}
