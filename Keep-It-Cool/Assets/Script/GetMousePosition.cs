using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMousePosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetPosition()
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return position;
    }
}
