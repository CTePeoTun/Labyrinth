using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public class Knifes : MonoBehaviour, IEnemy
    {
        [SerializeField] private Transform _knifes;
        private Vector3 _startPosition;

        private void Awake()
        {
            _startPosition = _knifes.localPosition;
        }

        private void Start()
        {
            StartCoroutine(Move());
        }

        public void Activate()
        {
            StopCoroutine(Move());
        }

        private IEnumerator Move()
        {
            while (true)
            {
                _knifes.localPosition = _startPosition + new Vector3(0f, Mathf.PingPong(Time.time, 2f), 0f);
                yield return null;
            }
        }
    }
}