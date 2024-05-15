﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField] LayerMask movingLayer;
    [SerializeField] LayerMask enemyLayer;

    private void Update()
    {
        if (PlayerInputController.Instance.IsInteracting())
        {
            var target = GetMouseTargetDir();
            if (target is Vector3 targetPosition)
            {
                // Handle movement or other actions with targetPosition
               // Debug.Log($"Target Position: {targetPosition}");
            }
            else if (target is GameObject targetEnemy)
            {
                // Handle interaction with the enemy
               // Debug.Log($"Target Enemy: {targetEnemy.name}");
            }
        }
    }

    private object GetMouseTargetDir()
    {
        // Get the mouse position on the screen
        Vector3 mousePos = Input.mousePosition;

        // Calculate the direction of the mouse in the world
        Ray castPoint = Camera.main.ScreenPointToRay(mousePos);

        RaycastHit enemyHit;
        if (Physics.Raycast(castPoint, out enemyHit, Mathf.Infinity, enemyLayer))
        {
            // If the enemy is hit, return the enemy game object
            return enemyHit.collider.gameObject;
        }

        RaycastHit groundHit;
        if (Physics.Raycast(castPoint, out groundHit, Mathf.Infinity, movingLayer))
        {
            // If no enemy is hit but the ground is hit, return the ground position
            Vector3 targetDir = groundHit.point;
            targetDir.y = 0f; // Keep in XY plane
            return targetDir;
        }

        // If neither ground nor enemy is hit, return default direction
        Vector3 defaultDir = castPoint.direction;
        defaultDir.y = 0f; // Keep in XY plane
        return defaultDir;
    }
}



