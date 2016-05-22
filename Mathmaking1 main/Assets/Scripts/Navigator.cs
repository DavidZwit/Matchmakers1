using UnityEngine;

public class Navigator : NavigatorInterface
{
    Vector3 destination;
    GameObject obj;

    float walkSpeed, curiosityRange;

    public Navigator(float _walkSpeed, float _curiosityRange)
    {
        walkSpeed = _walkSpeed;
        curiosityRange = _curiosityRange;
    }

    public void SetDest(Vector3 newDest, GameObject _obj)
    {
        destination = newDest;
        obj = _obj;
    }

	public void UpdatePosition ()
    {
        if (Vector3.Distance(obj.transform.position, destination) < 1)
        {
            Vector3 objPos = obj.transform.position;
            destination = new Vector3(Random.Range(objPos.x - curiosityRange, objPos.x + curiosityRange), 0, 
                Random.Range(objPos.y - curiosityRange, objPos.y + curiosityRange));
        }

        obj.transform.LookAt(destination);
        obj.transform.eulerAngles = new Vector3(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, 0);

        obj.transform.Translate(obj.transform.forward * walkSpeed);
    }
}
