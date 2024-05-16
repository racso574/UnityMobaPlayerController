using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/PlayerBasicAtackState")]
public class PlayerBasicAtackState : States
{
    public float attackRange;
    public PlayerBasicAtackState(GameObject stateGameObject) : base(stateGameObject)
    {
    }
    public override void Start(){
        Debug.Log("ataque piu");
    }
    public override void FixedUpdate()
    {
       
    }
    public override void Update(){

    }  

   public override void OnExitState()
    {
        base.OnExitState();
    }
}
