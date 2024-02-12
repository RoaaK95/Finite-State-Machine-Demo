using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class State
{
    public enum STATE
    { IDLE, WALK, PURSUE, ATTACK, DIE };
    public enum EVENT
    { ENTER, UPDATE, EXIT };

    public STATE _name;
    protected EVENT _stage;
    protected GameObject _npc;
    protected Animator _anim;
    protected NavMeshAgent _agent;
    protected Transform _player;
    protected State _nextState;

    private float _visDis = 20.0f;
    private float _visAngle = 30.0f;
    private float _fireDist = 12.0f;

    public State(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
    {
        this._npc = _npc;
        this._agent = _agent;
        this._anim = _anim;
        this._player = _player;
        _stage = EVENT.ENTER;
    }

    public virtual void Enter() { _stage = EVENT.UPDATE; }
    public virtual void Update() { _stage = EVENT.UPDATE; }
    public virtual void Exit() { _stage = EVENT.EXIT; }

    public State Process()
    {
        if (_stage == EVENT.ENTER) Enter();
        if (_stage == EVENT.UPDATE) Update();
        if (_stage == EVENT.EXIT)
        {
            Exit();
            return _nextState;
        }
        return this;
    }

    public bool CanSeePlayer()
    {
        Vector3 direction = _player.position - _npc.transform.position;
        float angle = Vector3.Angle(direction, _npc.transform.position);
        if (direction.magnitude < _visDis && angle < _visAngle)
        {
            return true;
        }
        return false;
    }
    public bool CanAttackPlayer()
    {
        Vector3 direction = _player.position - _npc.transform.position;
        if (direction.magnitude < _fireDist)
        {
            return true;
        }
        return false;
    }
}
