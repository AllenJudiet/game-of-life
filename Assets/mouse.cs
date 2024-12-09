using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    public Camera cam;
    public float zoom=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zoom=Input.mouseScrollDelta.y;
        cam.orthographicSize += zoom;
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit hit))
            {
                hit.transform.GetComponent<cell>().alive = true;
                print(hit.transform.name);
            }
        }
    }
    
}
