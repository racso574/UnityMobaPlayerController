using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "States/PlayerMoveState")]
public class PlayerMoveState : States
{
    private Rigidbody rigidBody;
    private RotateCharacter rotateCharacter;
    private Vector3 targetPosition;
    private UnityEngine.AI.NavMeshPath path;
    private float elapsed = 0.0f;

    public float moveSpeed = 5f; // Custom movement speed
    public float stoppingDistance = 0.5f; // Custom stopping distance

    public PlayerMoveState(GameObject stateGameObject) : base(stateGameObject)
    {
    }

    public override void Start()
    {
        rigidBody = stateGameObject.GetComponent<Rigidbody>();
        rotateCharacter = stateGameObject.GetComponent<RotateCharacter>();
        path = new UnityEngine.AI.NavMeshPath();
        elapsed = 0.0f;

      
    }
    public override void FixedUpdate()
    {
        targetPosition = PlayerInteractionManager.Instance.MovingTargetPosition;

       CalculatePath();
        
       
            
    }


    private void MovePlayer()
    {
       
    }

    private void CalculatePath(){
            NavMeshHit hit;
        if (NavMesh.SamplePosition(targetPosition, out hit, 1.0f, NavMesh.AllAreas))
        {
            // Si está dentro de la NavMesh, calcula el camino normalmente
            NavMesh.CalculatePath(stateGameObject.transform.position, hit.position, NavMesh.AllAreas, path);
        }
        else
        {
            // Si está fuera de la NavMesh, encuentra el punto más cercano en el plano XY de la NavMesh
            Vector3 targetPosWithoutY = new Vector3(targetPosition.x, 0, targetPosition.z);
            if (NavMesh.SamplePosition(targetPosWithoutY, out hit, 1000.0f, NavMesh.AllAreas))
            {
                // Proyecta verticalmente el punto encontrado en el plano XY hacia la NavMesh
                Vector3 closestPoint = hit.position;
                closestPoint.y = targetPosition.y;

                // Calcula el camino hacia el punto proyectado dentro de la NavMesh
                NavMesh.CalculatePath(stateGameObject.transform.position, closestPoint, NavMesh.AllAreas, path);
            }
            else
            {
                Debug.LogError("No se pudo encontrar un punto dentro de la NavMesh.");
            }
        }
        
        for (int i = 0; i < path.corners.Length - 1; i++)
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);

        for (int i = 0; i < path.corners.Length; i++)
        {
            Debug.Log("Corner " + i + ": " + path.corners[i]);
        }
    }


    public override void Update()
    {
        // Implementar lógica de actualización si es necesario
    }

    public override void OnExitState()
    {
        base.OnExitState();
        rigidBody.velocity = Vector3.zero; // Detener el movimiento cuando se sale del estado
    }
}


