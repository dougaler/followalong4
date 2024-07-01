using System;
using UnityEngine;

namespace _app.Scripts.Enemy.TriggerChecks
{
    public class EnemyAggroCheck : MonoBehaviour
    {
        public GameObject PlayerTarget { get; set; }
        private Base.Enemy _enemy;

        private void Awake()
        {
            PlayerTarget = GameObject.FindGameObjectWithTag("Player");
            _enemy = GetComponentInParent<Base.Enemy>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == PlayerTarget)
            {
                _enemy.SetAggroStatus(true);
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject == PlayerTarget)
            {
                _enemy.SetAggroStatus(false);
            }
        }
    }
}