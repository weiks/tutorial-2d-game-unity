using UnityEngine;
using Quarters;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
		CheckBalance ();
    }

	private void CheckBalance() {
//		Quarters.Quarters.Instance.GetAccountBalance (delegate (User.Account.Balance balance) {
//			Debug.Log("Balance Check Success");
//			TransferQuarters(2);
//		}, delegate (string error) {
//			Debug.Log("Balance Check Error: " + error);
//		});
//   GetAccountBalance is broken

		TransferQuarters(2);
	}

	private void TransferQuarters (int quantity) {
		TransferAPIRequest request = new TransferAPIRequest(quantity, "Tokens for starting game", delegate (string transactionHash) {
			Debug.Log("Tokens Transfer Success");
			Application.LoadLevel("Stage1");
		}, delegate (string error) {
			Debug.Log("Tokens Transfer Error: " + error);
		});

		//start transfer
		Quarters.Quarters.Instance.CreateTransfer(request);
	}

	private void PlayGame() {
		// "Stage1" is the name of the first scene we created.
		Application.LoadLevel("Stage1");
	}
}
