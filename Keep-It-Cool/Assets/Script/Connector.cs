using Unity.VisualScripting;
using UnityEngine;

public class Connector : MonoBehaviour
{
    public GetMousePosition getMousePosition;
    public LayerMask inputConnectorLayer;
    public float hitBoxSize;
    public OutputConnect outputConnect;
    public GameObject connectorLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = getMousePosition.GetPosition();
        SetConnectorLine();
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
            connectorLine.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    void SetConnectorLine()
    {
        float connectorX = gameObject.transform.position.x;
        float connectorY = gameObject.transform.position.y;
        float outputX = outputConnect.transform.position.x;
        float outputY = outputConnect.transform.position.y;
        float deltaX = connectorX - outputX;
        float deltaY = connectorY - outputY;
        float length = Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY);
        float angle = Mathf.Atan2(deltaY, deltaX) * Mathf.Rad2Deg;
        connectorLine.transform.localScale = new Vector3(length, connectorLine.transform.localScale.y, connectorLine.transform.localScale.z);
        connectorLine.transform.position = new Vector3((connectorX + outputX) / 2, (connectorY + outputY) / 2, connectorLine.transform.position.z);
        connectorLine.transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
