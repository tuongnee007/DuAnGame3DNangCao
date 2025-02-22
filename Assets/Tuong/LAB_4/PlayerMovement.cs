using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Camera Camera;
    private NavMeshAgent agent;
    private RaycastHit[] Hits = new RaycastHit[1];
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.RaycastNonAlloc(ray, Hits) > 0)
            {
                agent.SetDestination(Hits[0].point);
            }
        }
    }
}
