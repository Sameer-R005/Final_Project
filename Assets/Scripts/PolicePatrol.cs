using UnityEngine;
using UnityEngine.AI;

public class PolicePatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float waitTimeAtPoint = 2f;

    private NavMeshAgent agent;
    private Animator animator;
    private int currentPointIndex = 0;
    private float waitTimer;
    private bool waiting;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (patrolPoints == null || patrolPoints.Length == 0)
        {
            Debug.LogWarning($"{gameObject.name}: No patrol points assigned.");
            enabled = false;
            return;
        }

        if (!agent.isOnNavMesh)
        {
            Debug.LogError($"{gameObject.name}: NavMeshAgent is not on a NavMesh.");
            enabled = false;
            return;
        }

        GoToPoint(currentPointIndex);
    }

    void Update()
    {
        if (animator != null)
        {
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }

        if (waiting)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= waitTimeAtPoint)
            {
                waiting = false;
                GoToNextPoint();
            }

            return;
        }

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude < 0.01f)
            {
                waiting = true;
                waitTimer = 0f;
            }
        }
    }

    void GoToPoint(int index)
    {
        if (patrolPoints[index] != null)
        {
            agent.SetDestination(patrolPoints[index].position);
        }
    }

    void GoToNextPoint()
    {
        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        GoToPoint(currentPointIndex);
    }
}