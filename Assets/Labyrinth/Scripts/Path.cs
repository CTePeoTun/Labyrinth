using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private bool _isLooped;
        [SerializeField] private Transform[] _points;

        private int _current = 0;

        public void OnDrawGizmos()
        {
            if (_points != null && _points.Length >= 2)
            {
                for (int i = 1; i < _points.Length; i++)
                {
                    Gizmos.DrawLine(_points[i-1].position, _points[i].position);
                }
                if (_isLooped)
                {
                    Gizmos.DrawLine(_points[0].position, _points[_points.Length-1].position);
                }
            }
        }

        public Transform GetTargetPoint()
        {
            if (_points != null)
            {
                if (_current < _points.Length)
                {
                    var point = _points[_current];
                    _current++;
                    return point;                    
                } else
                {
                    if (_isLooped)
                    {
                        _current = 0;
                        return _points[0];
                    } else
                    {
                        return null;
                    }
                }
            } else
            {
                Debug.LogWarning("Empty path " + gameObject);
                return null;
            }
        }
    }
}