using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

	// Use this for initialization
public void onSubmit(){
		string userName = GameObject.Find ("usernameInputField").transform.FindChild ("Text").GetComponent<Text> ().text;
		print ("username======= ================================================" + userName);
	}
}
