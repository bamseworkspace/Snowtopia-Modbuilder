using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMeshGenerator : MonoBehaviour
{
    public int xSize;
    public int zSize;
    public int lastxSize;
    public Mesh mesh;

    public float y;
    public Transform indexer;

    public float Multi;

    public Vector3[] vertices;
    public int[] triangles;
    public float raise;

    public int[] Indexs;


    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        mesh = GetComponent<MeshFilter>().mesh;

        CreateMesh();


    }

    // Update is called once per frame
    private void Update()
    {
        RenderMesh();

    }

    void CreateMesh()
    {
        Debug.Log(xSize*zSize);

        Indexs = new int[xSize * zSize];
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        for (int i = 0, z = 0; z <= zSize; z++)
        {


            for (int x = 0; x <= xSize; x++)
            {

                Indexs[i] = Instantiate(indexer, new Vector3(x, 0, z), Quaternion.identity).GetComponent<Index>().thisindex = i;

                vertices[i] = new Vector3(x, 0, z);
                i++;
            }
        }
        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
    }

    void RenderMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        GetComponent<MeshCollider>().sharedMesh = mesh;

    }

    public void PointEx(int index)
    {
        float yPos = vertices[index].y + Multi;
        vertices[index] = new Vector3(vertices[index].x, yPos, vertices[index].z);
    }
}
