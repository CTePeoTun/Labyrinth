using System;
using System.Collections;
using UnityEngine;

namespace Labyrinth
{
    public class Player : Character
    {
        public event Action OnDeath;
        public event Action OnFinish;

        private bool isAlive = true;

        private void OnTriggerEnter(Collider other)
        {
            if (isAlive)
            {
                if (other.TryGetComponent(out Finish finish))
                {
                    OnFinish?.Invoke();
                    return;
                }
                if (other.TryGetComponent(out IEnemy enemy))
                {
                    enemy.Activate();
                    StartCoroutine(Death());
                }                
            }            
        }

        private IEnumerator Death()
        {
            Stay();
            isAlive = false;
            yield return new WaitForSeconds(0.3f);
            _animator.SetTrigger(AnimParametres.Death);
            yield return new WaitForSeconds(3f);
            OnDeath?.Invoke();
        }

        public override void Walk()
        {
            if (isAlive)
            {
                base.Walk();
            }            
        }

        public override void Stay()
        {
            if (isAlive)
            {
                base.Stay();
            }
        }

    }
}