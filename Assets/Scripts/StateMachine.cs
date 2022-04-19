using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private static StateMachine instance = null;
    private static readonly object padlock = new object();

    private State state { get; set; }

    private StateMachine() { }

    public static StateMachine Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new StateMachine();
                    instance.InitializeStateMachine();
                    Debug.Log("State machine instanced and Initialized\nCurrent State: " + instance.state.name()) ;
                }
                return instance;
            }
        }
    }

    private void InitializeStateMachine()
    {
        state = new TestState();
    }
}
