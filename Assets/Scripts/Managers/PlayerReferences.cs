using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReferences : MonoBehaviour
{
    
    public static PlayerReferences instance;
    [SerializeField] LayerMask groundMask;
  

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Debug.Log("Manager PLayerReferences already exists");
    }
    public Vector3 GetMouseTargetDir()
    {
        // Obtener la posici�n del rat�n en la pantalla
        Vector3 mousePos = Input.mousePosition;

        // Calcular la direcci�n del rat�n en el mundo
        Ray castPoint = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        Vector3 targetDir = Vector3.zero;

        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity,groundMask))
        { 
            targetDir = hit.point; // Conseguir la direccion a la que esta apuntando el raton en el mundo
            targetDir.y = 0f; // Mantener en el plano XY
        }
        else
        {
            targetDir = castPoint.direction;
            targetDir.y = 0f; // Mantener en el plano XY
        }
        //Debug.Log(targetDir);
        return targetDir;
    }

}
