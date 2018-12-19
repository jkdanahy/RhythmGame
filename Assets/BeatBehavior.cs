using UnityEngine;
using System.Collections;

public class BeatBehavior : MonoBehaviour {
    public GameObject myObject;
	// Use this for initialization
	void Start () {
        myObject = Resources.Load("Assets/Prefabs/Beat") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0,-10) * Time.deltaTime);
        if(transform.position.y < -8f)
        {
            Destroy(gameObject);
            GameController.beatMiss();
        }
	}
}
