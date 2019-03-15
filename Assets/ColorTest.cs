using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTest : MonoBehaviour
{
    public Color color;
    private MaterialPropertyBlock block;

    private void Awake()
    {
        block = new MaterialPropertyBlock();
        block.SetColor("_Color", Color.blue);
        //GetComponent<ParticleSystem>().GetComponent<Renderer>().materi
    }
}