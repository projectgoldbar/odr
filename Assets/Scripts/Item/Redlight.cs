using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redlight : Item
{
    private void Awake()
    {
        ColorSet();
    }

    protected override void ColorSet()
    {
        lightcolor = Color.red;
    }
}