using UnityEngine;

namespace States { 
class Wander : State {

    GameObject obj;
    Animation anim;
    NavMeshAgent agent;
    NavigatorInterface nav;
    StatesEnum returnState;

    string alertTag, animString;
    float alertRange, walkSpeed, wanderTime;

    Vector3 walkToPos;
    float timeLeft;

    public Wander (string _alertTag, string _animString = "[A][I]Add the correct animation name to the state[A][I]",
        NavigatorInterface _nav = null, NavMeshAgent _agent = null, float _wanderTime = 10, float _alertRange = 20, float _walkSpeed = 0.5f)
    {
        alertTag = _alertTag;
        animString = _animString;
        agent = _agent;
        nav = _nav;
        wanderTime = _wanderTime;
        timeLeft = wanderTime;
        alertRange = _alertRange;
        walkSpeed = _walkSpeed;
    }

    public void Enter(GameObject theObject, Animation _anim)
    {
        obj = theObject;
        anim = _anim;
        timeLeft = wanderTime;
        walkToPos = obj.transform.position;
        if (nav != null) nav.SetDest(obj.transform.position, obj);
    }

    public bool Reason()
    {
        Collider[] objectsInRange = Physics.OverlapSphere(obj.transform.position, alertRange);
        if (timeLeft < 0 && wanderTime > 0) {
            returnState = StatesEnum.idle;
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

        if (nav != null) nav.UpdatePosition();
        else if (agent) agent.SetDestination(GenerateNewPos());
        else {
            if (Vector3.Distance( obj.transform.position, walkToPos ) > 1) {
                obj.transform.LookAt(walkToPos);
                obj.transform.Translate(Vector3.forward * walkSpeed);
            } else {
                walkToPos = GenerateNewPos();
            }
        }
    }

    Vector3 GenerateNewPos ()
    {
        return new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
    }

    public StatesEnum Leave()
    {
        return returnState;
    }
}
}