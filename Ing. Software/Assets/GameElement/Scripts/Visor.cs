using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visor : MonoBehaviour
{
    public Texture texture;
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        material.mainTexture = texture; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
