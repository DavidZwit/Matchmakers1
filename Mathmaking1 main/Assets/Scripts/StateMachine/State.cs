public interface State
{
    void Enter(UnityEngine.GameObject theObject, UnityEngine.Animation anim);
    bool Reason();
    void Act();
    StatesEnum Leave();
}
