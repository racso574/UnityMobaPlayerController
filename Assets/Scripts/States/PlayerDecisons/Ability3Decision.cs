using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerDecisions/Ability3Decision")]
public class Ability3Decision : Decision
{
    public override bool Decide(StateMachine stateMachine)
    {
        bool aux = false;
        if (PlayerInputController.Instance.IsUsingAbility3() && PlayerTimers.Instance.abilityTimers[3] > PlayerTimers.Instance.abilityCD[3])
        {
            PlayerInputController.Instance.Ability3Used();
            aux = true;
        }
        return aux;
    }
}
