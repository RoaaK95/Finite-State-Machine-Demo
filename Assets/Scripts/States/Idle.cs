using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{
    public Idle(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) : base(_npc, _agent, _anim, _player)
    {
        _name = STATE.IDLE;
    }

    public override void Enter()
    {
        _anim.SetTrigger("isIdle");
        base.Enter();
    }

    public override void Update()
    {
        if (CanSeePlayer())
        {
          //  _nextState = new Pursue(_npc, _agent, _anim, _player);
            _stage = EVENT.EXIT;
        }

        else if (Random.Range(0, 100) < 10)
        {
            //_nextState = new Walk(_npc, _agent, _anim, _player);
            _stage = EVENT.EXIT;
        }
    }

    public override void Exit() 
    {
        _anim.ResetTrigger("isIdle");
        base.Exit();
    }
}
