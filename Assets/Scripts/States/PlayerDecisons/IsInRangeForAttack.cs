using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Decisions/IsInRangeForAttack")]

public class IsInRangeForAttack : Decision
{
    [SerializeField] AttackState attackState;
    public override bool Decide(StateMachine stateMachine)
    {
        return PlayerInteractionManager.Instance.GetTargetDistance(stateMachine.transform.position, PlayerInteractionManager.Instance.targetEnemy.transform.position) < attackState.GetAttackRange();
    }
}
