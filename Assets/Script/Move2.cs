using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{

    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float TimeToMove = 0.2f;

    public bool currentPlayer;
    public GameObject Selected;

    public Transform FirePoint;
    public GameObject BulletPrefab;

    public BoxCollider2D BoxColldier01;
    public BoxCollider2D BoxColldier02;
    public BoxCollider2D BoxColldier03;

    public BoxCollider2D BoxColldier04;
    public BoxCollider2D BoxColldier05;
    public BoxCollider2D BoxColldier06;

    void Start()
    {
        currentPlayer = false;

    }

    void OnMouseDown()
    {
        currentPlayer = true;
        Debug.Log(currentPlayer);
        Selected.gameObject.SetActive(true);

        BoxColldier01.enabled = false;
        BoxColldier02.enabled = false;
        BoxColldier03.enabled = false;

        BoxColldier04.enabled = false;
        BoxColldier05.enabled = false;
        BoxColldier06.enabled = false;
    }

    void Update()
    {
        if (currentPlayer)
        {
            if (Input.GetKey(KeyCode.UpArrow) && !isMoving)
                StartCoroutine(MovePlayer(Vector3.up));

            if (Input.GetKey(KeyCode.DownArrow) && !isMoving)
                StartCoroutine(MovePlayer(Vector3.down));

            if (Input.GetKey(KeyCode.LeftArrow) && !isMoving)
                StartCoroutine(MovePlayer(Vector3.left));

            if (Input.GetKey(KeyCode.RightArrow) && !isMoving)
                StartCoroutine(MovePlayer(Vector3.right));
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }

        }

    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;
        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < TimeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / TimeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
            currentPlayer = false;
            Selected.gameObject.SetActive(false);

           

            BoxColldier04.enabled = true;
            BoxColldier05.enabled = true;
            BoxColldier06.enabled = true;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        currentPlayer = false;
        Selected.gameObject.SetActive(false);

       

        BoxColldier04.enabled = true;
        BoxColldier05.enabled = true;
        BoxColldier06.enabled = true;
    }
}
