using _app.Scripts.Enemy.StateMachine;
using UnityEngine;

namespace _app.Scripts.Enemy.Statemachine.ConcreteStates
{
    public class EnemyIdleState : EnemyState
    {
        private Vector3 _targetPosition;
        private Vector3 _direction;
        public EnemyIdleState(Base.Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
        {
            
        }

        public override void EnterState()
        {
            base.EnterState();

            _targetPosition = GetRandomPointInCircle();
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void FrameUpdate()
        {
            base.FrameUpdate();

            if (enemy.IsAggroed)
            {
                enemy.StateMachine.ChangeState(enemy.ChaseState);
            }

            _direction = (_targetPosition - enemy.transform.position).normalized;
            
            enemy.MoveEnemy(_direction * enemy.randomMovementRange);

            if ((enemy.transform.position - _targetPosition).sqrMagnitude < 0.01f)
            {
                _targetPosition = GetRandomPointInCircle();
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        private Vector3 GetRandomPointInCircle()
        {
            return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * enemy.randomMovementRange;
        }
    }
}