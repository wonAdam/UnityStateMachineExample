using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> where T : IStateMachineOwner
{
    private State<T> _currentState;

    public void Init(State<T> initialState)
    {
        _currentState = initialState;
    }

    public void Tick()
    {
        _currentState.Tick();
        foreach(var pair in _currentState.Transitions)
        {
            var transition = pair.Key;
            var dest = pair.Value;

            if (transition.Evaluate() == false)
                continue;

            _currentState.Exit();
            dest.Enter();
            _currentState = dest;
        }
    }
}
