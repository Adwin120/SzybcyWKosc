using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        int combineIndex = 0;
        for (int i = 0; i < meshFilters.Length; i++)
        {
            if (meshFilters[i].sharedMesh.name.Equals("LaneDivider"))
            {
                continue;
            }

            combine[combineIndex].mesh = meshFilters[i].sharedMesh;
            combine[combineIndex].transform = meshFilters[i].transform.localToWorldMatrix;
            Destroy(meshFilters[i].gameObject.GetComponent<MeshCollider>());
            combineIndex++;
        }
        System.Array.Resize(ref combine, combineIndex);
        Mesh finalMesh = new Mesh();
        finalMesh.CombineMeshes(combine, true, true);

        //MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        //MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();

        //meshFilter.sharedMesh = finalMesh;
        //meshRenderer.sharedMaterial = meshFilters[0].GetComponent<MeshRenderer>().sharedMaterial;
        meshCollider.sharedMesh = finalMesh;

        // Adjust position of the combined mesh
        Vector3[] vertices = finalMesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = transform.InverseTransformPoint(vertices[i]);
        }
        finalMesh.vertices = vertices;
        meshCollider.convex = true;
        meshCollider.convex = false;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
