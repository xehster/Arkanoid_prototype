using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
    public Material[] materials;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material randomMaterial = materials[Random.Range(0, materials.Length)];
        renderer.material = randomMaterial;
    }
}
