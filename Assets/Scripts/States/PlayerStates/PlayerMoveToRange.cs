using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/PlayerMoveToRange")]
public class PlayerMoveToRange : States
{

     private Rigidbody rb;
    private RotateCharacter rc;

    private Vector3 targetPosition;
    private Vector3 newTargetPosition;

    private UnityEngine.AI.NavMeshPath path;
    private int pathIndex;

    public float moveSpeed;
    
    public PlayerMoveToRange(GameObject stateGameObject) : base(stateGameObject)
    {
    }
    public override void Start(){
        rb = stateGameObject.GetComponent<Rigidbody>();
        rc = stateGameObject.GetComponent<RotateCharacter>();
        path = new UnityEngine.AI.NavMeshPath();
        targetPosition = PlayerInteractionManager.Instance.targetEnemy.transform.position;
        CalculatePath();
        pathIndex = 1;
    }
    public override void FixedUpdate()
    {
        
        newTargetPosition = PlayerInteractionManager.Instance.targetEnemy.transform.position;
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
            UnityEngine.AI.NavMeshHit hit;
        if (UnityEngine.AI.NavMesh.SamplePosition(targetPosition, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))
        {
            // Si está dentro de la NavMesh, calcula el camino normalmente
            UnityEngine.AI.NavMesh.CalculatePath(stateGameObject.transform.position, hit.position, UnityEngine.AI.NavMesh.AllAreas, path);
        }
        else
        {
            // Si está fuera de la NavMesh, encuentra el punto más cercano en el plano XY de la NavMesh
            Vector3 targetPosWithoutY = new Vector3(targetPosition.x, 0, targetPosition.z);
            if (UnityEngine.AI.NavMesh.SamplePosition(targetPosWithoutY, out hit, 1000.0f, UnityEngine.AI.NavMesh.AllAreas))
            {
                // Proyecta verticalmente el punto encontrado en el plano XY hacia la NavMesh
                Vector3 closestPoint = hit.position;
                closestPoint.y = targetPosition.y;

                // Calcula el camino hacia el punto proyectado dentro de la NavMesh
                UnityEngine.AI.NavMesh.CalculatePath(stateGameObject.transform.position, closestPoint, UnityEngine.AI.NavMesh.AllAreas, path);
            }
            else
            {
                Debug.LogError("No se pudo encontrar un punto dentro de la NavMesh.");
            }
        }
      }
    public override void Update(){

    }  

   public override void OnExitState()
    {
        PlayerInteractionManager.Instance.playerAction = 2;
    }
}
