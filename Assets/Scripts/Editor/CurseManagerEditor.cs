using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CurseManager))]
public class CurseManagerEditor : Editor
{
    int m_Blindness;
    int m_Boulder;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        m_Blindness = EditorGUILayout.Popup("Blindness", m_Blindness, new string[] { "NoBlind", "LowBlind", "MedBlind", "HiBlind" }, new GUILayoutOption[0]);
        ((CurseManager)target).SetBlindLevel((CurseManager.BlindLevel)m_Blindness);

        m_Boulder = EditorGUILayout.Popup("Boulder", m_Boulder, new string[] { "Small", "Medium", "Large" }, new GUILayoutOption[0]);
        ((CurseManager)target).SetBoulderSize((CurseManager.BoulderSize)m_Boulder);
    }
}
