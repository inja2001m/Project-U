using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : BaseSingleton<BulletPoolManager>
{
    [SerializeField]
    private int m_PlayerNormalBulletAmount;
    private GameObject m_PlayerNormalBullet;
    private List<GameObject> m_PlayerNormalBulletList; 
    
    [SerializeField]
    private int m_PlayerGuidedBulletAmount;
    private GameObject m_PlayerGuidedBullet;
    private List<GameObject> m_PlayerGuidedBulletList;
    
    [SerializeField]
    private int m_EnermyNormalBulletAmount;
    private GameObject m_EnermyNormalBullet;
    private List<GameObject> m_EnermyNormalBulletList;

    private GameObject m_PlayerNormalBulletPool;
    private GameObject m_PlayerGuidedBulletPool;
    private GameObject m_EnermyNormalBulletPool;

    void Awake()
    {
        m_PlayerNormalBullet = Resources.Load("Prefabs/Bullets/PlayerNormalBullet") as GameObject;
        m_PlayerGuidedBullet = Resources.Load("Prefabs/Bullets/PlayerGuidedBullet") as GameObject;
        m_EnermyNormalBullet = Resources.Load("Prefabs/Bullets/EnermyBullet") as GameObject;
    }

    void Start()
    {
        int i;

        m_PlayerNormalBulletList = new List<GameObject>();
        m_PlayerGuidedBulletList = new List<GameObject>();
        m_EnermyNormalBulletList = new List<GameObject>();

        m_PlayerNormalBulletPool = new GameObject("PlayerNormalBulletPool");
        m_PlayerGuidedBulletPool = new GameObject("PlayerGuidedBulletPool");
        m_EnermyNormalBulletPool = new GameObject("EnermyNormalBulletPool");

        for (i = 0; i < m_PlayerNormalBulletAmount; ++i)
        {
            GameObject obj = CreateObject(m_PlayerNormalBullet);
            obj.transform.SetParent(m_PlayerNormalBulletPool.transform);
            m_PlayerNormalBulletList.Add(obj);
        }
        for (i = 0; i < m_PlayerGuidedBulletAmount; ++i)
        {
            GameObject obj = CreateObject(m_PlayerGuidedBullet);
            obj.transform.SetParent(m_PlayerGuidedBulletPool.transform);
            m_PlayerGuidedBulletList.Add(obj);
        }
        for (i = 0; i < m_EnermyNormalBulletAmount; ++i)
        {
            GameObject obj = CreateObject(m_EnermyNormalBullet);
            obj.transform.SetParent(m_EnermyNormalBulletPool.transform);
            m_EnermyNormalBulletList.Add(obj);
        }
    }

    GameObject CreateObject(GameObject _obj)
    {
        GameObject obj = Instantiate(_obj);
        obj.SetActive(false);
        return obj;
    }

    public GameObject GetPlayerNormalBullet()
    {
        GameObject obj;

        if (m_PlayerNormalBulletList.Count == 0)
        {
            obj = CreateObject(m_PlayerNormalBullet);
            return obj;
        }

        obj = m_PlayerNormalBulletList[0];
        m_PlayerNormalBulletList.RemoveAt(0);
        return obj;
    }
    public void AddPlayerNormalBullet(GameObject _obj)
    {
        m_PlayerNormalBulletList.Add(_obj);
    }

    public GameObject GetPlayerGuidedBullet()
    {
        GameObject obj;

        if (m_PlayerGuidedBulletList.Count == 0)
        {
            obj = CreateObject(m_PlayerGuidedBullet);
            return obj;
        }

        obj = m_PlayerGuidedBulletList[0];
        m_PlayerGuidedBulletList.RemoveAt(0);
        return obj;
    }
    public void AddPlayerGuidedBullet(GameObject _obj)
    {
        m_PlayerGuidedBulletList.Add(_obj);
    }

    public GameObject GetEnermayNormalBullet()
    {
        GameObject obj;

        if(m_EnermyNormalBulletList.Count == 0)
        {
            obj = CreateObject(m_EnermyNormalBullet);
            return obj;
        }

        obj = m_EnermyNormalBulletList[0];
        m_EnermyNormalBulletList.RemoveAt(0);
        return obj;
    }
    public void AddEnermyNormalBullet(GameObject _obj)
    {
        m_EnermyNormalBulletList.Add(_obj);
    }
}
