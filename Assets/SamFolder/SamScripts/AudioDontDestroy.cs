using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDontDestroy : MonoBehaviour
{
    public static AudioDontDestroy m_instance;
    private void Awake () {
        if ( m_instance == null ) {
            m_instance = this;
            DontDestroyOnLoad( m_instance );
        } else {
            Destroy( this.gameObject );
        }
    }
}
