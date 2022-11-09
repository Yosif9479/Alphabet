using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryCard : MonoBehaviour
{
    private Text letter;
    public Sprite[] sprites;
    public bool open;
    private Animation animations;
    public static string targetLetter;
    public GameObject particle;
    public AnimationClip win;
    private AudioSource audioSource;

    public void Awake()
    {
        open = false;
        letter = GetComponentInChildren<Text>();
        animations = GetComponent<Animation>();
        Close();
        if (MemorySystem.cards == null)
        {
            MemorySystem.cards = new List<GameObject>();
        }
        if (MemorySystem.liveCards == null)
        {
            MemorySystem.liveCards = new List<GameObject>();
        }
        MemorySystem.cards.Add(gameObject);
        MemorySystem.liveCards.Add(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void Win()
    {
        animations.clip = win;
        animations.Play();
        audioSource.Play();
    }

    public void Particle()
    {
        MemorySystem.liveCards.Remove(gameObject);
        Destroy(gameObject);
    }

    public void Click()
    {
        if (animations.isPlaying == false)
        {
            if (MemorySystem.card2 == null)
            {
                if (open == false)
                {
                    open = !open;
                    if (MemorySystem.card1 == null)
                    {
                        MemorySystem.card1 = gameObject;
                        animations.Play();
                    }
                    else if (MemorySystem.card1 != null && MemorySystem.card2 == null)
                    {
                        MemorySystem.card2 = gameObject;
                        animations.Play();
                    }
                }
                else
                {
                    open = !open;
                    animations.Play();
                    MemorySystem.card1 = null;
                }
            }
        }
    }

    public void Rotate()
    {
        if (open == true)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    private void Open()
    {
        letter.color = new Color(1, 1, 1, 1);
        GetComponent<Image>().sprite = sprites[1];
    }

    private void Close()
    {
        letter.color = new Color(1, 1, 1, 0);
        GetComponent<Image>().sprite = sprites[0];
    }
}