using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : BaseSingleton<GameManager>
{
    private float sceneChangeTime;
    private float m_SceneChangeTime
    {
        set
        {
            if (3.0f <= value)
                GoToResultScene();
            else
                this.sceneChangeTime = value;
        }
        get
        {
            return this.sceneChangeTime;
        }
    }

    [HideInInspector] public bool m_IsGameOver;
    [HideInInspector] public bool m_IsOnSpecialAttack;

    [SerializeField]
    public Light m_WorldLight;
    private Color m_OriginWorldLightColor;

    [SerializeField]
    private float m_EffectDurationTime;
    private float currentEffectDurationTime;
    private float m_CurrentEffectDurationTime
    {
        set
        {
            if(m_EffectDurationTime <= value)
            {
                this.currentEffectDurationTime = 0.0f;
                m_IsOnEffect = false;
                m_CurrentEffectTime = 0.0f;
                m_WorldLight.color = m_OriginWorldLightColor;
            }
            else
                this.currentEffectDurationTime = value;
        }
        get
        {
            return this.currentEffectDurationTime;
        }
    }
    private bool isOnEffect;
    public bool m_IsOnEffect
    {
        set
        {
            if (value == true)
                this.isOnEffect = true;
            else
            {
                this.isOnEffect = false;
                this.currentEffectDurationTime = 0.0f;
            }
        }
    }

    [SerializeField]
    private float m_EffectRate;
    private float currentEffectTime;
    private float m_CurrentEffectTime
    {
        set
        {
            if (m_EffectRate <= value)
            {
                m_IsToggledEffect = !m_IsToggledEffect;
                this.currentEffectTime = 0.0f;
            }
            else
                this.currentEffectTime = value;
        }
        get
        {
            return this.currentEffectTime;
        }
    }
    private bool m_IsToggledEffect;

    void Start()
    {
        m_IsGameOver = false;
        m_SceneChangeTime = 0.0f;
        m_IsOnSpecialAttack = false;
        m_OriginWorldLightColor = m_WorldLight.color;
        m_IsToggledEffect = true;
        m_CurrentEffectDurationTime = 0.0f;
        m_IsOnEffect = false;
    }

    void Update()
    {        
        if(this.isOnEffect)
        {
            SpecialAttackEffect();
            m_CurrentEffectTime += Time.deltaTime;
            m_CurrentEffectDurationTime += Time.deltaTime;
        }
    }

    void SpecialAttackEffect()
    {
        if (m_IsToggledEffect)
            m_WorldLight.color = Color.white;
        else
            m_WorldLight.color = Color.black;
    }

    void GoToResultScene()
    {
        SceneManager.LoadScene("Result");
    }
}