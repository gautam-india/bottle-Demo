using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{

    [SerializeField] GameObject victoryPanel;
    private BoxCollider2D finishCollider;
    [SerializeField]
    private LayerMask playerMask;

    private void Awake()
    {
        victoryPanel.SetActive(false);
        finishCollider = GetComponent<BoxCollider2D>();
    }

      

    private void Update()
    {
        if (isFinished())
        {

            StartCoroutine(finishSet());
        }
    }

    IEnumerator finishSet()
    {
        yield return new WaitForSeconds(1f);
        victoryPanel.SetActive(true);
    }

    public bool isFinished()
    {
        float extraHeight = 0.05f;

        RaycastHit2D raycastHit2D = Physics2D.BoxCast(finishCollider.bounds.center, finishCollider.bounds.size, 0f, Vector2.up, extraHeight, playerMask);


        return raycastHit2D.collider != null;
    }


}
