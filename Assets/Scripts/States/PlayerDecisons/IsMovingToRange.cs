using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlayerDecisions/IsMovingToRange")]
public class IsMovingToRange : Decision
{
    public override bool Decide(StateMachine stateMachine)
    {
        bool aux = false;
        if (PlayerInteractionManager.Instance.playerAction == 3)
        {
            aux = true;
        }
        return aux;
    }
}
