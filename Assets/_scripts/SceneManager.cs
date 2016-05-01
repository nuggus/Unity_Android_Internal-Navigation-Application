using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

public void onClickSchedule(){
		Application.LoadLevel ("schedule");
	}
	public void onClickNavigation(){
		Application.LoadLevel ("navigation");
	}
	public void onClickLogin(){
		//var showPopup = true;
		string userName = GameObject.Find("usernameInputField").transform.FindChild("Text").GetComponent<Text>().text;

		string pwd=GameObject.Find("pwdInputField").transform.FindChild("Text").GetComponent<Text>().text;
		//print ("User:" + userName + "and" + " Password:" + pwd);
		if (userName != "" && pwd != "") {
		
			Application.LoadLevel ("main");
		} 

}
	public void onClickLogout(){
		Application.LoadLevel ("login");
	}
	public void onClickNavigationBack(){
		Application.LoadLevel ("main");
	}

	/*public void playAudio()
	{
		GetComponent<AudioSource> ().Play ();
	}*/

}
