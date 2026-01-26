using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public GameObject outPipe;
    public GameObject inPipe;
    public GameObject output;
    public GameObject input;
    public GetMousePosition getMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        getMousePosition = GameObject.Find("GameManager").GetComponent<GetMousePosition>();
        outPipe = transform.Find("OutPipe").gameObject;
        inPipe = transform.Find("InPipe").gameObject;

        gameObject.transform.localScale = new Vector2(
            Mathf.Abs(output.transform.position.x - input.transform.position.x) + outPipe.transform.localScale.x, 
            gameObject.transform.localScale.y
        );
        gameObject.transform.position = new Vector3(
            (output.transform.position.x + input.transform.position.x) / 2,
            Mathf.Min(output.transform.position.y - 0.6f, input.transform.position.y - 0.6f),
            1
        );
        SetInOutPipe(outPipe, output, true);
        SetInOutPipe(inPipe, input, true);
    }

    void OnMouseDrag()
    {
        gameObject.transform.position = new Vector3(
            (output.transform.position.x + input.transform.position.x) / 2,
            Mathf.Min(getMousePosition.GetPosition().y, output.transform.position.y - 0.6f, input.transform.position.y - 0.6f),
            1
        );
        SetInOutPipe(outPipe, output, false);
        SetInOutPipe(inPipe, input, false);
    }

    void SetInOutPipe(GameObject pipe, GameObject connector, bool useLossy)
    {
        pipe.transform.localScale = new Vector2(
            pipe.transform.localScale.x / (useLossy ? gameObject.transform.lossyScale.x : 1),
            Mathf.Abs(connector.transform.position.y - gameObject.transform.position.y) / gameObject.transform.lossyScale.y
        );
        pipe.transform.position = new Vector3(
            connector.transform.position.x,
            (connector.transform.position.y + gameObject.transform.position.y) / 2,
            1
        );
    }
}
