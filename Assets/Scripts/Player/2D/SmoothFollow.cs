using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _absoluteOffset;
    [SerializeField] private float _smoothTime;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _distanceMultiplier;
    private Vector3 _velocity = Vector3.zero;
    private Vector3 _offset = Vector3.zero;

    public void UpdatePosition(Transform target)
    {
        Vector3 targetPosition = target.position + _absoluteOffset;

        //Speed up movement if object is too far from target
        float distance = Vector2.Distance(_offset, targetPosition);
        var smoothTime = distance <= _maxDistance ? _smoothTime : _smoothTime - (distance - _maxDistance) / _distanceMultiplier;

        //Smoothly move object towards the target
        _offset = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
        transform.position = Snapping.Round(_offset);
    }
}
