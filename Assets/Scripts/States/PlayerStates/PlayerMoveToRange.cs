using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/PlayerMoveToRange")]
public class PlayerMoveToRange : States
{
    public PlayerMoveToRange(GameObject stateGameObject) : base(stateGameObject)
    {
    }
    public override void Start(){
        base.Start();
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
