using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    public static Progression s_Inst;

    public State m_State;

    public enum State
    {
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
        m_State = State.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        // todo
    }
}
