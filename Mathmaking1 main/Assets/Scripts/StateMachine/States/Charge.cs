using UnityEngine;

namespace States { 
class Charge : State {

    GameObject obj;
    Animation anim;
    StatesEnum returnState;
    GameObject target;

    string attackTag, animString;
    float chargeRange, chargeSpeed, attackRange;

    public Charge (string _attackTag, string _animString = "[A][I]Add the correct animation name to the state[A][I]", 
        float _chargeRange = 21, float _chargeSpeed = 1, float _attackRange = 3)
    {
        attackTag = _attackTag;
        animString = _animString;
        chargeRange = _chargeRange;
        chargeSpeed = _chargeSpeed;
        attackRange = _attackRange;
    }

    public void Enter(GameObject theObject, Animation _anim)
    {
        obj = theObject;
        anim = _anim;

        Collider[] objectsInRange = Physics.OverlapSphere(obj.transform.position, chargeRange);

        for (int i = 0; i < objectsInRange.Length; i++) {
            if (objectsInRange[i].tag == attackTag) {
                target = objectsInRange[i].gameObject;
            }
        }
    }

    public bool Reason()
    {
        if (target == null) return false;

        float distance = Vector3.Distance(target.transform.position, obj.transform.position);

        if (distance < chargeRange) {
            if (distance > attackRange) {
                return true;
            }
            returnState = StatesEnum.intaract;
            return false;
        }
        returnState = StatesEnum.wander;
        return false;
    }

    public void Act()
    {
        obj.transform.LookAt(target.transform);
        obj.transform.Translate(Vector3.forward * chargeSpeed);

        if (anim && !anim.IsPlaying(animString)) anim.Play(animString);
    }

    public StatesEnum Leave()
    {
        return returnState;
    }
}
}
