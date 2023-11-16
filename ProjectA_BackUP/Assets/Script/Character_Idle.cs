using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Idle : Character_Statement
{
    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(character.isMoving)
            animator.SetInteger("isMoving", 1);
    }
    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
