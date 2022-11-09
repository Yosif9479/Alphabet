using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloons : MonoBehaviour
{
    public float speed, xSpeed;
    private int positionCount;
    public string xPositionSide = "Right";
    public GameObject deathParticle, letter;
    public int id;
    public Sprite[] balloons;

    private void Awake()
    {
        int r = Random.Range(0, 100);
        if (r > 50)
        {
            xPositionSide = "Right";
        }
        else if (r < 50)
        {
            xPositionSide = "Left";
        }
        id = Random.Range(1, 8);
        GetComponent<SpriteRenderer>().sprite = balloons[id];
    }

    private void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed);
        if (positionCount == 200)
        {
            xPositionSide = "Left";
        }
        else if (positionCount == 0)
        {
            xPositionSide = "Right";
        }

        if (xPositionSide == "Right")
        {
            transform.position = new Vector2(transform.position.x + xSpeed, transform.position.y);
            positionCount++;
        }
        else if (xPositionSide == "Left")
        {
            transform.position = new Vector2(transform.position.x - xSpeed, transform.position.y);
            positionCount--;
        }
    }

    private void OnMouseDown()
    {
        Burst();
    }

    public void Burst()
    {
        letter.GetComponent<SpriteRenderer>().color = deathParticle.GetComponent<BalloonsDeathParticle>().colors[id];
        Instantiate(letter).transform.position = new Vector2 (transform.position.x, transform.position.y + 1.54f);
        deathParticle.GetComponent<BalloonsDeathParticle>().SetColor(id);
        Instantiate(deathParticle).transform.position = transform.position;
        Destroy(gameObject);
    }
}
