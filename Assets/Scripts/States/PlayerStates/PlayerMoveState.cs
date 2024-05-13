using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

[CreateAssetMenu(menuName = "States/PlayerMoveState")]
public class PlayerMoveState : States
{
    private Rigidbody rigidBody;
    private RotateCharacter rotateCharacter;
    private Vector3 targetPosition;
    private NavMeshAgent navMeshAgent;

    public PlayerMoveState(GameObject stateGameObject) : base(stateGameObject)
    {
    }

    public override States CheckTransitions()
    {
        States newGameState = null;
        if (rigidBody.velocity == Vector3.zero)
        {
            newGameState = base.CheckTransitions();
        }
        
        
        return newGameState;
    }
  
    public override void Start()
    {
        rigidBody = stateGameObject.GetComponent<Rigidbody>();
        rotateCharacter = stateGameObject.GetComponent<RotateCharacter>();
        navMeshAgent = stateGameObject.GetComponent<NavMeshAgent>();
    }

    public new void OnEnterState()
    {
       Debug.Log("oensmoverse");
       
    }

    private void GetMovingPoint(){
        targetPosition = PlayerReferences.instance.GetMouseTargetDir();
        targetPosition.y = stateGameObject.transform.position.y;
        stateGameObject.transform.rotation = rotateCharacter.RotateTowardsPoint(targetPosition, stateGameObject.transform.position);
    }


    public override void FixedUpdate()
    {
         if (PlayerInputController.Instance.IsMoving())
        {
            GetMovingPoint();
             navMeshAgent.velocity = Vector3.zero;         
        }
        
        MovePlayer();
       
    }

    private void MovePlayer()
    {
        NavMeshHit hit;
        // Try to sample the position directly with a small distance
        if (NavMesh.SamplePosition(targetPosition, out hit, 1.0f, NavMesh.AllAreas))
        {
            navMeshAgent.SetDestination(hit.position);
        }
        else
        {
            // If the initial sample fails, try with a larger distance
            if (NavMesh.SamplePosition(targetPosition, out hit, 10.0f, NavMesh.AllAreas))
            {
                navMeshAgent.SetDestination(hit.position);
                Debug.LogWarning("La posición de destino estaba fuera del NavMesh. Moviendo al punto más cercano en la NavMesh.");
            }
            else
            {
                Debug.LogWarning("No se pudo encontrar un punto cercano en la NavMesh. No se pudo mover el NavMeshAgent.");
            }
        }
    }


    public override void Update()
    {
        // Implementar lógica de actualización si es necesario
    }
    
    public override void OnExitState()
    {
        base.OnExitState();
    }

}

