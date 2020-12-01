using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cam_FightingStyleScript : MonoBehaviour
{
    [SerializeField] private Vector3 framingNormal;
    [SerializeField] private float distance;

    public Transform pOne, pTwo;
    public Cinemachine.CinemachineVirtualCamera virtualCamera;
    public float transposerLinearSlope;
    public float transposerLinearOffset;
    public float minDistance;
    public float minCamDistance;
    public float secondaryDistance;
    public float secondaryCameraDistance;
    
    private Cinemachine.CinemachineTransposer transposer;
    private bool hasVirtualCamera;

    [ContextMenu("Calculate Slope")]
    void CalculateSlope()
    {
        if (virtualCamera == null)
            return;

        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        if (transposer == null)
            return;

        if (!Application.isPlaying)
        {
            minDistance = Vector3.Distance(pOne.position, pTwo.position);
            distance = minDistance;

            minCamDistance = transposer.m_FollowOffset.magnitude;
        }

        transposerLinearSlope = (secondaryCameraDistance - minCamDistance) / 
                                (secondaryDistance - minDistance);
        transposerLinearOffset = minCamDistance - (transposerLinearSlope * minDistance);
    }

    private void Awake()
    {
        hasVirtualCamera = virtualCamera != null;
        if (hasVirtualCamera)
        {
            transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            if (transposer == null)
            {
                hasVirtualCamera = false;
            }
            else
            {
                framingNormal = transposer.m_FollowOffset;
                framingNormal.Normalize();
            }
        }
    }

    private void LateUpdate()
    {
        if (pOne == null || pTwo == null)
            return;
        
        Vector3 diff = pOne.position - pTwo.position;
        distance = diff.magnitude;

        diff.y = 0f;
        diff.Normalize();

        if (hasVirtualCamera)
        {
            transposer.m_FollowOffset = framingNormal * (Mathf.Max(minDistance, distance) *
                transposerLinearSlope + transposerLinearOffset);
        }
        
        if(Mathf.Approximately(0f, diff.sqrMagnitude))
            return;
        
        Quaternion q = Quaternion.LookRotation(diff, Vector3.up) * 
                       Quaternion.Euler(0, 90, 0);

        Quaternion qA = q * Quaternion.Euler(0, 180, 0);

        float angle = Quaternion.Angle(q, transform.rotation);
        float angleA = Quaternion.Angle(qA, transform.rotation);

        if (angle < angleA)
        {
            transform.rotation = q;
        }
        else
        {
            transform.rotation = qA;
        }
        
    }
}
