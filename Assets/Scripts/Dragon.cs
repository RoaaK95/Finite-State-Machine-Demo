using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragon : MonoBehaviour
{
    private NavMeshAgent _agent;
    private State _currentState;
    private Animator _anim;
    [SerializeField] private Transform _player;
    private float _startTime = 2.0f;
    private float _freq = 1.0f;
    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    void Start()
    {
        _currentState = new Idle(gameObject, _agent, _anim, _player);
        InvokeRepeating("UpateProcess", _startTime, _freq);
    }
    void UpateProcess()
    {
        _currentState = _currentState.Process();
    }
}
