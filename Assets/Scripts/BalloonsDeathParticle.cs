using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonsDeathParticle : MonoBehaviour
{
    public Color[] colors;

    private void Awake()
    {
        
    }

    public void SetColor(int id)
    {
#pragma warning disable CS0618
        GetComponent<ParticleSystem>().startColor = colors[id];
#pragma warning restore CS0618
    }
}
