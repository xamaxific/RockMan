using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CurseManager))]
public class CurseManagerEditor : Editor
{
    int m_Blindness;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        m_Blindness = EditorGUILayout.Popup("Blindness", m_Blindness, new string[] { "NoBlind", "LowBlind", "MedBlind", "HiBlind" }, new GUILayoutOption[0]);
        ((CurseManager)target).SetBlindLevel((CurseManager.BlindLevel)m_Blindness);
    }
}
