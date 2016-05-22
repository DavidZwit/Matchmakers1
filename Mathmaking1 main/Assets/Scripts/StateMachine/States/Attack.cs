using UnityEngine;

namespace States { 
class Attack : State {

    GameObject obj;
    Animation anim;
    StatesEnum returnState;

    float attackRange;
    string attackTag, animString;

    bool attacking = false;
    int attacked = 0;

    public Attack (string _attackTag, string _animString = "[A][I]Add the correct animation name to the state[A][I]",
        float _attackRange = 4)
    {
        attackTag = _attackTag;
        animString = _animString;
        attackRange = _attackRange;
    }

    public void Enter(GameObject theObject, Animation _anim)
    {
        obj = theObject;
        anim = _anim;
    }

    public bool Reason()
    {
        attacked++;

        if (!attacking) {
            if (anim) {
                if (!anim.IsPlaying(animString)) {
                    attacking = true;
                }
            } else {
                attacking = true;
            }
            
            return true;
        } else {
            returnState = StatesEnum.retreat;
            return false;
        }
    }

    public void Act()
    {
        if (attacked == 1) {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(obj.transform.position, obj.transform.forward, attackRange);

            if (anim) anim.Play(animString);
            try {
                for (int i = 0; i < hits.Length; i++) {
                    GameObject hitObject = hits[i].transform.gameObject;
                    if (hitObject.tag == attackTag)
                        Debug.Log("Delt damage to " + hitObject.name + "!!!");
                }
            }
            catch { Debug.Log("target not in range"); }
        }
    }

    public StatesEnum Leave()
    {
        attacking = false;
        attacked = 0;
        return returnState;
    }
}
}