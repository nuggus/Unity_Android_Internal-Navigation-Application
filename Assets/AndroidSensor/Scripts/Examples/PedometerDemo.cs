using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PedometerDemo : MonoBehaviour {
	
	private PedometerPlugin pedometerPlugin;
	private string demoName="[PedometerDemo] ";

	public Text stepCountText;
	public Text stepDetectText;
	
	// Use this for initialization
	void Start (){
		//get the instance of pedometer plugin
		pedometerPlugin = PedometerPlugin.GetInstance();

		//set to zero to hide debug toast messages
		pedometerPlugin.SetDebug(0);

		//initialze pedometer
		pedometerPlugin.Init();

		//set this to true to always starts at zero steps, else set to false to continue steps
		pedometerPlugin.SetAlwaysStartAtZero(true);

		//set call back listener for pedometer events
		pedometerPlugin.SetCallbackListener(OnStepCount,OnStepDetect);

		//register sensor event listener
		pedometerPlugin.RegisterSensorListener();
	}

	public void ResetTotalStep(){
		//reset total step to zero
		if(pedometerPlugin!=null){
			pedometerPlugin.ResetTotalStep();
			UpdateStepCount(0);
			Debug.Log( demoName + "ResetTotalStep ");
		}
	}	
				 
	private void OnApplicationPause(bool val){
		if(val){
			//game is pause
			//remove sensor event listener
			if(pedometerPlugin!=null){
				pedometerPlugin.RemoveSensorListener();
			}
		}else{
			//game is resume
			//register sensor event listener
			if(pedometerPlugin!=null){
				pedometerPlugin.RegisterSensorListener();
			}
		}
	}

	//step count event is triggered
	private void OnStepCount(int count){
		UpdateStepCount(count);
		Debug.Log( demoName + "OnStepCount count " + count);
	}

	//step detect event is triggered
	private void OnStepDetect(){
		UpdateStepDetect("Detect!");
		Debug.Log( demoName + "OnStepDetect");
	}

	//for updating step count for demo purpose
	private void UpdateStepCount(int count){
		if(stepCountText!=null){
			stepCountText.text = string.Format("Step Count: {0}",count);
		}
	}

	//for showing step is detected for demo purpose
	private void UpdateStepDetect(string val){
		if(stepDetectText!=null){
			stepDetectText.text = string.Format("Step Detect: {0}",val);
		}
	}
}