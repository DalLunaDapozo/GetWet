using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanarReflection : MonoBehaviour
{
    Camera m_ReflectionCamera;
    Camera m_MainCamera;

    public GameObject m_ReflectionPlane;

    public Material m_WaterMaterial;

    RenderTexture m_RenderTarget;

    [Range (0.0f, 1.0f)]
    public float m_ReflectionFactor = 0.5f;
    void Start()
    {
        GameObject reflectionCameraGo = new GameObject("ReflectionCamera");
        m_ReflectionCamera = reflectionCameraGo.AddComponent<Camera>();
        m_ReflectionCamera.enabled = false;

        m_MainCamera = Camera.main;

        m_RenderTarget = new RenderTexture(Screen.width, Screen.height, 24);
    
    }

    void Update()
    {
        Shader.SetGlobalFloat("_reflectionFactor", m_ReflectionFactor);
    }

    private void OnPostRender()
    {
        RenderReflection();
    }

    void RenderReflection()
    {
        m_ReflectionCamera.CopyFrom(m_MainCamera);

        Vector3 cameraDirectionWorldSpace = m_MainCamera.transform.forward;
        Vector3 cameraUpWorldSpace = m_MainCamera.transform.up;
        Vector3 cameraPositionWorldSpace = m_MainCamera.transform.position;

        Vector3 cameraDirectionPlaneSpace = m_ReflectionPlane.transform.InverseTransformDirection(cameraDirectionWorldSpace);
        Vector3 cameraUpPlaneSpace = m_ReflectionPlane.transform.InverseTransformDirection(cameraDirectionWorldSpace);
        Vector3 cameraPositionPlaneSpace = m_ReflectionPlane.transform.InverseTransformPoint(cameraPositionWorldSpace);

        cameraDirectionPlaneSpace.y *= - 1.0f;
        cameraUpPlaneSpace.y *= -1.0f;
        cameraPositionPlaneSpace.y *= -1.0f;

        cameraDirectionWorldSpace = m_ReflectionPlane.transform.TransformDirection(cameraDirectionPlaneSpace);
        cameraUpWorldSpace = m_ReflectionPlane.transform.TransformDirection(cameraUpPlaneSpace);
        cameraPositionWorldSpace = m_ReflectionPlane.transform.TransformPoint(cameraPositionPlaneSpace);

        m_ReflectionCamera.transform.position = cameraDirectionWorldSpace;
        m_ReflectionCamera.transform.LookAt(cameraPositionWorldSpace + cameraDirectionWorldSpace, cameraUpWorldSpace);

        m_ReflectionCamera.targetTexture = m_RenderTarget;

        m_ReflectionCamera.Render();

        DrawQuad();
    }
    
    void DrawQuad()
    {
        GL.PushMatrix();

        m_WaterMaterial.SetPass(0);
        m_WaterMaterial.SetTexture("_ReflectionTex", m_RenderTarget);

        GL.LoadOrtho();

        GL.Begin(GL.QUADS);

        GL.TexCoord2(1.0f, 0.0f);
        GL.Vertex3(0.0f,0.0f,0.0f);
        GL.TexCoord2(1.0f, 1.0f);
        GL.Vertex3(0.0f, 1.0f, 0.0f);
        GL.TexCoord2(0.0f, 1.0f);
        GL.Vertex3(1.0f, 1.0f, 0.0f);
        GL.TexCoord2(0.0f, 0.0f);
        GL.Vertex3(1.0f, 0.0f, 0.0f);

        GL.End();

        GL.PopMatrix();
    }
}
