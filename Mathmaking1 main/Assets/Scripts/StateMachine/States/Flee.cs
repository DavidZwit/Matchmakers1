using UnityEngine;

namespace States { 
class Flee : State {

    GameObject obj;
    Animation anim;
    StatesEnum returnState;

    string enemyTag, animString;
    float runSpeed, runRange;

    GameObject enemyObject;

    public Flee(string _enemyTag, string _animString = "[A][I]Add the correct animation name to the state[A][I]", 
        float _runSpeed = 1, float _runRange = 40)
    {
        enemyTag = _enemyTag;
        animString = _animString;
        runSpeed = _runSpeed;
        runRange = _runRange;
    }

    public void Enter(GameObject theObject, Animation _anim)
    {
        obj = theObject;
        anim = _anim;

        Collider[] objectsInRange = Physics.OverlapSphere(obj.transform.position, runRange);

        for (int i = 0; i < objectsInRange.Length; i++) {
            if (objectsInRange[i].tag == enemyTag) {
                enemyObject = objectsInRange[i].gameObject;
            }
        }
    }

    public bool Reason()
    {
        if (Vector3.Distance(obj.transform.position, enemyObject.transform.position) < runRange) {
            return true;
        }
        return false;
    }

    public void Act()
    {
        obj.transform.LookAt(enemyObject.transform);
        obj.transform.Rotate(new Vector3(0, 180, 0));
        obj.transform.Translate(Vector3.forward * runSpeed);
        if (anim && !anim.IsPlaying(animString)) anim.Play(animString);
    }

    public StatesEnum Leave()
    {
        return returnState;
    }
}
}