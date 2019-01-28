using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatRun : MonoBehaviour
{
    Cat cat;
    public float catSpeed;

    Vector3 originalPos;



    bool facingRight = false;
    Vector3 pos, localScale;
    [SerializeField]
    public Vector3 spawn;
    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    void Start()
    {
        cat = GetComponent<Cat>();
        originalPos = transform.localPosition;
        localScale = transform.localScale;

        pos = new Vector3(2.3f, -2.41f, -0.04256725f);

    }


    void Update()
    {

        Fly();



        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.name.Equals(gameObject.name))
            {
                cat.speechBubble.SetActive(false);

                cat.display.UpdateReferences(cat.petState);
                cat.display.GetComponent<Timer>().timer = 10;
                cat.display.GetComponent<Timer>().StartTimer();
                enabled = false;
                pos = new Vector3(2.3f, -2.41f, -0.04256725f);
                transform.position = pos;

                cat.GetNewAction();
            }

        }
    }


    #region CatMove
    void Fly()
    {
        CheckWhereToFace();

        if (facingRight)
            MoveRight();
        else
            MoveLeft();


    }
    void CheckWhereToFace()
    {
        if (pos.x < -7f)
            facingRight = true;

        else if (pos.x > 7f)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;

    }

    void MoveRight()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    void MoveLeft()
    {
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }
    #endregion

}
