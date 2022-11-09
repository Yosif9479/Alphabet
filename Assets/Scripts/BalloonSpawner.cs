using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloon;
    public float minPosition, maxPosition;

    private void Awake()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.4f);
            Instantiate(balloon).transform.position = new Vector2 (Random.Range(minPosition, maxPosition), balloon.transform.position.y);
        }
    }
}
