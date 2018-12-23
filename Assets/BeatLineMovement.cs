using UnityEngine;
using System.Collections;

public class BeatLineMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (MapEditorController.moving)
        {
            transform.Translate(new Vector3(0, MapEditorController.mapSpeed) * Time.deltaTime);
        }
        else
        {
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            {
                transform.position = transform.position + new Vector3(0, 1, 0);
            }
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
            {
                transform.position = transform.position - new Vector3(0, 1, 0);
            }
        }
        if (transform.position.y < -7)
        {
            transform.position = transform.position + new Vector3(0, 12, 0);
        }
        if (transform.position.y >= 7)
        {
            transform.position = transform.position - new Vector3(0, 12, 0);
        }
	}
}
