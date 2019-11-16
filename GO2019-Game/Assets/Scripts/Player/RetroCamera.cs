using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RetroCamera : MonoBehaviour
{
    public Material material;

    // Start is called before the first frame update
    void OnRenderImage(RenderTexture src, RenderTexture dest) 
    {
        Graphics.Blit(src, dest, material);
    }
}
