using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] private Path _path;
        [SerializeField] protected Animator _animator;
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _rotationSpeed = 400f;

        private Transform _targetPoint;
        protected bool isMove;

        protected virtual void Awake()
        {
            GetTargetPoint();
        }

        public virtual void Walk()
        {
            SetMoveState(true);
        }

        public virtual void Stay()
        {
            SetMoveState(false);
        }

        private void SetMoveState(bool isNeedMove)
        {
            isMove = isNeedMove;
            _animator.SetBool(AnimParametres.IsMove, isNeedMove);
        }

        protected virtual void Update()
        {
            if (isMove == true && _targetPoint != null)
            {
                if(Vector3.Distance(_targetPoint.position, transform.position) > 0.1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, _targetPoint.position, _speed * Time.deltaTime);
                    var q = Quaternion.LookRotation(transform.position - _targetPoint.position);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * _rotationSpeed);
                } else
                {
                    GetTargetPoint();
                }                
            }            
        }

        private void GetTargetPoint()
        {
            _targetPoint = _path.GetTargetPoint();
        }

    }    
}