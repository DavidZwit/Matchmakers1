using UnityEngine;

class StateTemplate : State {

    GameObject obj;
    Animation anim;
    string animString;
    StatesEnum returnState;

    public StateTemplate ()
    {

    }

    public void Enter(GameObject theObject, Animation _anim)
    {
        obj = theObject;
    }

    public bool Reason()
    {
        Debug.Log("reason");
        return true;
    }

    public void Act()
    {
        Debug.Log("act");
    }

    public StatesEnum Leave()
    {
        Debug.Log("leave");
        return returnState;
    }
}
