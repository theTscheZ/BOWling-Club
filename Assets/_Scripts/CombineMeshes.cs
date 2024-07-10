using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineMeshes : MonoBehaviour
{
    void Start()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        int i = 0;
        while (i < meshFilters.Length)
        {
            // Überprüfen Sie, ob das Mesh schreibgeschützt ist
            if (!meshFilters[i].sharedMesh.isReadable)
            {
                Debug.LogError($"Mesh {meshFilters[i].name} is not readable and cannot be combined.");
                return;
            }

            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
            i++;
        }

        MeshFilter mf = gameObject.AddComponent<MeshFilter>();
        mf.mesh = new Mesh();
        mf.mesh.CombineMeshes(combine, true, true);
        gameObject.AddComponent<MeshRenderer>().material = meshFilters[0].GetComponent<Renderer>().sharedMaterial;

        // Aktivieren Sie das Parent-Objekt nach dem Kombinieren wieder
        gameObject.SetActive(true);
    }
}
