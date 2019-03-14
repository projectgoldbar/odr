using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowLight : Item
{
    // Start is called before t
    private void Awake()
    {
        ColorSet();
    }

    protected override void ColorSet()
    {
        lightcolor = Color.yellow;
    }
}