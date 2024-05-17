using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "States/PlayerMoveState")]
public class PlayerMoveState : States
{
    private Rigidbody rb;
    private RotateCharacter rc;

    private Vector3 targetPosition;
    private Vector3 newTargetPosition;

    private UnityEngine.AI.NavMeshPath path;
    private int pathIndex;

    public float moveSpeed;// Custom movement speed

    public PlayerMoveState(GameObject stateGameObject) : base(stateGameObject)
    {
    }

public override void Start()
{
    rb = stateGameObject.GetComponent<Rigidbody>();
    rc = stateGameObject.GetComponent<RotateCharacter>();
    path = new UnityEngine.AI.NavMeshPath();
    targetPosition = PlayerInteractionManager.Instance.MovingTargetPosition;
    CalculatePath();
    pathIndex = 1;
}

public override void FixedUpdate()
{
    newTargetPosition = PlayerInteractionManager.Instance.MovingTargetPosition;
    if (targetPosition != newTargetPosition)
    {
        targetPosition = newTargetPosition;
        CalculatePath();
        pathIndex = 1;
    }

    if (path.corners.Length > 1)
    {
        float distanceToNextPoint = PlayerInteractionManager.Instance.GetTargetDistance(stateGameObject.transform.position, path.corners[pathIndex]);

        if (distanceToNextPoint < 0.92f)
        {
            if (pathIndex < path.corners.Length - 1)
            {
                pathIndex++;
            }
            else
            {
                // Hemos llegado al último punto
                Debug.Log("Ya he llegado");
                rb.velocity = Vector3.zero;
                PlayerInteractionManager.Instance.playerAction = 0;
                return; // Salir del método para evitar movimiento adicional
            }
        }
        
        stateGameObject.transform.rotation = rc.RotateTowardsPoint(path.corners[pathIndex], stateGameObject.transform.position);
        MovePlayer();
    }
}

private void MovePlayer()
{
    if (path.corners.Length > 1 && pathIndex < path.corners.Length)
    {
        Vector3 direction = (path.corners[pathIndex] - stateGameObject.transform.position).normalized;
        Vector3 newPosition = stateGameObject.transform.position + direction * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
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
        
        // for (int i = 0; i < path.corners.Length - 1; i++)
        //     Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);

        // for (int i = 0; i < path.corners.Length; i++)
        // {
        //     Debug.Log("Corner " + i + ": " + path.corners[i]);
        // }
    }


    public override void Update()
    {
        // Implementar lógica de actualización si es necesario
    }

    public override void OnExitState()
    {
        base.OnExitState();
        rb.velocity = Vector3.zero; // Detener el movimiento cuando se sale del estado
    }
}


