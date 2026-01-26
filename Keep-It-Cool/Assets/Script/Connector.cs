using Unity.VisualScripting;
using UnityEngine;

public class Connector : MonoBehaviour
{
    public GetMousePosition getMousePosition;
    public LayerMask inputConnectorLayer;
    public float hitBoxSize;
    public OutputConnect outputConnect;
    public GameObject connectorLine;
    public GameObject pipePrefab;


    // Start is called before the first frame update
    void Start()
    {
        // SpriteRenderer sr = connectorLine.GetComponent<SpriteRenderer>();
        // Debug.Log("Sprite world width = " + sr.sprite.bounds.size.x);
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
                CreatePipe(inputConnect.gameObject);
            }
            outputConnect = null;
            connectorLine.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    
    void SetConnectorLine()
    {
        LineRenderer lr = connectorLine.GetComponent<LineRenderer>();

        Vector3 start = outputConnect.transform.position;
        Vector3 end = transform.position;

        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }

    void CreatePipe(GameObject inputConnect)
    {
        GameObject newPipe = Instantiate(pipePrefab, (inputConnect.transform.position + outputConnect.gameObject.transform.position) / 2, Quaternion.identity);
        Pipe pipeClass = newPipe.GetComponent<Pipe>();
        pipeClass.input = inputConnect;
        pipeClass.output = outputConnect.gameObject;
        outputConnect.pipe = newPipe;
    }
}
