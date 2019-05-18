using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseManager : MonoBehaviour
{
    [SerializeField]
    float m_StepSpeed = 1f;

    [SerializeField]
    CameraBlindness m_CamBlind;

    public enum BlindLevel
    {
        None,
        Low,
        Med,
        High
    }

    float m_SeeDistTarg;
    float m_SeeDistCur;

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

    private void Start()
    {
        SetBlindLevel(BlindLevel.None);
        m_SeeDistCur = m_SeeDistTarg;
    }

    private void Update()
    {
        float time = Time.time;

        m_SeeDistCur = Mathf.SmoothStep(m_SeeDistCur, m_SeeDistTarg, m_StepSpeed * time);
        if (m_CamBlind != null)
        {
            m_CamBlind.m_SeeDist = m_SeeDistCur;
        }
    }
}
