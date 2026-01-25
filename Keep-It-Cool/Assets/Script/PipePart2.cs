using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePart2 : MonoBehaviour
{
    public GameObject output;
    public GameObject input;
    public GetMousePosition getMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        getMousePosition = GameObject.Find("GameManager").GetComponent<GetMousePosition>();
        Pipe pipe = transform.parent.gameObject.GetComponent<Pipe>();
        output = pipe.output;
        input = pipe.input;
        gameObject.transform.position = new Vector2(
            (output.transform.position.x + input.transform.position.x) / 2,
            Mathf.Min(output.transform.position.y - 0.6f, input.transform.position.y - 0.6f)
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        gameObject.transform.position = new Vector2(
            (output.transform.position.x + input.transform.position.x) / 2,
            Mathf.Min(getMousePosition.GetPosition().y, output.transform.position.y - 0.6f, input.transform.position.y - 0.6f)
        );
    }
}
