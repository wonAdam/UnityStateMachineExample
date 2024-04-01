using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class State<T> where T : IStateMachineOwner
{
    protected T _owner;

    public State(T owner)
    {
        _owner = owner;
    }

    public virtual void Enter() {}
    public virtual void Tick() {}
    public virtual void Exit() {}

    public void AddTransition(State<T> destination, Transition<T> transition) 
    { 
        _transitions.Add(transition, destination); 
    }

    private Dictionary<Transition<T>, State<T>> _transitions = new Dictionary<Transition<T>, State<T>>();

    public Dictionary<Transition<T>, State<T>> Transitions { get => _transitions; }

}
