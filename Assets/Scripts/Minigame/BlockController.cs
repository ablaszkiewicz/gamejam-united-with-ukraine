using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    // Start is called before the first frame update
    private HingeJoint2D _hingeJoint;
    private GameObject _ropeHook;
    [SerializeField] private Sprite[] sprites;
    void Start()
    {
        _hingeJoint = GetComponent<HingeJoint2D>();
        _ropeHook = GameObject.FindWithTag("Hook");

        int spawnedBlocks = GameObject.FindGameObjectsWithTag("Block").Length;
        GetComponent<SpriteRenderer>().sprite = sprites[spawnedBlocks - 1];
        
        ConnectJoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _hingeJoint.enabled = false;
        }
    }
    
    private void ConnectJoint()
    {
        _hingeJoint.connectedBody = _ropeHook.GetComponent<Rigidbody2D>();
    }
}
