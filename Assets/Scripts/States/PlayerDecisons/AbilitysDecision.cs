using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerDecisions/AbilitysDecision")]
public class AbilitysDecision : Decision
{
    private float abilityNumber
    public override bool Decide(StateMachine stateMachine)
    {
        bool aux = false;
        if (PlayerInputController.Instance.IsUsingAbility1())
        {
                aux = true;
        }
        return aux;
    }
}
