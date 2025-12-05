using UnityEngine;
using UnityEditor.AI;
using UnityEngine.AI;
using System.IO;

public class ST_EnemyAI : MonoBehaviour
{

    public enum State { Patrol, Chase }
    public State currentState;

    [Header("References")]
    public NavMeshAgent agent;
    public Transform playerTarget;

    [Header("Patrol Settings")]
    // List  Waypoints to go
    public Transform[] waypoints;
    // Which point to go now?
    private int currentWaypointIndex = 0;
    // Wait on Waypoint
    public float waitTimer = 0f;

    [Header("Detection")]
    // How far the enemy see
    public float detectionRange = 10f;

    void Start()
    {
        // Gets the NavMesh Agent of the Enemy
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        // Moves to the first waypoint when starting the game
        if (waypoints.Length > 0) 
        {
            agent.SetDestination(waypoints[0].position);
        }
    }

    void Update()
    {
        // Switches from protrol to chase logic
        switch (currentState)
        {
            case State.Patrol:
                PatrolLogic();
                CheckForPlayer();
                break;
            case State.Chase:
                ChaseLogic();
                CheckIfLostPlayer();
                break;
        }
    }
    void PatrolLogic()
    {
        // Do nothing if no waypoint
        if (waypoints.Length == 0) return;
        
        // Check if the enemy reached the current waypoint
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            // Start wait timer
            waitTimer += Time.deltaTime;
            // Only move after waiting
            if (waitTimer > 2.0f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                agent.SetDestination(waypoints[currentWaypointIndex].position);
                waitTimer = 0f; // Reset timer
            }
        }
    }
    void ChaseLogic()
    {
        //move to the player
        if (playerTarget != null)
        {
            agent.SetDestination(playerTarget.position);
        }
    }

    void CheckForPlayer()
    {
        // Check distance from the player?
        float dist = Vector3.Distance(transform.position, playerTarget.position);
        if (dist < detectionRange)
        {
            currentState = State.Chase;
        }
    }
    void CheckIfLostPlayer()
    {
        //Is player gone?
        float dist = Vector3.Distance(transform.position,playerTarget.position);
        // Multiplier adds a "buffer" to prevent flickering
        if (dist > detectionRange * 1.5f) 
{
            currentState = State.Patrol;
            // Resume pathing to the last known waypoint
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
