using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/PlayerBasicAtackState")]
public class PlayerBasicAtackState : AttackState
{
    public float attackRange;
    public PlayerBasicAtackState(GameObject stateGameObject) : base(stateGameObject)
    {
    }
    public override void Start(){
        
    }
    public override void FixedUpdate()
    {
       if (PlayerInteractionManager.Instance.GetTargetDistance(stateGameObject.transform,PlayerInteractionManager.Instance.targetEnemy) <= attackRange){
        Debug.Log("attacando shes");
       }else{
        PlayerInteractionManager.Instance.playerAction = 3;
       }
    }
    public override void Update(){

    }  

   public override void OnExitState()
    {
        base.OnExitState();
    }
}
