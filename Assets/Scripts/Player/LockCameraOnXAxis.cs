using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu(" ")]
public class LockCameraOnXAxis : CinemachineExtension
{
    public float CamXPositionLock = 0;

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
       if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.x = CamXPositionLock;
            state.RawPosition = pos;
        }
    }
}
