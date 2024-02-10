using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pursue : State
{
    public Pursue(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) : base(_npc, _agent, _anim, _player)
    {
        _name = STATE.PURSUE;
        _agent.speed = 5.0f;
        _agent.isStopped = false;
    }

    public override void Enter()
    {
        _anim.SetTrigger("isPursuing");
        base.Enter();
    }

    public override void Update()
    {
        _agent.SetDestination(_player.position);
        if (_agent.hasPath)
        {
            if (CanAttackPlayer())
            {
                // _nextState = new Attack(_npc, _agent, _anim, _player);
                _stage = EVENT.EXIT;
            }
            else if (!CanSeePlayer())
            {
                _nextState = new Walk(_npc, _agent, _anim, _player);
                _stage = EVENT.EXIT;
            }

        }
    }

    public override void Exit()
    {
        _anim.ResetTrigger("isPursuing");
        base.Exit();
    }
}
