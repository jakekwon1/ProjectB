using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character_Statement : StateMachineBehaviour
{
    protected Character character;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (character == null)
            character = animator.GetComponent<Character>();
        StateEnter(animator, stateInfo, layerIndex);
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateUpdate(animator, stateInfo, layerIndex);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateExit(animator, stateInfo, layerIndex);
    }

    virtual public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    virtual public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    virtual public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
