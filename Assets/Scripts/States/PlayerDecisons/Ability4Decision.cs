using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerDecisions/Ability4Decision")]
public class Ability4Decision : Decision
{
    public override bool Decide(StateMachine stateMachine)
    {
        bool aux = false;
        if (PlayerInputController.Instance.IsUsingAbility4() && PlayerTimers.Instance.abilityTimers[4] > PlayerTimers.Instance.abilityCD[4])
        {
            aux = true;
        }
        return aux;
    }
}
