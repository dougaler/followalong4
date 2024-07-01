using System;
using _app.Scripts.Enemy.Statemachine;
using _app.Scripts.Enemy.StateMachine;
using _app.Scripts.Enemy.Statemachine.ConcreteStates;
using _app.Scripts.Enemy.StateMachine.ConcreteStates;
using _app.Scripts.Interfaces;
using UnityEngine;

namespace _app.Scripts.Enemy.Base
{
    public class Enemy : MonoBehaviour, IEnemyMoveable, IDamageable, ITriggerCheckable
    {
        public EnemyStateMachine StateMachine { get; set; }
        public EnemyIdleState IdleState { get; set; }
        public EnemyChaseState ChaseState { get; set; }
        public EnemyAttackState AttackState { get; set; }

        public Rigidbody2D rb;
        public bool IsFacingRight { get; set; } = true;

        public float randomMovementRange = 5f;
        public float randomAttackRange = 1f;

        [field:SerializeField] public float MaxHealth { get; set; } = 100f;
        public float CurrentHealth { get; set; }
        
        public bool IsAggroed { get; set; }
        public bool IsWithinStrikingDistance { get; set; }

        private void Awake()
        {
            StateMachine = new EnemyStateMachine();
            IdleState = new EnemyIdleState(this, StateMachine);
            ChaseState = new EnemyChaseState(this, StateMachine);
            AttackState = new EnemyAttackState(this, StateMachine);
        }

        private void Start()
        {
            CurrentHealth = MaxHealth;
            rb = GetComponent<Rigidbody2D>();
            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            StateMachine.CurrentEnemyState.FrameUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentEnemyState.PhysicsUpdate();
        }

        public void MoveEnemy(Vector2 velocity)
        {
            rb.velocity = velocity;
            CheckForLeftOrRightFacing(velocity);
        }

        public void CheckForLeftOrRightFacing(Vector2 velocity)
        {
            if (IsFacingRight && velocity.x < 0f)
            {
                Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
                transform.rotation = Quaternion.Euler(rotator);
                IsFacingRight = !IsFacingRight;
            }
            else if (!IsFacingRight && velocity.x > 0f)
            {
                Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
                transform.rotation = Quaternion.Euler(rotator);
                IsFacingRight = !IsFacingRight;
            }
        }

        public void Damage(float damageAmount)
        {
            CurrentHealth -= damageAmount;
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            Destroy(this.gameObject);
        }

        
        public void SetAggroStatus(bool isAggroed)
        {
            IsAggroed = isAggroed;
        }

        public void SetStrikingDistanceBool(bool isStrikingDistance)
        {
            IsWithinStrikingDistance = isStrikingDistance;
        }
    }
}