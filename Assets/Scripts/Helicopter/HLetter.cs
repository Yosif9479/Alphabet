using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HLetter : MonoBehaviour
{
    public GameObject[] letters;
    public string[] lettersSTR, lettersSTRtj;
    private string[] selectedLetters;
    public AudioClip[] lettersAudioRu, lettersAudioTj;
    private AudioSource audioSource;
    private GameObject helicopter;
    public float secondsInterval;
    [HideInInspector] public int i;
    public GameObject _letter;
    [SerializeField] private Color lettersCollor;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        helicopter = GameObject.Find("Helicopter");
        foreach (GameObject letter in letters)
        {
            letter.GetComponent<Text>().color = lettersCollor;
        }
        if (MenuButtons.language == "ru")
        {
            i = Random.Range(0, 32);
            GetComponent<Text>().text = lettersSTR[i];
            audioSource.clip = lettersAudioRu[i];
        }
        else if (MenuButtons.language == "tj")
        {
            i = Random.Range(0, 34);
            GetComponent<Text>().text = lettersSTRtj[i];
            audioSource.clip = lettersAudioTj[i];
        }
        selectedLetters = new string[3];
        RandomLetters();
    }

    private void Start()
    {
        StartCoroutine(LettersAudio());
    }

    private void Update()
    {
        foreach (var clipInfo in helicopter.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0))
        {
            if (clipInfo.clip.name == "Door")
            {
                StopCoroutine(LettersAudio());
            }
        }
    }

    public void SelectLetter(int id)
    {
        letters[id].GetComponent<Text>().color = GetComponent<Text>().color;
        GetComponent<Text>().color = new Color(0, 0, 0, 0);
        Destroy(gameObject);
        SceneManager.LoadScene("Helicopter");
    }

    public void RandomLetters()
    {
        i = Random.Range(0, 3);
        letters[i].GetComponent<Text>().text = GetComponent<Text>().text;
        selectedLetters[0] = GetComponent<Text>().text;
        for (int j = 0; j < 3; j++)
        {
            if (j != i)
            {
                if (MenuButtons.language == "ru")
                {
                    letters[j].GetComponent<Text>().text = lettersSTR[Random.Range(0, 32)];
                }
                else if (MenuButtons.language == "tj")
                {
                    letters[j].GetComponent<Text>().text = lettersSTRtj[Random.Range(0, 32)];
                }
                while (selectedLetters.Contains(letters[j].GetComponent<Text>().text))
                {
                    if (MenuButtons.language == "ru")
                    {
                        letters[j].GetComponent<Text>().text = lettersSTR[Random.Range(0, 32)];
                    }
                    else if (MenuButtons.language == "tj")
                    {
                        letters[j].GetComponent<Text>().text = lettersSTRtj[Random.Range(0, 32)];
                    }
                }
            }
        }
    }

    public void PlayAnimation()
    {
        if (i == 0)
        {
            GetComponent<Animation>().PlayQueued("1");
        }
        else if (i == 1)
        {
            GetComponent<Animation>().PlayQueued("2");
        }
        else
        {
            GetComponent<Animation>().PlayQueued("3");
        }
    }

    private IEnumerator LettersAudio()
    {
        while (true)
        {
            if (letters[i].GetComponent<Text>().color == lettersCollor)
            {
                audioSource.Play();
            }
            yield return new WaitForSeconds(secondsInterval);
        }
    }
}