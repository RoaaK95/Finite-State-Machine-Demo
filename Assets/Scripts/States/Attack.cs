using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : State
{
    private float _rotSpeed = 2.0f;
    private AudioSource _audioSource;
    private AudioClip _FireSfx;
    public Attack(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) : base(_npc, _agent, _anim, _player)
    {
        _name = STATE.ATTACK;
        _audioSource = _agent.GetComponent<AudioSource>();
    }

    public override void Enter()
    {
        _anim.SetTrigger("isAttacking");
        _agent.isStopped = true;
        //_audioSource.PlayOneShot(_FireSfx);
        base.Enter();
    }

    public override void Update()
    {
        Vector3 direction = _player.position - _npc.transform.position;
        float angle = Vector3.Angle(direction, _npc.transform.forward);
        direction.y = 0.0f;

        _npc.transform.rotation = Quaternion.Slerp(_npc.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * _rotSpeed);

        if (!CanAttackPlayer())
        {
            _nextState = new Idle(_npc, _agent, _anim, _player);
            _stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        _anim.ResetTrigger("isAttacking");
        base.Exit();
    }
}
