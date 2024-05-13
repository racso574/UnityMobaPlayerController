using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerInputController : MonoBehaviour
{

    static public PlayerInputController Instance { get; private set; }
    
    private bool isMoving;

    private void Start()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Este singleton esta ya puesto en escena: " + gameObject.name);
            Destroy(gameObject);
        }

    }

    public void OnMoving(InputValue inputValue)
    {
        if (inputValue.isPressed)
            isMoving = true;
        else
            isMoving = false;
    }
    public bool IsMoving()
    {
        return isMoving;
    }

   
}

