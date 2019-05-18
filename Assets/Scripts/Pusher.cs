using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pusher : MonoBehaviour
{
    [SerializeField]
    float m_MaxForce = 100f;

    Rigidbody2D m_RBody;

    // Start is called before the first frame update
    void Start()
    {
        m_RBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float power = InputFreqSystem.s_Inst.m_PowerOutput;
        if (power > 0)
        {
            m_RBody.AddForceAtPosition(
                new Vector2(power * m_MaxForce, 0f),
                m_RBody.position);
        }
    }
}
