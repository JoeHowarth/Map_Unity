using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]


public class TileMap : MonoBehaviour {
    public int size_x = 100;
    public int size_z = 50;
    public float tile_size = 1.0f;


    // Use this for initialization
    void Start () {
        BuildMesh();
	}

    public void BuildMesh()
    {
        int numTiles = size_x * size_z;
        int vsize_x = size_x + 1;
        int vsize_z = size_z + 1;
        int numVerts = vsize_x * vsize_z;


        // Generate mesh data
        Vector3[] vertices = new Vector3[numVerts];
        Vector3[] normals = new Vector3[numVerts];
        Vector2[] uv = new Vector2[numVerts];

        int[] triangles = new int[numTiles * 2 * 3];

        int x, z;
        for (z = 0; z < vsize_z; z++)
        {
            for (x = 0; x < vsize_x; x++)
            {
                int ind = z * vsize_x + x;
                vertices[ind] = new Vector3(x * tile_size, Random.Range(-1f,1f), z * tile_size);
                normals[ind] = Vector3.up;
                uv[ind] = new Vector2((float)x / size_x, (float)z / size_z);
            }
        }
        for (z = 0; z < size_z; z++)
        {
            for (x = 0; x < size_x; x++)
            {
                int squareIndex = z * size_x + x;
                int triOffset = squareIndex * 6;
                int offset = z * vsize_x + x;

                triangles[triOffset + 0] = offset;
                triangles[triOffset + 1] = offset + vsize_x;
                triangles[triOffset + 2] = offset + vsize_x + 1;


                triangles[triOffset + 3] = offset;
                triangles[triOffset + 4] = offset + vsize_x + 1;
                triangles[triOffset + 5] = offset + 1;
            }
        }
        

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        // Assign mesh to filter/render/collider
        MeshFilter mesh_filter = GetComponent<MeshFilter>();
        MeshCollider mesh_collider = GetComponent<MeshCollider>();


        mesh_filter.mesh = mesh;
        mesh_collider.sharedMesh = mesh;
        Debug.Log("mesh done");


    }
}
