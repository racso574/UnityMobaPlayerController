using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerDecisions/Ability2Decision")]
public class Ability2Decision : Decision
{
    public override bool Decide(StateMachine stateMachine)
    {
        bool aux = false;
        if (PlayerInputController.Instance.IsUsingAbility2() && PlayerTimers.Instance.abilityTimers[2] > PlayerTimers.Instance.abilityCD[2])
        {
            PlayerInputController.Instance.Ability2Used();
            aux = true;
        }
        return aux;
    }
}
