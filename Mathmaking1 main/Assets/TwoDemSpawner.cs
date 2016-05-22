using UnityEngine;
using System.Collections;

public class TwoDemSpawner: MonoBehaviour {

    [SerializeField]
    GameObject blocks;
    [SerializeField]
    Vector2 begin, end;
    [SerializeField]
    int steps;
    
    void Start()
    {
        for (float x = begin.x; x < end.x; x += steps)
        {
            for (float y = begin.y; y < end.y; y += steps)
            {
                Instantiate(blocks, new Vector3(x, 0, y), new Quaternion());
            }
        }
    }
}
