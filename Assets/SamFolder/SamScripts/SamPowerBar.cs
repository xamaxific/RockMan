using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SamPowerBar : MonoBehaviour
{
    [SerializeField] private Slider m_slider;

    void LateUpdate () {
        m_slider.value = InputFreqSystem.s_Inst.m_PowerOutput;
    }
}
