using UnityEngine;
using System.Collections;

public class PassFailMeterController : MonoBehaviour {

	// Use this for initialization
    Transform orangeBar;
    float maxBarWidth;
	void Start () {
        orangeBar = gameObject.transform.Find("OrangeSquare").GetComponent<Transform>();
        maxBarWidth = orangeBar.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        orangeBar.localScale = new Vector3(maxBarWidth*GameController.passFailScore, orangeBar.localScale.y, orangeBar.localScale.z);
	}
}
