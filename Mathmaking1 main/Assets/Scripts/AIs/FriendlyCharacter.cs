using UnityEngine;
using States;

public class FriendlyCharacter : MonoBehaviour {

    StateMachine behaviourMachine;

    void Awake()
    {
        behaviourMachine = new StateMachine(gameObject, StatesEnum.wander); 

        behaviourMachine.AddState(StatesEnum.wander, new Wander("Player", "Animation Pose", new Navigator(0.2f, 50)));
        behaviourMachine.AddState(StatesEnum.alert, new Charge("Player", "Animation Pose"));
        behaviourMachine.AddState(StatesEnum.intaract, new Attack("Player", "Animation Pose"));
        behaviourMachine.AddState(StatesEnum.retreat, new Flee("Player", "Animation Pose"));
        behaviourMachine.AddState(StatesEnum.idle, new Idle("Player", "Animation Pose"));

        behaviourMachine.Start();
    }

    void Update()
    {
        behaviourMachine.UpdateState();  
    }
}
