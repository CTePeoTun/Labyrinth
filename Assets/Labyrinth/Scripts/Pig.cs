using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public class Pig : Character, IEnemy
    {
        private void Start()
        {
            Walk();
        }

        public void Activate()
        {
            StartCoroutine(Attack());
        }

        private IEnumerator Attack()
        {
            Stay();
            _animator.SetTrigger(AnimParametres.Attack);
            yield return new WaitForSeconds(2f);
            Walk();
        }
    }
}