using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HButtonLetter : MonoBehaviour
{
    [SerializeField] private GameObject helicopter;
    [SerializeField] private GameObject letter;
    [SerializeField] int id;

    public void Click()
    {
        if (letter != null)
        {
            foreach (var clipInfo in helicopter.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0))
        {
            if (clipInfo.clip.name == "Door")
            {
                return;
            }
            else
            {
                if (GetComponent<Text>().text == letter.GetComponent<Text>().text)
                {
                    helicopter.GetComponent<Animator>().SetTrigger("Door");
                    GetComponent<Text>().color = Color.green;
                }
                else
                {
                    GetComponent<Animation>().Play();
                }
            }
        }
        }
    }
}
