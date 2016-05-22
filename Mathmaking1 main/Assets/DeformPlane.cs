using UnityEngine;

public class DeformPlane : MonoBehaviour
{

    public int DeformFromPoint(Vector2 point, int height)
    {
        Mesh currentPlane = gameObject.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = currentPlane.vertices;

        Vector3[,] sortedVertices = ArrayEditor.ToToDem<Vector3>(vertices);

        for (int x = -(height / 2); x <= (height / 2); x++)
        {
            for (int y = -(height / 2); y <= (height / 2); y++)
            {
                try { sortedVertices[x, y].y = Mathf.Abs(point.x - x); }
                catch {  }
            }
        }

        currentPlane.vertices = ArrayEditor.ToOneDem<Vector3>(sortedVertices);
        currentPlane.RecalculateBounds();

        return 1;
    }
}
