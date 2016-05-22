using UnityEngine;
using System.Collections;

public class DebugScript : MonoBehaviour {
    [SerializeField]
    GameObject target;

	void Update () {
        print(Vector3.Distance(transform.position, target.transform.position));
	}
}
