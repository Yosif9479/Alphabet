using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemorySystem : MonoBehaviour
{
    private string word1, word2;
    public static GameObject card1, card2;
    private string targetLetter;
    public string[] lettersRu, lettersTj;
    private int num; 
    public static List<GameObject> cards, liveCards;
    public GameObject cardParticle;

    private void Start()
    {
        SelectLetter();
    }

    private void Update()
    {
        if (card1 != null)
        {
            word1 = card1.GetComponentInChildren<Text>().text;
        }
        if (card2 != null)
        {
            word2 = card2.GetComponentInChildren<Text>().text;
        }
        if (card1 != null && card2 != null)
        {
            if (card1.GetComponent<Animation>().isPlaying == false && card2.GetComponent<Animation>().isPlaying == false)
            {
                if (word1 == word2)
                {
                    card1.GetComponent<MemoryCard>().Win();
                    card2.GetComponent<MemoryCard>().Win();
                }
                else
                {
                    StartCoroutine(Lose());
                }  
            }
        }
        if (liveCards.Count == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Memory");
        }
    }

    public void SelectLetter()
    {
        for (int i = 0; cards.Count != 0; i++)
        {
            if (num == 0)
            {
                if (MenuButtons.language == "ru")
                {
                    targetLetter = lettersRu[Random.Range(0, 32)];
                }
                else if (MenuButtons.language == "tj")
                {
                    targetLetter = lettersTj[Random.Range(0, 34)];
                }
                num++;
            }
            else if (num == 1)
            {
                num = 0;
            }
            int sel = Random.Range(0, cards.Count - 1);
            cards[sel].GetComponentInChildren<Text>().text = targetLetter;
            cards.RemoveAt(sel);
        }
    }

    private IEnumerator Lose()
    {
        yield return new WaitForSeconds(0.5f);
        if (card1 != null)
        {
            if (card1.GetComponent<Animation>().isPlaying == false)
            {
                card1.GetComponent<MemoryCard>().open = false;
                card2.GetComponent<MemoryCard>().open = false;
                card1.GetComponent<Animation>().Play();
                card2.GetComponent<Animation>().Play();
                card1 = null;
                card2 = null;
            }
        }
        StopCoroutine(Lose());
    }
}
