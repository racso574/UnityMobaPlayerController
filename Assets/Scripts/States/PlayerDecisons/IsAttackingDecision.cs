using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlayerDecisions/IsAtackingDecision")]
public class IsAtackingDecision : Decision
{
   public override bool Decide(StateMachine stateMachine)
    {
        bool aux = false;
        if (PlayerInteractionManager.Instance.playerAction == 2)
        {
            aux = true;
        }
        return aux;
    }
}
