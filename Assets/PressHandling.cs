using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PressHandling : MonoBehaviour {

    List<GameObject> beatsInside;
    public AudioClip snareHit;
    AudioSource source;
    bool soundPlayed;
    // Use this for initialization
    void Start () {
        beatsInside = new List<GameObject>();
        soundPlayed = false;
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*if (beatsInside.Count > 0 && !soundPlayed && Mathf.Abs(beatsInside[0].transform.position.y - transform.position.y) < .5f)
        {
            soundPlayed = true;
            source.PlayOneShot(snareHit);
        }*/
        if(Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(1).phase == TouchPhase.Began))
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch tap = Input.GetTouch(i);
                if (tap.phase == TouchPhase.Began)
                {
                    //We transform the touch position into word space from screen space and store it.
                    Vector2 touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);

                    Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

                    //We now raycast with this information. If we have hit something we can process it.
                    RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
                    if (hitInformation.collider != null && hitInformation.collider.gameObject == this.gameObject)
                    {
                        if (beatsInside.Count > 0)
                        {
                            GameController.beatHit();
                            soundPlayed = true;
                            source.PlayOneShot(snareHit);
                            Destroy(beatsInside[0]);
                            beatsInside.RemoveAt(0);
                        }
                        else
                        {
                            GameController.beatMiss();
                        }
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        beatsInside.Add(col.gameObject);
        soundPlayed = false;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        beatsInside.RemoveAt(0);
    }
}
