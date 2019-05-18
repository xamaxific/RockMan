using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimSpeedSetter : MonoBehaviour
{
    [SerializeField]
    Animator m_Animator;

    [SerializeField]
    float m_SpeedScale = 1f;

    Vector3 m_LastPos;

    void Start()
    {
        m_LastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // determine speed
        Vector3 pos = transform.position;
        float speed = Mathf.Abs(pos.x - m_LastPos.x) * m_SpeedScale;
        m_LastPos = pos;

        // feed the animator
        if (m_Animator != null)
        {
            m_Animator.SetFloat("runSpeed", speed);
        }
    }
}
