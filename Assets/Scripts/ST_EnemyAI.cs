using UnityEngine;
using UnityEditor.AI;
using UnityEngine.AI;

public class ST_EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform playerTarget;
    void Start()
    {
        //Gets the NavMesh Agent of the Enemy
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }

    void Update()
    {
        //Moves towards the player postion
        if (playerTarget != null)
        {
            agent.SetDestination(playerTarget.position);
        }
    }
}
