using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AssembleCreature : MonoBehaviour {

    BodyParts bodyParts;
    CreatureTorso torsoPositions;

    GameObject head, tail, torso;
    List<GameObject> legs = new List<GameObject>();

    [SerializeField]
    float scale;

    void Start()
    {

        bodyParts = GameObject.Find("Handeler").GetComponent<BodyParts>();
        Assemble();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            transform.localScale /= scale;
            DestoryChildren();
            Assemble();
        }
    }

    void DestoryChildren()
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in children) {
            if (child.gameObject.name != gameObject.name) Destroy(child.gameObject);
        }
    }

    void Assemble()
    {
        torso = Instantiate(bodyParts.torsos[Random.Range(0, bodyParts.torsos.Length)], transform.position, new Quaternion()) as GameObject;
        torso.transform.parent = transform;
        torso.name = "torso";
        torsoPositions = torso.GetComponent<CreatureTorso>();

        head = Instantiate(bodyParts.heads[Random.Range(0, bodyParts.heads.Length)],  torsoPositions.HeadPos,  new Quaternion()) as GameObject;
        head.name = "head";
        head.transform.parent = transform;

        tail = Instantiate(bodyParts.tails[Random.Range(0, bodyParts.tails.Length)], torsoPositions.Tailpos, new Quaternion(0, 90, 180, 0)) as GameObject;
        tail.name = "tial";
        tail.transform.parent = transform;


        int randomLeg = Random.Range(0, bodyParts.legs.Length);
        for (int i = 0; i < bodyParts.legs.Length; i++) {

            legs.Insert(i, Instantiate(bodyParts.legs[randomLeg], torsoPositions.LegPositions[i].position, new Quaternion()) as GameObject);
            legs[i].transform.parent = transform;
            legs[i].name = "leg" + i;
        }

        transform.localScale *= scale;
    }
}
