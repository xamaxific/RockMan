using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraBlindness : MonoBehaviour
{
    [SerializeField]
    Material m_Mat;

    [SerializeField]
    float m_SeeDist = 0.5f;

    // Postprocess the image
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        m_Mat.SetFloat("_time", Time.time);
        m_Mat.SetFloat("_seeDist", m_SeeDist);
        Graphics.Blit(source, destination, m_Mat);
    }
}
