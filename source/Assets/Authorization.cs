using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quarters;

public class Authorization : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		if (!Quarters.Quarters.IsAuthorized) {
			Quarters.Quarters.Instance.Authorize(OnAuthorizationSuccess, OnAuthorizationFailed);
//		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void getUserDetails () {
		Quarters.Quarters.Instance.GetUserDetails(delegate(User user) {
			Debug.Log("User loaded");
			Debug.Log("Display Name: " + user.displayName);
			Debug.Log("Email: " + user.email);

		} , delegate (string error) {
			Debug.LogError("Cannot load the user details: " + error);

		} );
	}

	public void OnAuthorizationSuccess() {
		Debug.Log("OnAuthorizationSuccess");
		getUserDetails ();
	}
		
	public void OnAuthorizationFailed(string error) {
		Debug.LogError("OnAuthorizationFailed: " + error);

	}
}