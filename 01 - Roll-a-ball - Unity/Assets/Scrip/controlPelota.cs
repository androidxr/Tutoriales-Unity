using UnityEngine;
using System.Collections;

public class controlPelota : MonoBehaviour {
	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;

	void Start (){
		count = 0;
		SetCounText();
		winText.text = "";
	}
	void FixedUpdate(){

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertival = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertival);
		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag =="PickUp"){
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCounText();
		}
	}

	void SetCounText(){
		countText.text = "Count: " + count.ToString();
		if (count >= 10) {
			winText.text="YOU WINN!!!!";		
		}
	}

}
