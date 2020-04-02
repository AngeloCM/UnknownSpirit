using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.AI.States
{
    public class WalkState : AbstractFSMState
    {
        Vector3 _nextWalkDestination;

        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.WALK;
        }

        public override bool EnterState()
        {
            EnteredState = false;

            if (base.EnterState())
            {
                if (_nextWalkDestination == null)
                {
                    Debug.Log("MISSING DESTINATION");
                }
                else
                {
                    getNextDestination();
                    EnteredState = true;
                }
            }

            if (EnteredState)
            {
                Debug.Log("ENTERED WALK STATE " + _enemy.gameObject.name);
            }

            return EnteredState;
        }

       

        public override void UpdateState()
        {
            if (EnteredState)
            {
                //Logic
                if (Vector3.Distance(_enemy.transform.position, _nextWalkDestination) <= _enemy.DistanceToNextDestination)
                {
                    _fsm.EnterState(FSMStateType.IDLE);
                }
                else if (Vector3.Distance(_enemy.transform.position, _enemy.PlayerReference.transform.position) <= _enemy.DistanceToAttackPlayer)
                {
                    _fsm.EnterState(FSMStateType.ATTACK);
                }
                else
                {
                    SetDestination();
                    Debug.Log("KEEP WALKING");
                }
            }
        }

        private void SetDestination()
        {
            Debug.Log("WALKING");
            _enemy._navMeshAgent.SetDestination(_nextWalkDestination);
        }

        private void getNextDestination()
        {
            _nextWalkDestination = new Vector3(UnityEngine.Random.Range(-24f, 24f), _enemy.transform.position.y, UnityEngine.Random.Range(-24f, 24f));
        }


        public override bool ExitState()
        {
            base.ExitState();

            Debug.Log("EXITING FLY STATE");
            return true;
        }
    }
}
