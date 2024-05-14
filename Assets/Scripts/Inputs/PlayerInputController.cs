using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerInputController : MonoBehaviour
{

    static public PlayerInputController Instance { get; private set; }
    
    private bool isInteracting;
    private bool isUsingAbility1;
    private bool isUsingAbility2;
    private bool isUsingAbility3;
    private bool isUsingAbility4;

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

    public void OnPlayerInteraction(InputValue inputValue)
    {
        if (inputValue.isPressed)
            isInteracting = true;
        else
            isInteracting = false;
    }
    public bool IsInteracting()
    {
        return isInteracting;
    }

    public void OnAbility1(InputValue inputValue)
    {
        if (!inputValue.isPressed)
        {
            isUsingAbility1 = false;
        }
        else
        {
            isUsingAbility1 = true;
        }
    }
    public bool IsUsingAbility1()
    {
        return isUsingAbility1;
    }

    public void OnAbility2(InputValue inputValue)
    {
        if (!inputValue.isPressed)
        {
            isUsingAbility2 = false;
        }
        else
        {
            isUsingAbility2 = true;
        }
    }
    public bool IsUsingAbility2()
    {
        return isUsingAbility2;
    }
    public void OnAbility3(InputValue inputValue)
    {
        if (!inputValue.isPressed)
        {
            isUsingAbility3 = false;
        }
        else
        {
            isUsingAbility3 = true;
        }
    }
    public bool IsUsingAbility3()
    {
        return isUsingAbility3;
    }
    public void OnAbility4(InputValue inputValue)
    {
        if (!inputValue.isPressed)
        {
            isUsingAbility4 = false;
        }
        else
        {
            isUsingAbility4 = true;
        }
    }
    public bool IsUsingAbility4()
    {
        return isUsingAbility4;
    }
   
}

