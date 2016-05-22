using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreatureTorso : MonoBehaviour {

    public Vector3 headPos, tailpos;
    public List<Transform> legPositions = new List<Transform>();

    public Vector3 HeadPos
    {
        get { return headPos; }
        set { headPos = value; }
    }

    public Vector3 Tailpos
    {
        get { return tailpos; }
        set { tailpos = value; }
    }

    public List<Transform> LegPositions
    {
        get { return legPositions; }
        set { legPositions = value; }
    }

    Transform[] childs;

    void Awake()
    {
        childs = gameObject.transform.GetComponentsInChildren<Transform>();
        
        foreach (Transform trans in childs)
        {
            if (trans.gameObject.name == "Head") headPos = trans.position;
            else if (trans.gameObject.name == "Tail") tailpos = trans.position;
            else if (trans.gameObject.name == "Legs") {

                Transform[] legs = trans.GetComponentsInChildren<Transform>();
                foreach(Transform leg in legs) {
                    if (leg.gameObject.name != gameObject.name && leg.gameObject.name != "Legs") {
                        legPositions.Add(leg);
                    }
                }

            }
        }
    }
}
