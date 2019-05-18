using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(PollInputSystem))]
public class InputFreqSystem : MonoBehaviour
{
    public static InputFreqSystem s_Inst;

    // duration of each beat (secs)
    [SerializeField]
    float m_BeatPeriod = 0.5f;

    // how many beats back we poll to determine power
    [SerializeField]
    int m_NumBeatsToPoll = 5;

    // the output of this system [0, 1]
    [NonSerialized]
    public float m_PowerOutput;

    PollInputSystem m_Input;

    void Start()
    {
        m_Input = GetComponent<PollInputSystem>();       
    }

    void OnEnable()
    {
        s_Inst = this;
    }

    void OnDisable()
    {
        s_Inst = null;
    }

    // Update is called once per frame
    void Update()
    {
        // for the last n beats, we check whether the input was received during that period
        // we score 1 point for each beat where we received input.
        // we divide through by the number of beats that we have checked.

        // we check until the end of the last full beat
        float now = Time.time;
        float timeIntoBeat = now % m_BeatPeriod;
        float lastFullBeatEnd = now - timeIntoBeat;

        // initialise score and start of beat time
        int score = 0;
        float beatStart = lastFullBeatEnd - (m_BeatPeriod * m_NumBeatsToPoll);

        // grab input buffer
        List<float> inputBuf = m_Input.m_Buffer;
        int inputLen = inputBuf.Count;
        int inputPos = 0;

        // skip past inputs that occur before our time
        while ((inputPos < inputLen) && (inputBuf[inputPos] < beatStart))
        {
            ++inputPos;
        }

        // loop over beats to determine score
        for (int beatInd = 0; beatInd < m_NumBeatsToPoll; ++beatInd)
        {
            // figure out where beat ends
            float beatEnd = beatStart + m_BeatPeriod;

            // do we score on this beat?
            bool scored = false;
            while ((inputPos < inputLen) && (inputBuf[inputPos] < beatEnd))
            {
                scored = true;
                ++inputPos;
            }
            if (scored)
            {
                ++score;
            }

            // increase beat start for next loop
            beatStart += m_BeatPeriod;
        }

        // output power rating
        m_PowerOutput = (float)score / m_NumBeatsToPoll;
    }
}
