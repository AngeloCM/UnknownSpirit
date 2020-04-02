using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.AI.EnemyCode
{
    public class Enemy : MonoBehaviour
    {
        FiniteStateMachine _finiteStateMachine;

        public NavMeshAgent _navMeshAgent;

        public GameObject PlayerReference;

        [SerializeField, Tooltip("The time to wait in Idle State")]
        public int Health = 10;

        [SerializeField, Tooltip("The time to wait in Idle State")]
        public float totalDurationIdle = 2f;

        [SerializeField, Tooltip("The time to wait in Idle State")]
        public float DistanceToNextDestination = 2f;

        [SerializeField, Tooltip("The distance between the Player and Enemy to Atack the Player")]
        public float DistanceToAttackPlayer = 300f;

        [SerializeField, Tooltip("The distance between the Player and Enemy to Explode Enemy on Player")]
        public float DistanceToExplode = 50f;

        public void Awake()
        {
            _finiteStateMachine = new FiniteStateMachine(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Start()
        {
            PlayerReference = GameObject.FindGameObjectWithTag("Player");
        }

        void Update()
        {
            PlayerReference.transform.position = PlayerReference.transform.position;
            _finiteStateMachine.Update();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                if (Health > 0)
                {
                    Health--;
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
