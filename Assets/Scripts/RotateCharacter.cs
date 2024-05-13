using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCharacter : MonoBehaviour
{

    public Quaternion Rotate(Quaternion objectCurrentRotation, Vector3 direction)
    {
        Quaternion rotation = Quaternion.Lerp(objectCurrentRotation, Quaternion.LookRotation(direction, Vector3.up), 0.5f);
        return rotation;
    }

    public Quaternion Rotate(Quaternion objectCurrentRotation, Vector3 direction, float rotationSmoothness)
    {
        Quaternion rotation = Quaternion.Lerp(objectCurrentRotation, Quaternion.LookRotation(direction, Vector3.up), 0.5f);
        return rotation;
    }


    public Quaternion NonSmoothenedRotation(Vector3 direction)
    {
        // Calcula la rotación respecto al eje Y usando LookRotation
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        
        // Extrae la rotación solo en el eje Y
        Quaternion yRotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
        
        return yRotation;
    }

     public Quaternion RotateTowardsPoint(Vector3 point, Vector3 playerpos)
    {
        // Calcula la dirección desde la posición actual del jugador hacia el punto deseado
        Vector3 direction = point - playerpos;

        // Para asegurarnos de que la rotación solo se aplique en el eje Y, eliminamos las componentes X y Z de la dirección
        direction.y = 0f;

        // Si la dirección es cero, no hay necesidad de rotación
    
            // Normaliza la dirección para obtener un vector de dirección unitario
            direction.Normalize();

            // Calcula el ángulo de rotación en radianes basado en la dirección
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // Crea una Quaternion que solo rote alrededor del eje Y
            Quaternion targetRotation = Quaternion.Euler(0f, angle, 0f);

            // Aplica la rotación al jugador
           return targetRotation;
        
        
    }

    


}
