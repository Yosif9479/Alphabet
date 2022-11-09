using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsMenu : MonoBehaviour
{
    private int id = 0;
    public Sprite[] images, imagesTj;
    public string[] letters, lettersTj;
    public string[] words, wordsTj;
    public AudioClip[] sounds, soundsTj;
    public Text letter, word;
    private AudioSource audioSource;
    public GameObject image;
    private int minLevel, maxLevel;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        minLevel = 0;
        if (MenuButtons.language == "tj")
        {
            maxLevel = 34;
            image.GetComponent<Image>().sprite = imagesTj[id];
            letter.text = lettersTj[id];
            word.text = wordsTj[id];
        }
        else if (MenuButtons.language == "ru")
        {
            maxLevel = 32;
            image.GetComponent<Image>().sprite = images[id];
            letter.text = letters[id];
            word.text = words[id];
        }
        PlaySound();
    }

    public void Move(string option)
    {
        if (option == "next")
        {
            if (id != maxLevel)
            {
                id++;
            }

            else
            {
                id = minLevel;
            }
        }
        else if (option == "previous")
        {
            if (id != minLevel)
            {
                id--;
            }

            else
            {
                id = maxLevel;
            }
        }
        if (MenuButtons.language == "tj")
        {
            image.GetComponent<Image>().sprite = imagesTj[id];
            letter.text = lettersTj[id];
            word.text = wordsTj[id];
        }
        else if (MenuButtons.language == "ru")
        {
            image.GetComponent<Image>().sprite = images[id];
            letter.text = letters[id];
            word.text = words[id];
        }
        PlaySound();
    }

    public void PlaySound()
    {
        if (MenuButtons.language == "ru")
        {
            audioSource.clip = sounds[id];
        }
        else if (MenuButtons.language == "tj")
        {
            audioSource.clip = soundsTj[id];
        }
        audioSource.Play();
    }
}
