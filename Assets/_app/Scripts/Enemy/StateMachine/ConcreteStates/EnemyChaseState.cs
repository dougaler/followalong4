using _app.Scripts.Enemy.StateMachine;
using UnityEngine;

namespace _app.Scripts.Enemy.Statemachine.ConcreteStates
{
    public class EnemyChaseState : EnemyState
    {
        private Transform _playerTransform;
        private float _movementSpeed = 1.25f;
        public EnemyChaseState(Base.Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
        {
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public override void EnterState()
        {
            base.EnterState();
            
            Debug.Log("Chase State Enter");
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void FrameUpdate()
        {
            base.FrameUpdate();

            Vector2 moveDirection = (_playerTransform.position - enemy.transform.position).normalized;
            enemy.MoveEnemy(moveDirection * _movementSpeed);

            if (enemy.IsWithinStrikingDistance)
            {
                enemy.StateMachine.ChangeState(enemy.AttackState);
            }

            if (!enemy.IsAggroed && !enemy.IsWithinStrikingDistance)
            {
                enemy.StateMachine.ChangeState(enemy.IdleState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}