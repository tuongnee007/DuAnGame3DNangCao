using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    public enum Enemystate { Idle, Moving, SpeedBoost }
    public Enemystate currentState = Enemystate.Idle;

    public Transform target;
    public float updateSpeed = 0.1f;
    public float speedBoostMultiplier = 2f;
    public float speedBoostDuration = 2f;
    public float stopDistance = 0.5f;
    public GameObject panelUI;

    private NavMeshAgent agent;
    private float totalDistance;
    private float traveledDistance;
    private float nextTriggerDistance;
    private bool isPerformingAction = false;
    private Vector3 lastPosition;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agent.SetDestination(target.position);
        StartCoroutine(CalculateTotalPathDistance());
        StartCoroutine(StateMachine());

        if (panelUI != null)
        {
            panelUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (!isPerformingAction && agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            StopEnemyAndShowPanel();
        }
    }

    private IEnumerator CalculateTotalPathDistance()
    {
        yield return new WaitForSeconds(0.5f);
        while (!agent.hasPath)
            yield return null;

        totalDistance = GetPathLength(agent.path);
        nextTriggerDistance = totalDistance / 3f;
        traveledDistance = 0f;
        lastPosition = transform.position;
    }

    private IEnumerator StateMachine()
    {
        WaitForSeconds wait = new WaitForSeconds(updateSpeed);
        while (true)
        {
            switch (currentState)
            {
                case Enemystate.Idle:
                    yield return new WaitForSeconds(1f);
                    currentState = Enemystate.Moving;
                    break;

                case Enemystate.Moving:
                    if (!isPerformingAction)
                    {
                        traveledDistance += Vector3.Distance(lastPosition, transform.position);
                        lastPosition = transform.position;

                        if (traveledDistance >= nextTriggerDistance)
                        {
                            nextTriggerDistance += totalDistance / 3f;
                            StartCoroutine(SpeedBoost());
                        }
                    }
                    break;
            }
            yield return wait;
        }
    }

    private IEnumerator SpeedBoost()
    {
        currentState = Enemystate.SpeedBoost;
        agent.speed *= speedBoostMultiplier;
        yield return new WaitForSeconds(speedBoostDuration);
        agent.speed /= speedBoostMultiplier;
        currentState = Enemystate.Moving;
    }

    private float GetPathLength(NavMeshPath path)
    {
        float length = 0f;
        if (path.corners.Length < 2)
            return length;
        for (int i = 1; i < path.corners.Length; i++)
        {
            length += Vector3.Distance(path.corners[i - 1], path.corners[i]);
        }
        return length;
    }

    private void StopEnemyAndShowPanel()
    {   
        agent.isStopped = true;

        if (panelUI != null)
        {
            panelUI.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
        else
        {
            Debug.LogError(" panelUI chưa được gán");
        }
    }
}
