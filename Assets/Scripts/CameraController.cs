using Cinemachine;
using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachine;
    [SerializeField] private CinemachineTransposer transposer;
    
    [SerializeField] private float chillDamping;
    [SerializeField] private float punkDamping;
    
    [SerializeField] private float chillCameraDistance;
    [SerializeField] private float punkCameraDistance;

    [SerializeField] private float chillOffset;
    [SerializeField] private float punkOffset;

    private void Awake()
    {
        cinemachine = GetComponent<CinemachineVirtualCamera>();
        transposer = cinemachine.GetCinemachineComponent<CinemachineTransposer>();
    }

    private void Update()
    {
        if (AudioManager.instance.mood == Mood.chill || AudioManager.instance.mood == Mood.none)
        {
            transposer.m_FollowOffset.x = chillOffset;
            transposer.m_XDamping = chillDamping;

            cinemachine.m_Lens.FieldOfView = 60f;
            cinemachine.m_Lens.Dutch = 0f;
        
        }
        else if (AudioManager.instance.mood == Mood.punk)
        {
            StartCoroutine(TransposeCamera());
            transposer.m_XDamping = punkDamping;

            cinemachine.m_Lens.Dutch = 2f;
        }
    }
    
    IEnumerator TransposeCamera()
    {
        transposer.m_FollowOffset.x = Mathf.Lerp(transposer.m_FollowOffset.x, punkOffset, .01f);
        cinemachine.m_Lens.FieldOfView = Mathf.Lerp(cinemachine.m_Lens.FieldOfView, 70f, .001f);
        cinemachine.m_Lens.Dutch = Mathf.Lerp(cinemachine.m_Lens.Dutch, 4f, .001f);
        yield return new WaitForSeconds(0f);
    }
}
