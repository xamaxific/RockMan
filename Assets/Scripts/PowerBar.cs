using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerBar : MonoBehaviour
{   
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 scale = transform.localScale;
        scale.x = InputFreqSystem.s_Inst.m_PowerOutput;
        transform.localScale = scale; 
    }
}
