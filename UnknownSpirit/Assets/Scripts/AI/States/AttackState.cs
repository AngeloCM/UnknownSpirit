using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.AI.States
{
    public class AttackState : AbstractFSMState
    {
        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.ATTACK;
        }

        public override bool EnterState()
        {
            EnteredState = base.EnterState();

            if (EnteredState)
            {
                Debug.Log("ENTERED ATTACK STATE " + _enemy.gameObject.name);
            }

            return EnteredState;
        }

        public override void UpdateState()
        {

            if (EnteredState)
            {
                if (Vector3.Distance(_enemy.transform.position, _enemy.PlayerReference.transform.position) > _enemy.DistanceToAttackPlayer)
                {
                    _fsm.EnterState(FSMStateType.WALK);
                    _enemy._navMeshAgent.speed = 5f;
                }
                else
                {
                    AttackPlayer();
                }
            }
        }

        private void AttackPlayer()
        {
            Debug.Log("ATTACKING!");
            _enemy._navMeshAgent.speed = 10f;
            _enemy._navMeshAgent.SetDestination(_enemy.PlayerReference.transform.position);
        }

        public override bool ExitState()
        {
            base.ExitState();

            Debug.Log("EXITING ATTACK STATE");
            return true;
        }
    }
}
