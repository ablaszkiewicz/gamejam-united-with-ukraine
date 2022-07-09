using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField] private GameObject blockAnchor;
    private LineRenderer lineRenderer;
    private GameObject ropeHook;
    
    // Start is called before the first frame update
    void Start()
    {
        ropeHook = GameObject.FindWithTag("Hook");
        lineRenderer = GetComponent<LineRenderer>();
        
        lineRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, blockAnchor.transform.position);
        lineRenderer.SetPosition(1, ropeHook.transform.position);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lineRenderer.enabled = false;
        }
    }
}
