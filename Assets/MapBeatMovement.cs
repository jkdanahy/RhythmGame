using UnityEngine;
using System.Collections;

public class MapBeatMovement : MonoBehaviour {

    // Use this for initialization
    public AudioClip snareHit;
    bool beenPlayed;
    AudioSource source;
	void Start () {
        source = GetComponent<AudioSource>();
        beenPlayed = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("return"))
        {
            beenPlayed = false;
        }
        if (MapEditorController.moving)
        {
            transform.Translate(new Vector3(0, MapEditorController.mapSpeed) * Time.deltaTime);
            if(transform.position.y < -2.98 && transform.position.y > -3.02 && !beenPlayed)
            {
                beenPlayed = true;
                source.PlayOneShot(snareHit);
            }
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
	}
}
