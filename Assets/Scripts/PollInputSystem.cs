using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollInputSystem : MonoBehaviour
{
    // rolling buffer of presses, starting with the least recent
    public List<float> m_Buffer = new List<float>();    

    // Update is called once per frame
    void Update()
    {
        float now = Time.time;

        // delete too old presses
        const float kKeepTime = 5f;
        float tooOld = now - kKeepTime;
        while ((m_Buffer.Count > 0) && (m_Buffer[0] <= tooOld))
        {
            m_Buffer.RemoveAt(0);
        }

        // store new press if applicable
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Buffer.Add(now);
        }
    }
}
