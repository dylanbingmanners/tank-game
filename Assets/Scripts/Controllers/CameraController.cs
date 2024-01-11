using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    static CameraController _instance;
    public static CameraController Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<CameraController>();
            }
            return _instance;
        }
    }

    public Camera Camera;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _smoothSpeed;
    [SerializeField] private float _zoom;
    [SerializeField] private float _maxHDistance;
    [SerializeField] private float _maxVDistance;

    private Vector2 _currentSpeed;

    private void LateUpdate()
    {
        Vector2 cursorPosWorld = Camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 focusPoint = new Vector2((cursorPosWorld.x + _target.transform.position.x) / 2, (cursorPosWorld.y + _target.transform.position.y) / 2);

        float hDistance = Mathf.Abs(focusPoint.x - _target.transform.position.x);
        float vDistance = Mathf.Abs(focusPoint.y - _target.transform.position.y);

        if (hDistance > _maxHDistance)
        {
            float hDistanceRatio = _maxHDistance / hDistance;
            float focusPointH = (1 - hDistanceRatio) * _target.transform.position.x + hDistanceRatio * focusPoint.x;
            focusPoint = new Vector2(focusPointH, focusPoint.y);
        }

        if (vDistance > _maxVDistance)
        {
            float vDistanceRatio = _maxVDistance / vDistance;
            float focusPointV = (1 - vDistanceRatio) * _target.transform.position.y + vDistanceRatio * focusPoint.y;
            focusPoint = new Vector2(focusPoint.x, focusPointV);
        }

        Vector2 smoothed = Vector2.SmoothDamp(Camera.transform.position, focusPoint, ref _currentSpeed, _smoothSpeed);
        Camera.transform.position = new Vector3(smoothed.x, smoothed.y, _zoom);
    }
}
