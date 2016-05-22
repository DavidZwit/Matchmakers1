using UnityEngine;

public class DeformPlatform : MonoBehaviour
{
    [SerializeField]
    GameObject plane;

    internal GameObject[,] testTerain;

    void Start()
    {
        testTerain = CreateObject(new Vector2(20, 20));

        for (int x = 0; x < 20 * 11; x++) {
            for (int y = 0; y < 20 * 11; y++) {

                if (UnityEngine.Random.Range(0, 50) == 0)
                    ChangeVertices(testTerain, new Vector2(x / 11, y / 11), new Vector2(x / 20, y / 20), UnityEngine.Random.Range(-20, 20));
            }
        }
    }

    GameObject[,] CreateObject(Vector2 terrainSize)
    {
        GameObject[,] returnPlane = new GameObject[(int)terrainSize.x, (int)terrainSize.y];

        Mesh objectMesh = plane.GetComponent<MeshFilter>().sharedMesh;
        Vector2 scale = new Vector2(objectMesh.bounds.size.x, objectMesh.bounds.size.z);

        for (var x = 0; x < terrainSize.x; x++) {
            for (var y = 0; y < terrainSize.y; y++) {
                returnPlane[x, y] = Instantiate(plane, new Vector3(-scale.x * x, 0, -scale.y * y), new Quaternion()) as GameObject;
                returnPlane[x, y].AddComponent<DeformPlane>();
            }
        }
        return returnPlane;
    }

    void ChangeVertices(GameObject[,] changePlane, Vector2 plane, Vector2 pointOnPlane, int newHeight)
    {
        changePlane[(int)plane.x, (int)plane.y].GetComponent<DeformPlane>().DeformFromPoint(pointOnPlane, newHeight);
    }
}
