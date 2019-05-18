using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerBar : MonoBehaviour
{
    [SerializeField]
    InputFreqSystem m_InputFreq;
    
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 scale = transform.localScale;
        scale.x = m_InputFreq.m_PowerOutput;
        transform.localScale = scale; 
    }
}
