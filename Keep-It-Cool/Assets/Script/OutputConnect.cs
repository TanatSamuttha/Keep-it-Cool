using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class OutputConnect : MonoBehaviour
{
    public InputConnect inputConnect;
    public GameObject connector;
    public GameObject connectorLine;
    public GetMousePosition getMousePosition;
    public GameObject pipe;

    // Start is called before the first frame update
    void Start()
    {
        GameObject connectmanager = GameObject.Find("ConnectManager");
        connector = connectmanager.transform.Find("Connector").gameObject;
        connectorLine = connectmanager.transform.Find("ConnectorLine").gameObject;
        getMousePosition = GameObject.Find("GameManager").GetComponent<GetMousePosition>();
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
        Destroy(pipe);
        connector.transform.position = getMousePosition.GetPosition();
        connector.SetActive(true);
        connectorLine.SetActive(true);
        Connector connectorClass = connector.GetComponent<Connector>();
        connectorClass.outputConnect = this;
    }
}
