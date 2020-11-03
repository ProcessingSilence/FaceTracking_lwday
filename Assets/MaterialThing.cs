using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialThing : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    public Material myMaterial;
    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = gameObject.GetComponent<MeshRenderer>();
         
    }

    // Update is called once per frame
    void Update()
    {
        _meshRenderer.material = myMaterial;
    }
}
