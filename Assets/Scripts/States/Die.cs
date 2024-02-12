using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Die : State
{
    public Die(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) : base(_npc, _agent, _anim, _player)
    {
        _name = STATE.DIE;
        _agent.isStopped = true;
    }

    public override void Enter()
    {
        _anim.SetTrigger("isDead");
        base.Enter();
    }

    public override void Update()
    {

    }
    public override void Exit()
    {
        base.Exit();
    }
}
