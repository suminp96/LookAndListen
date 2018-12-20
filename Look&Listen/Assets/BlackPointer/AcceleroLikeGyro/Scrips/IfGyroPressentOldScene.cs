using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfGyroPressentOldScene : MonoBehaviour {

	// this script is to enable or disable AcceleroGyro
	// when some conditions happends.
	// for example, if the devices has giroscope, this
	// script can detect this, and disable acceleroGyro
	// IS VERY EASY TO USE, ONLY ENABLE editorcondition
	// if you works on unity editor, and disable when
	// you want compile and android version.
	// bool editor ForceAccelerometer is only for test accelerometer rotation with phones that have gyroscope, disable when you publish your game.

	public GameObject acceGyroOff;		 	 // the gameobject thats contain script Accelerogyro.
	public bool ForceAccelerometer;			 // force to works with accelerometer, only recomended for test. disable always for finished versions.
	public bool editorcondition;			// disable this option if you compile your game if you work on unity editor enable this.

	void Start ()
	{
		
		checks ();
		checksII ();

	}

	void checks() {
		#if UNITY_EDITOR
		editor();
		#endif
	}
	void editor () {
		if (editorcondition == true) {
			print ("disabled sensor rotations, mouse rotation enabled");
			acceGyroOff.GetComponent<AcceleroGyro> ().enabled = false;			// to disable accelerogyro script.
			acceGyroOff.GetComponent<MoveCamera> ().enabled = true;				// enables camera rotating with mouse and keys in unity.
		}
	}

	void checksII() {
		#if UNITY_ANDROID
		if (editorcondition == false) {
			andro();
		#endif
		}
	}
	void andro() {

		if (SystemInfo.supportsGyroscope == true && ForceAccelerometer == false) {	// check if the gyroscope is activated.
			print(" selected : accelerogyro disabled, gyrorotation enabled");
			Input.gyro.enabled = true;											// enabling gyro if this is present on sistem.
			acceGyroOff.GetComponent<AcceleroGyro> ().enabled = false;			// action to disable accelerogyro script.
			acceGyroOff.GetComponent<MoveCamera> ().enabled = false;				// disable camera rotating with mouse and keys in unity.

		}

		else if (SystemInfo.supportsGyroscope == false) {						// check if the gyroscope is disabled.
			print(" selected : accelerogyro enabled, gyrorotation disabled");
			//Input.gyro.enabled = false;										// force to disable gyroscope
			acceGyroOff.GetComponent<AcceleroGyro> ().enabled = true;			// action to enable accelerogyro script.
			acceGyroOff.GetComponent<MoveCamera> ().enabled = false;			// disable camera rotating with mouse and keys in unity.

		}
		else {
			print(" selected : accelerogyro enabled, gyrorotation disabled");
			//Input.gyro.enabled = false;										// force to disable gyroscope
			acceGyroOff.GetComponent<AcceleroGyro> ().enabled = true;			// action to enable accelerogyro script.
			acceGyroOff.GetComponent<MoveCamera> ().enabled = false;			// disable camera rotating with mouse and keys in unity.
	}
}
}