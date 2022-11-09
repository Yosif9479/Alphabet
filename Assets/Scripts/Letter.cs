using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    private AudioSource audioSource;
    private int id;
    public Sprite[] lettersRu, lettersTj;
    public AudioClip[] lettersAudioRu, lettersAudioTj;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (MenuButtons.language == "ru")
        {
            id = Random.Range(0, 32);
            GetComponent<SpriteRenderer>().sprite = lettersRu[id];
            if (lettersAudioRu.Length != 0)
            {
                audioSource.clip = lettersAudioRu[id];
            }
        }
        else if (MenuButtons.language == "tj")
        {
            id = Random.Range(0, 34);
            GetComponent<SpriteRenderer>().sprite = lettersTj[id];
            if (lettersAudioTj.Length != 0)
            {
                audioSource.clip = lettersAudioTj[id];
            }
        }
        audioSource.Play();
        Destroy(gameObject, 4);
    }

    private void Update()
    {
        //nothing
    }
}
