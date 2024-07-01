using Unity;

using _app.Scripts.Enemy.StateMachine;

namespace _app.Scripts.Enemy.Statemachine
{
    public class EnemyState
    {
        protected Base.Enemy enemy;
        protected EnemyStateMachine enemyStateMachine;

        public EnemyState(Base.Enemy enemy, EnemyStateMachine enemyStateMachine)
        {
            this.enemy = enemy;
            this.enemyStateMachine = enemyStateMachine;
            
        }

        public virtual void EnterState()
        {
            
        }
        public virtual void ExitState()
        {
            
        }
        public virtual void FrameUpdate()
        {
            
        }
        public virtual void PhysicsUpdate()
        {
            
        }
    }
}