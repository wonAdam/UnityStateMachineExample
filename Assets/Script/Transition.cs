using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition<T> where T : IStateMachineOwner
{
    public virtual bool Evaluate() { return false; }
}

public class SimpleLambdaTransition<T> : Transition<T> where T : IStateMachineOwner
{
    public SimpleLambdaTransition(Func<bool> predicate)
    {
        _predicate = predicate;
    }

    private Func<bool> _predicate;

    public override bool Evaluate()
    {
        return _predicate.Invoke();
    }
}

