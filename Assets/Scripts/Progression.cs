﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    [SerializeField]
    Transform m_RestartUI;

    [SerializeField]
    Rigidbody2D m_BoulderRBody;

    public static Progression s_Inst;

    Renderer m_BoulderRenderer;
    Pusher m_BoulderPusher;

    public State m_State;
    float m_Delay;

    public enum State
    {
        GracePeriod,
        Playing,
        GameOver
    }

    private void OnEnable()
    {
        s_Inst = this;
    }

    private void OnDisable()
    {
        s_Inst = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (m_BoulderRBody)
        {
            m_BoulderRenderer = m_BoulderRBody.GetComponent<Renderer>();
            m_BoulderPusher = m_BoulderRBody.GetComponent<Pusher>();
        }

        m_State = State.GracePeriod;
        m_Delay = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        // update delay
        if (m_Delay > 0)
        {
            m_Delay -= Time.deltaTime;
        }

        switch (m_State)
        {
            case State.GracePeriod:
                bool enablePusher;
                if (m_Delay <= 0)
                {
                    m_State = State.Playing;
                    enablePusher = true;
                }
                else
                {
                    enablePusher = false;
                }
                if (m_BoulderPusher)
                {
                    m_BoulderPusher.enabled = enablePusher;
                }                
                break;

            case State.Playing:
                if (m_BoulderRenderer)
                {
                    if (!m_BoulderRenderer.isVisible)
                    {
                        m_State = State.GameOver;

                        if (m_RestartUI)
                        {
                            m_RestartUI.gameObject.SetActive(true);
                        }
                    }
                }
                break;

            case State.GameOver:
                if (m_BoulderRBody)
                {
                    m_BoulderRBody.simulated = false;
                }
                break;
        }
    }
}
