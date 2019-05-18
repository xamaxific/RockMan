using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Follower : MonoBehaviour
{
    [SerializeField]
    Collider2D m_Target = null;

    Collider2D m_MyCollider;
    int m_GroundMask;

    void Start()
    {
        m_MyCollider = GetComponent<Collider2D>();
        m_GroundMask = LayerMask.GetMask(new string[] { "Ground" });
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Target == null)
        {
            return;
        }

        // move to the left of the given target
        Vector3 pos = m_Target.bounds.center;
        pos.x = m_Target.bounds.min.x - (m_MyCollider.bounds.max.x - m_MyCollider.bounds.center.x);

        // move down to floor
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.down, int.MaxValue, m_GroundMask);
        if (hit.collider)
        {
            float midHeight = (m_MyCollider.bounds.center.y - m_MyCollider.bounds.min.y);
            pos.y = hit.point.y + midHeight;               
        }

        transform.position = pos;
    }
}
