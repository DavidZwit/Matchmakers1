using UnityEngine;

namespace States { 
class Idle : State{

    GameObject obj;
    Animation anim;
    StatesEnum returnState;

    string alertTag, animString;
    float alertRange, idleTime;

    float timeLeft;

    public Idle(string _alertTag, string _animString = "[A][I]Add the correct animation name to the state[A][I]",
        float _alertRange = 20, float _idleTime = 2)
    {
        alertTag = _alertTag;
        animString = _animString;
        alertRange = _alertRange;
        idleTime = _idleTime;
        timeLeft = idleTime;
    }

    public void Enter(GameObject theObject, Animation _anim)
    {
        obj = theObject;
        anim = _anim;
        timeLeft = idleTime;
    }

    public bool Reason()
    {
        Collider[] objectsInRange = Physics.OverlapSphere(obj.transform.position, alertRange);

        if (timeLeft < 0) {
            returnState = StatesEnum.wander;
            return false;
        }
        for (int i = 0; i < objectsInRange.Length; i++) {
            if (objectsInRange[i].tag == alertTag) {
                returnState = StatesEnum.alert;
                return false;
            }
        }
        return true;
    }

    public void Act()
    {
        timeLeft -= Time.deltaTime;
        if (anim && !anim.IsPlaying(animString)) anim.Play(animString);
    }

    public StatesEnum Leave()
    {
        return returnState;
    }
}
}