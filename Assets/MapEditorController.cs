using UnityEngine;
using System.Collections;

public class MapEditorController : MonoBehaviour {
    public GameObject mapBeat;
    public GameObject halfBeatLine;
    public GameObject fullBeatLine;
    public static float mapSpeed = -3.25f;
    public static bool moving = false;
	// Use this for initialization
	void Start () {
        for (int i = -6; i < 7; i++ )
        {
            Vector3 linePos = new Vector3(-12,i,9f);
            if(i % 2 == 0)
            {
                Instantiate(halfBeatLine, linePos, Quaternion.identity);
            }
            else
            {
                Instantiate(fullBeatLine, linePos, Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("return"))
        {
            moving = !moving;
        }
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f);
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 wordPos;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                wordPos = hit.point;
            }
            else
            {
                wordPos = Camera.main.ScreenToWorldPoint(mousePos);
                if(wordPos.x < 0)
                {
                    wordPos.x = -7f;
                }
                else
                {
                    wordPos.x = 7f;
                }
                if (Input.GetKey("left shift"))
                {
                    wordPos.y = Mathf.Round(wordPos.y);
                }
            }
            Instantiate(mapBeat, wordPos, Quaternion.identity);
            //or for tandom rotarion use Quaternion.LookRotation(Random.insideUnitSphere)
        }
	}
}
