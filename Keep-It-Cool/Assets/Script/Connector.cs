using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Connector : MonoBehaviour
{
    public GetMousePosition getMousePosition;
    public LayerMask inputConnectorLayer;
    public float hitBoxSize;
    public OutputConnect outputConnect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = getMousePosition.GetPosition();
        if (Input.GetMouseButtonUp(0))
        {
            Collider2D collider2D = Physics2D.OverlapCircle(transform.position, hitBoxSize, inputConnectorLayer);
            if (!collider2D.IsUnityNull())
            {
                InputConnect inputConnect = collider2D.GetComponent<InputConnect>();
                inputConnect.outputConnect = outputConnect;
                outputConnect.inputConnect = inputConnect;
            }
            outputConnect = null;
            gameObject.SetActive(false);
        }
    }
}
