using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    // Start is called before the first frame update
    private HingeJoint2D _hingeJoint;
    private GameObject _ropeHook;
    void Start()
    {
        _hingeJoint = GetComponent<HingeJoint2D>();
        _ropeHook = GameObject.FindWithTag("Hook");
        
        ConnectJoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            _hingeJoint.enabled = false;
        }
    }
    
    private void ConnectJoint()
    {
        _hingeJoint.connectedBody = _ropeHook.GetComponent<Rigidbody2D>();
    }
}
