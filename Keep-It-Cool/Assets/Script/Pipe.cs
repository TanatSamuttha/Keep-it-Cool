using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public GameObject part1;
    public GameObject part2;
    public GameObject part3;
    public GameObject output;
    public GameObject input;
    public GetMousePosition getMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        part1 = transform.Find("Part1").gameObject;
        part2 = transform.Find("Part2").gameObject;
        part3 = transform.Find("Part3").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        part1.transform.position = new Vector2(
            output.transform.position.x,
            (output.transform.position.y + part2.transform.position.y) / 2
        );
        part3.transform.position = new Vector2(
            input.transform.position.x,
            (input.transform.position.y + part2.transform.position.y) / 2
        );
        // part2.transform.position = new Vector2(
        //     (output.transform.position.x + input.transform.position.x) / 2,
        //     part3.transform.position.y
        // );
        part1.transform.localScale = new Vector2(part1.transform.localScale.x, Mathf.Abs(output.transform.position.y - part2.transform.position.y));
        part3.transform.localScale = new Vector2(part3.transform.localScale.x, Mathf.Abs(input.transform.position.y - part2.transform.position.y));
        part2.transform.localScale = new Vector2(Mathf.Abs(output.transform.position.x - input.transform.position.x) + part1.transform.localScale.x, part2.transform.localScale.y);
    }
}
