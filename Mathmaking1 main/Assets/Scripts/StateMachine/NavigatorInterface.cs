using UnityEngine;

public interface NavigatorInterface
{
    void SetDest(Vector3 dest, GameObject obj);
    void UpdatePosition();
}