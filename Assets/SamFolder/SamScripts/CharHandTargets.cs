using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHandTargets : MonoBehaviour
{
    [Header( "Target" )]
    [SerializeField] private Transform m_objectToattach;
    [SerializeField] private Vector3 m_leftHandTargetOffset;
    [SerializeField] private Vector3 m_rightHandTargetOffset;
    [Header("Controls")]
    [SerializeField] private Transform m_leftHandCtrl;
    [SerializeField] private Transform m_rightHandCtrl;



    private void Update () {
        SetCtrlToTarget();
    }

    public void SetCtrlToTarget () {
        Vector3 lHand = m_objectToattach.position + m_leftHandTargetOffset;
        Vector3 rHand = m_objectToattach.position + m_rightHandTargetOffset;
        m_leftHandCtrl.position = lHand;
        m_rightHandCtrl.position = rHand;
    }
}
