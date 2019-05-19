using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimSpeedSetter : MonoBehaviour
{
    [SerializeField]
    Animator m_Animator;

    [SerializeField]
    float m_SpeedScale = 1f;

    [SerializeField]
    float m_MaxSpeed = int.MaxValue;

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
        float speed = Mathf.Min(Mathf.Abs(pos.x - m_LastPos.x) * m_SpeedScale, m_MaxSpeed);
        //sam edit
        float dir = Vector3.Normalize( pos - m_LastPos ).x;
        //Debug.Log( dir );
        if ( dir > 0 ) {
            dir = 1;
        } else if ( dir < 0 ) {
            dir = -1;
        }
        m_LastPos = pos;
        //end sam edit

        // feed the animator
        if (m_Animator != null)
        {
            m_Animator.SetFloat("runSpeed", speed * dir);
        }
    }
}
