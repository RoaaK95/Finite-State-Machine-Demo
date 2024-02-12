using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walk : State
{
    private int _currentIndex = -1;
    public Walk(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) : base(_npc, _agent, _anim, _player)
    {
        _name = STATE.WALK;
        _agent.speed = 2.0f;
        _agent.isStopped = false;
    }

    public override void Enter()
    {
        float lastDistance = Mathf.Infinity;
        for (int i = 0; i < GameEnvironment.Singleton._Checkpoints.Count; i++)
        {
            GameObject thisWP = GameEnvironment.Singleton._Checkpoints[i];
            float distance = Vector3.Distance(_npc.transform.position, thisWP.transform.position);
            if (distance < lastDistance)
            {
                _currentIndex = i - 1;
                lastDistance = distance;
            }
        }
        _anim.SetTrigger("isWalking");
        base.Enter();
    }

    public override void Update()
    {
        if (_agent.remainingDistance < 1)
        {
            if (_currentIndex >= GameEnvironment.Singleton._Checkpoints.Count - 1)
            {
                _currentIndex = 0;
            }
            else
            {
                _currentIndex++;
            }
            _agent.SetDestination(GameEnvironment.Singleton._Checkpoints[_currentIndex].transform.position);
        }
        if (CanSeePlayer())
        {
            _nextState = new Pursue(_npc, _agent, _anim, _player);
            _stage = EVENT.EXIT;
        }


    }

    public override void Exit()
    {
        _anim.ResetTrigger("isWalking");
        base.Exit();
    }
}
