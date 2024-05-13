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
    public float playerSpeed;

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
        GetMovingPoint();  
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
        // Vector3 currentPosition = stateGameObject.transform.position;
        // Vector3 moveDirection = (targetPosition - currentPosition).normalized;

        // // Si ya estamos cerca del objetivo, detener el movimiento
        // if (Vector3.Distance(currentPosition, targetPosition) < 0.1f)
        // {
        //     rigidBody.velocity = Vector3.zero;
        //     return;
        // }

        // // Calcular la velocidad deseada
        // Vector3 desiredVelocity = moveDirection * playerSpeed;

        // // Calcular la fuerza necesaria para alcanzar la velocidad deseada
        // Vector3 force = (desiredVelocity - rigidBody.velocity) * rigidBody.mass / Time.fixedDeltaTime;

        // // Aplicar la fuerza al Rigidbody
        // rigidBody.AddForce(force);

        if (NavMesh.SamplePosition(targetPosition, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
        {
            navMeshAgent.SetDestination(hit.position);
        }
        else
        {
            // La posición de destino está fuera del NavMesh, busca la posición más cercana
            if (NavMesh.FindClosestEdge(targetPosition, out hit, NavMesh.AllAreas))
            {
                navMeshAgent.SetDestination(hit.position);
                Debug.LogWarning("La posición de destino está fuera del NavMesh. Moviendo al punto más cercano en la NavMesh.");
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

