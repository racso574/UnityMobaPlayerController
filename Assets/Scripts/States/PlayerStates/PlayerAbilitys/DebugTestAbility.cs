using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Abilitys/DebugTestAbility")]
public class DebugTestAbility : Ability
{
    public int abilitytestingnumber;
    public override void OnEnterState(GameObject stateGameObject)
    {
        Debug.Log("ability" + abilitytestingnumber);
    }


    public override void OnExitState()
    {

    }

    public override void AbilityUpdate()
    {

    }
}
