using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/PlayerMoveToRange")]
public class PlayerMoveToRange : States
{
    private Vector3 targetPosition;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    public PlayerMoveToRange(GameObject stateGameObject) : base(stateGameObject)
    {
    }
    public override void Start(){
        navMeshAgent = stateGameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    public override void FixedUpdate()
    {
        targetPosition = PlayerInteractionManager.Instance.targetEnemy.transform.position;
        MovePlayer() ;
    }

    private void MovePlayer()
    {
        UnityEngine.AI.NavMeshHit hit;
        // Try to sample the position directly with a small distance
        if (UnityEngine.AI.NavMesh.SamplePosition(targetPosition, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))
        {
            navMeshAgent.SetDestination(hit.position);
        }
        else
        {
            // If the initial sample fails, try with a larger distance
            if (UnityEngine.AI.NavMesh.SamplePosition(targetPosition, out hit, 10.0f, UnityEngine.AI.NavMesh.AllAreas))
            {
                navMeshAgent.SetDestination(hit.position);
            }
            else
            {
                Debug.LogWarning("No se pudo encontrar un punto cercano en la NavMesh. No se pudo mover el NavMeshAgent.");
            }
        }
    }
    public override void Update(){

    }  

   public override void OnExitState()
    {
        base.OnExitState();
    }
}
