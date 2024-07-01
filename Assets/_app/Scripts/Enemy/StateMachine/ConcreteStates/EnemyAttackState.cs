using _app.Scripts.Enemy.Statemachine;
using UnityEngine;


namespace _app.Scripts.Enemy.StateMachine.ConcreteStates
{
    public class EnemyAttackState : EnemyState
    {
        public EnemyAttackState(Base.Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
        {
            
        }

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Entered Attack State");
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void FrameUpdate()
        {
            base.FrameUpdate();
            enemy.MoveEnemy(Vector2.zero);
            if (enemy.IsAggroed && !enemy.IsWithinStrikingDistance)
            {
                enemy.StateMachine.ChangeState(enemy.ChaseState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
        
    }
}