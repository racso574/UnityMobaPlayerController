using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerDecisions/Ability1Decision")]
public class Ability1Decision : Decision
{
    public override bool Decide(StateMachine stateMachine)
    {
        bool aux = false;
        if (PlayerInputController.Instance.IsUsingAbility1() && PlayerTimers.Instance.abilityTimers[1] > PlayerTimers.Instance.abilityCD[1])
        {
            PlayerInputController.Instance.Ability1Used();
                aux = true;
        }
        return aux;
    }
}
