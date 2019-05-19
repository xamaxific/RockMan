using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    [SerializeField]
    Transform m_Target;

    [SerializeField]
    float m_Tolerance = 10f;

    [SerializeField]
    bool m_OnlyMoveForwards = true;

    float m_GracePeriod;

    // Start is called before the first frame update
    void Start()
    {
        // snap
        UpdatePos(tolerance: 0f);
        m_GracePeriod = 1f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdatePos(m_Tolerance);
    }

    void UpdatePos(float tolerance)
    {
        if (m_Target != null)
        {
            // target position should not move z pos
            Vector3 camPos = transform.position;
            Vector3 targPos = m_Target.position;
            targPos.z = camPos.z;

            // allow play around tracked xy position
            Vector3 diff = targPos - camPos;
            float len = diff.magnitude;

            // we only move camera when we are above tolerance
            if (len > tolerance)
            {
                Vector3 dir = diff / len;
                Vector3 newPos = targPos - dir * tolerance;

                // don't go back!
                if (m_OnlyMoveForwards)
                {
                    m_GracePeriod -= Time.deltaTime;
                    if (m_GracePeriod <= 0)
                    {
                        newPos.x = Mathf.Max(newPos.x, camPos.x);
                    }
                }

                transform.position = newPos;
            }
        }
    }
}
