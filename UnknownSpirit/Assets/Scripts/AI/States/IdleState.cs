using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.AI.States
{
    public class IdleState : AbstractFSMState
    {
        float _totalDuration;

        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.IDLE;
        }

        public override bool EnterState()
        {
            EnteredState = base.EnterState();

            if (EnteredState)
            {
                Debug.Log("ENTERED IDLE STATE " + _enemy.name);
                _totalDuration = 0f;
            }

            return EnteredState;
        }

        public override void UpdateState()
        {
            if (EnteredState)
            {
                _totalDuration += Time.deltaTime;
                Debug.Log("UPDATING IDLE STATE: " + _totalDuration + " seconds.");

                if (_totalDuration >= _enemy.totalDurationIdle)
                {
                    _fsm.EnterState(FSMStateType.WALK);
                }
                else if (Vector3.Distance(_enemy.transform.position, _enemy.PlayerReference.transform.position) <= _enemy.DistanceToAttackPlayer)
                {
                    _fsm.EnterState(FSMStateType.ATTACK);
                }
            }
        }

        public override bool ExitState()
        {
            base.ExitState();

            Debug.Log("EXITING IDLE STATE");
            return true;
        }
    }
}
