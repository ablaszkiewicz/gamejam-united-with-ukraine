using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HookController : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    [SerializeField] private float moveSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void GoUp()
    {
        transform.DOBlendableMoveBy(new Vector3(0, 3, 0), 1).SetEase(Ease.OutQuint);
        Invoke("GoDown", 3.1f);
    }
    

    void GoDown()
    {
        transform.DOBlendableMoveBy(new Vector3(0, -3, 0), 1).SetEase(Ease.OutQuint);
    }
}
