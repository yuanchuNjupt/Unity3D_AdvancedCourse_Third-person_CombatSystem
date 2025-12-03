using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_CameraControl : MonoBehaviour
{
    //相机的移动速度
    [SerializeField, Header("相机参数配置")] private float _controlSpeed;  //摄像机移动速度
    [SerializeField, Header("最大俯仰角")] private float _cameraVerticalMaxAngle;  //限制相机上下最大旋转角度
    [SerializeField, Header("最小俯仰角")] private float _cameraVerticalMinAngle;  //限制相机上下最小转角度
    [SerializeField, Header("相机旋转平滑时间")] private float _smoothRotationTime;   //摄像机平滑速度
    [SerializeField, Header("TP_Camera偏移值")] private float _positionOffset;   //摄像机与目标物体的距离偏移
    [SerializeField, Header("相机位置平滑插值系数")] private float _positionSmoothTime;    //摄像机位置平滑时间


    [SerializeField , Header("跟随目标")]
    public Transform _lookTarget;
    private Vector3 _smoothDampVelocity = Vector3.zero;
    private Vector2 _input;    //相机的输入 旋转角度
    private Vector3 _cameraRotation;   //当前摄像机的旋转角度

    private void Update()
    {
        if(_lookTarget == null)
            return;
        CameraInput();
    }

    private void LateUpdate()
    {
        if(_lookTarget == null)
            return;
        UpdateCameraRotation();
        CameraPosition();
    }

    private void CameraInput()
    {

        _input.y += InputManager.Instance.CameraMove.x * _controlSpeed;
        _input.x -= InputManager.Instance.CameraMove.y * _controlSpeed;

        _input.x = Mathf.Clamp(_input.x, _cameraVerticalMinAngle, _cameraVerticalMaxAngle);
    }

//更新相机的旋转
    private void UpdateCameraRotation()
    {
        _cameraRotation = Vector3.SmoothDamp(_cameraRotation , new Vector3(_input.x, _input.y, 0), ref _smoothDampVelocity, _smoothRotationTime);
        transform.eulerAngles = _cameraRotation;
    }

    private void CameraPosition()
    {
        var newPos = (_lookTarget.position + (-transform.forward * _positionOffset));
        transform.position = Vector3.Lerp(transform.position , newPos , DevelepTools.UnTetheredLerp(_positionSmoothTime));
    }
    
    
    
}
