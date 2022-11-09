using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helicopter : MonoBehaviour
{
    private Text letterText;
    private Animator animator;
    public GameObject letterObj;
    public float firstPoint, lastPoint;
    [SerializeField] float speed;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void DropLetter()
    {
        letterObj.GetComponent<HLetter>().PlayAnimation();
    }

}
