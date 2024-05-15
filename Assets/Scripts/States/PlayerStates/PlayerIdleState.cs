using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "States/PlayerIdleState")]
public class PlayerIdleState : States
{
    private Rigidbody rigidBody;

    public PlayerIdleState(GameObject stateGameObject) : base(stateGameObject)
    {
    }

    public override void Start(){
        rigidBody = stateGameObject.GetComponent<Rigidbody>();
        
        
    }
    public override void Update()
    { 
        
    }
    public override void OnExitState()
    {
        base.OnExitState();
    }
    
}