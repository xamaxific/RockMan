using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurseManager : MonoBehaviour
{
    [SerializeField]
    float m_StepSpeed = 1f;

    [SerializeField]
    CameraBlindness m_CamBlind;

    [SerializeField]
    Rigidbody2D m_Boulder;

    [SerializeField]
    Text m_ControlText;

    [SerializeField]
    PollInputSystem m_InputSystem;

    [SerializeField]
    float m_MinBoulderMass, m_MaxBoulderMass;

    [SerializeField]
    float m_MinBoulderScale, m_MaxBoulderScale;

    [SerializeField]
    float m_LowConfusionSwitchPeriod, m_HighConfusionSwitchPeriod;

    public enum BlindLevel
    {
        None,
        Low,
        Med,
        High
    }

    public enum BoulderSize
    {
        Small,
        Medium,
        Large
    }

    public enum ConfusionLevel
    {
        None,
        Low,
        High
    }

    float m_SeeDistTarg;
    float m_SeeDistCur;

    float m_BoulderScaleTarg;
    float m_BoulderScaleCur;

    ConfusionLevel m_Confusion;
    KeyCode m_ConfusionSwitchCode;
    float m_ConfusionSwitchDelay;

    public void SetBlindLevel(BlindLevel lvl)
    {
        switch (lvl)
        {
            case BlindLevel.None:   m_SeeDistTarg = 0.45f; break;
            case BlindLevel.Low:    m_SeeDistTarg = 0.25f; break;
            case BlindLevel.Med:    m_SeeDistTarg = 0.17f; break;
            case BlindLevel.High:   m_SeeDistTarg = 0.1f; break;
        }
    }

    public void SetBoulderSize(BoulderSize size)
    {
        
        switch (size)
        {
            case BoulderSize.Small: m_BoulderScaleTarg = 0f; break;
            case BoulderSize.Medium: m_BoulderScaleTarg = 0.5f; break;
            case BoulderSize.Large: m_BoulderScaleTarg = 1f; break;
        }
    }

    public void SetConfusionLevel(ConfusionLevel level)
    {
        m_Confusion = level;
    }

    private void Start()
    {
        SetBlindLevel(BlindLevel.None);
        m_SeeDistCur = m_SeeDistTarg;

        SetBoulderSize(BoulderSize.Small);
        m_BoulderScaleCur = 0f;

        SetConfusionLevel(ConfusionLevel.None);
        m_ConfusionSwitchDelay = 0f;
        m_ConfusionSwitchCode = KeyCode.Space;
    }

    private void Update()
    {
        float time = Time.time;

        // do blindness
        m_SeeDistCur = Mathf.SmoothStep(m_SeeDistCur, m_SeeDistTarg, m_StepSpeed * time);
        if (m_CamBlind != null)
        {
            m_CamBlind.m_SeeDist = m_SeeDistCur;
        }

        // do boulder scale
        m_BoulderScaleCur = Mathf.SmoothStep(m_BoulderScaleCur, m_BoulderScaleTarg, m_StepSpeed * time);
        if (m_Boulder != null)
        {
            m_Boulder.mass = m_MinBoulderMass + m_BoulderScaleCur * (m_MaxBoulderMass - m_MinBoulderMass);
            float scale = m_MinBoulderScale + m_BoulderScaleCur * (m_MaxBoulderScale - m_MinBoulderScale);
            m_Boulder.transform.localScale = new Vector3(scale, scale, scale);
        }

        // figure out what key is trigger
        if (m_Confusion != ConfusionLevel.None)
        {
            m_ConfusionSwitchDelay -= Time.deltaTime;
            if (m_ConfusionSwitchDelay <= 0)
            {
                int index = ((int)(UnityEngine.Random.value * 26)) % 26;
                m_ConfusionSwitchCode = (KeyCode)((int)KeyCode.A + index);
                m_ConfusionSwitchDelay = (m_Confusion == ConfusionLevel.High) ? m_HighConfusionSwitchPeriod : m_LowConfusionSwitchPeriod;
            }
        }

        // set value in text
        if (m_ControlText != null)
        {
            m_ControlText.text = m_ConfusionSwitchCode.ToString();
        }

        // set value in input
        if (m_InputSystem != null)
        {
            m_InputSystem.m_TriggerKey = m_ConfusionSwitchCode;
        }
    }
}
