using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : States
{
    [SerializeField] float attackRange;

    public AttackState(GameObject stateGameObject) : base(stateGameObject)
    {
    }

    public virtual float GetAttackRange()
    {
        return attackRange;
    }

    public override void Update()
    {

    }
}
