using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseTrigger : MonoBehaviour
{
    public enum TriggerType
    {
        Blind,
        Confused,
        Boulder
    }
    public TriggerType m_Type;
    public CurseManager.BlindLevel m_BlindLevel;
    public CurseManager.ConfusionLevel m_ConfusedLevel;
    public CurseManager.BoulderSize m_BoulderSize;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CurseManager.s_Inst == null)
        {
            return;
        }

        switch (m_Type)
        {
            case TriggerType.Blind:
                CurseManager.s_Inst.SetBlindLevel(m_BlindLevel);
                break;

            case TriggerType.Confused:
                CurseManager.s_Inst.SetConfusionLevel(m_ConfusedLevel);
                break;

            case TriggerType.Boulder:
                CurseManager.s_Inst.SetBoulderSize(m_BoulderSize);
                break;
        }

    }
}
