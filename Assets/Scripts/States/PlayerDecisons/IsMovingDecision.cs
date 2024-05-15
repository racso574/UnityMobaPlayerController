using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlayerDecisions/IsMovingDecision")]
public class IsMovingDecision : Decision
{
    public override bool Decide(StateMachine stateMachine)
    {
        bool aux = false;
        if (PlayerInteractionManager.Instance.startMoving)
        {
            //PlayerInteractionManager.Instance.startMoving = false;
            aux = true;
        }
        return aux;
    }
}

