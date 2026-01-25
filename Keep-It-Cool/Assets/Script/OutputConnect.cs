using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OutputConnect : MonoBehaviour
{
    public InputConnect inputConnect;
    public GameObject connector;
    public GetMousePosition getMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Renderer>().material.color = (inputConnect.IsUnityNull())?Color.red:Color.green;
    }

    void OnMouseDown()
    {
        if (!inputConnect.IsUnityNull())
        {
            inputConnect.outputConnect = null;
        }
        inputConnect = null;
        connector.transform.position = getMousePosition.GetPosition();
        connector.SetActive(true);
        Connector connectorClass = connector.GetComponent<Connector>();
        connectorClass.outputConnect = this;
    }
}
