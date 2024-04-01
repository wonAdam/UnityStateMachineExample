using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateMachineOwner
{ 
}

public class Warrior : MonoBehaviour, IStateMachineOwner
{
    private StateMachine<Warrior> _stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        _stateMachine = new StateMachine<Warrior>();

        var Idle = new WarriorIdle(this);
        var RunRight = new WarriorRunRight(this);
        var RunLeft = new WarriorRunLeft(this);

        Idle.AddTransition(RunRight, new SimpleLambdaTransition<Warrior>(() =>
        {
            return Input.GetKey(KeyCode.D);
        }));
        Idle.AddTransition(RunLeft, new SimpleLambdaTransition<Warrior>(() =>
        {
            return Input.GetKey(KeyCode.A);
        }));
        RunRight.AddTransition(Idle, new SimpleLambdaTransition<Warrior>(() =>
        {
            return !Input.GetKey(KeyCode.D);
        }));
        RunLeft.AddTransition(Idle, new SimpleLambdaTransition<Warrior>(() =>
        {
            return !Input.GetKey(KeyCode.A);
        }));

        _stateMachine.Init(Idle);
    }

    // Update is called once per frame
    void Update()
    {
        _stateMachine.Tick();
    }
}


public class WarriorIdle : State<Warrior>
{
    private Animator animator;
    public WarriorIdle(Warrior owner) : base(owner)
    {
    }

    public override void Enter()
    {
        if (animator == null)
        {
            animator = _owner.GetComponent<Animator>();
        }
        animator.Play("Warrior_Idle", 0);
    }
}


public class WarriorRun : State<Warrior>
{
    private Animator animator;

    public WarriorRun(Warrior owner) : base(owner)
    {
    }

    public override void Enter()
    {
        if (animator == null)
        {
            animator = _owner.GetComponent<Animator>();
        }
        animator.Play("Warrior_Run", 0);
    }

    public override void Tick()
    {
    }
}


public class WarriorRunRight : WarriorRun
{
    public WarriorRunRight(Warrior owner) : base(owner)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _owner.transform.localScale = new Vector3(1, 1, 1);
    }
}

public class WarriorRunLeft : WarriorRun
{
    public WarriorRunLeft(Warrior owner) : base(owner)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _owner.transform.localScale = new Vector3(-1, 1, 1);
    }
}


