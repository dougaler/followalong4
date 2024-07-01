using _app.Scripts.Enemy.Statemachine;
using UnityEngine;

namespace _app.Scripts.Enemy.StateMachine
{
    public class EnemyStateMachine
    {
        public EnemyState CurrentEnemyState { get; set; }
        
        public void Initialize(EnemyState startingState){
            CurrentEnemyState = startingState;
            CurrentEnemyState.EnterState();
        }
        public void ChangeState(EnemyState newState){
            CurrentEnemyState.ExitState();
            CurrentEnemyState = newState;
            CurrentEnemyState.EnterState();
        }
    }
    
}