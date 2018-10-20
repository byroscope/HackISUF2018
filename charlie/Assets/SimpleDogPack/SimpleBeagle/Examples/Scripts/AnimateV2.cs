using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Threading;

public class AnimateV2 : MonoBehaviour {

	private Animator anim;
	private string AnimatorName;
	private int Move;
	int Pose = 0;
	int CurrentPose = 0;
	bool ChangePose = false;
	public bool StateChangeComplete = true;
	//public GameObject target;
	private string CurrentButtonPressed = "Stand";
    float speed = 10;
    Vector3 desiredPosition;

    private GameObject AggressiveButton;
	private GameObject LayButton;
	private GameObject StandButton;
	private GameObject SitButton;
	private GameObject ConsumeButton;

	private float CrossfadeVal = 0.25f;
	void Start () 
	{
		AggressiveButton = GameObject.Find("Aggressive");
		LayButton = GameObject.Find("Lay");
		StandButton = GameObject.Find("Stand");
		SitButton = GameObject.Find("Sit");
		ConsumeButton = GameObject.Find("Consume");

		anim = GetComponent<Animator> ();
		AnimatorName = anim.name;
		print ("name " + AnimatorName);
	}

	void Update () 
	{

        Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);

        if (ChangePose) 
		{
			print ("Change Pose");
			ChangePose = false;
			//if stands
			if (CurrentPose == 0) {
				if (Pose == 1) {
					anim.CrossFade ( "IdleToAggressive", CrossfadeVal);
				} else if (Pose == 2) {
					anim.CrossFade ( "IdleToSit", CrossfadeVal);
				} else if (Pose == 3) {
					anim.CrossFade (  "IdleToLay", CrossfadeVal);
				} 
				else if (Pose == 5) {
					anim.CrossFade (  "IdleToConsume", CrossfadeVal);
				} 
				CurrentPose = Pose;
			}
			//aggressive
			else if (CurrentPose == 1) {
				if (Pose == 0) {
					anim.CrossFade ( "AggressiveToIdle", CrossfadeVal);
				} else if (Pose == 2) {
					anim.CrossFade ( "AggressiveToSitTrans", CrossfadeVal);
				} else if (Pose == 3) {
					anim.CrossFade ( "AggressiveToLayTrans", CrossfadeVal);
				} else if (Pose == 4) {
					anim.CrossFade (  "AggressiveToIdle", CrossfadeVal);
				}
				else if (Pose == 5) {
					anim.CrossFade (  "AggressiveToEat", CrossfadeVal);
				} 
				CurrentPose = Pose;
			}
			//Sit
			else if (CurrentPose == 2) {
				if (Pose == 0) {
					anim.CrossFade (  "SitToIdle", CrossfadeVal);
				} else if (Pose == 1) {
					anim.CrossFade (  "SitToAggressiveTrans", CrossfadeVal);
				} else if (Pose == 3) {
					anim.CrossFade (  "SitToLay", CrossfadeVal);
				} else if (Pose == 4) {
					anim.CrossFade (  "SitToIdle", CrossfadeVal);
				}
				else if (Pose == 5) {
					anim.CrossFade (  "SitToEat", CrossfadeVal);
				} 
				CurrentPose = Pose;
			}
			//Lay
			else if (CurrentPose == 3) {
				if (Pose == 0) {
					anim.CrossFade (  "LayToIdle", CrossfadeVal);
				} else if (Pose == 1) {
					anim.CrossFade (  "LayToAggressiveTrans", CrossfadeVal);
				} else if (Pose == 2) {
					anim.CrossFade (  "LayToSit", CrossfadeVal);
				} else if (Pose == 4) {
					anim.CrossFade (  "LayToIdle", CrossfadeVal);
				}
				else if (Pose == 5) {
					anim.CrossFade (  "LayToEat", CrossfadeVal);
				} 
				CurrentPose = Pose;
			}
			//walk or consume
			else if (CurrentPose == 4 || CurrentPose == 5) {
				if (Pose == 0) {
					anim.CrossFade (  "Idle", CrossfadeVal);
				} else if (Pose == 1) {
					anim.CrossFade (  "IdleToAggressive", CrossfadeVal);
				} else if (Pose == 2) {
					anim.CrossFade (  "IdleToSit", CrossfadeVal);
				} else if (Pose == 3) {
					anim.CrossFade (  "IdleToLay", CrossfadeVal);
				}
				else if (Pose == 5) {
					anim.CrossFade (  "IdleToConsume", CrossfadeVal);
				}
				CurrentPose = Pose;
			} 
		}
	}
	public void StandButtonClicked()
	{
		if (CurrentButtonPressed != "Stand") {
			Pose = 0;
			ChangePose = true;
			//ResetButtonNames ();
		}else {
			anim.CrossFade (  StandButton.GetComponentInChildren<Text> ().text, 0.5f);
		}
		Move = 0;
		anim.SetFloat ("Move", Move);
		CurrentButtonPressed = "Stand";
	}
	public void SitButtonClicked()
	{
		if (CurrentButtonPressed != "Sit") {
			Pose = 2;
			ChangePose = true;
			//ResetButtonNames ();
		}else {
			anim.CrossFade (  SitButton.GetComponentInChildren<Text> ().text, 0.5f);
		}
		Move = 0;
		CurrentButtonPressed = "Sit";
		anim.SetFloat ("Move", Move);
        //print("about to move");
        //desiredPosition = transform.position + new Vector3(10, 0, 0);
        //iTween.MoveBy(gameObject, iTween.Hash("y", 4, "time", 2, "easeType", "linear"));
        //print("moved");
    }
	public void LayButtonClicked()
	{
		if (CurrentButtonPressed != "Lay") {
			Pose = 3;
			ChangePose = true;
			ResetButtonNames ();
		}else {
			anim.CrossFade (  LayButton.GetComponentInChildren<Text> ().text, 0.5f);
		}


		Move = 0;
		anim.SetFloat ("Move", Move);
		CurrentButtonPressed = "Lay";
	}
	public void ConsumeButtonClicked()
	{
		if (CurrentButtonPressed != "Consume") 
		{
			Pose = 5;
			ChangePose = true;
			ResetButtonNames ();
		} else {
			anim.CrossFade (  ConsumeButton.GetComponentInChildren<Text> ().text, 0.5f);
		}
		Move = 0;
		anim.SetFloat ("Move", Move);
		CurrentButtonPressed = "Consume";
	}
	public void AggressiveButtonClicked ()
	{
		if (CurrentButtonPressed != "Aggressive") 
		{
			Pose = 1;
			ChangePose = true;
			ResetButtonNames ();
		} else {
			anim.CrossFade (  AggressiveButton.GetComponentInChildren<Text> ().text, 0.5f);
		}
		Move = 0;
		anim.SetFloat ("Move", Move);
		CurrentButtonPressed = "Aggressive";
	}
	bool BackWards =false;
	public void WalkButtonClicked()
	{
		if (Move < 3 && !BackWards) 
		{
			Move++;
		}
		else 
		{
			BackWards = true;
			Move--;
			if (Move == 1) {
				BackWards = false;
			}
		}
		anim.SetFloat ("Move", Move);

		if (Pose != 4) {
			ChangePose = true;
			//ResetButtonNames ();
		}
		Pose = 4;
		CurrentButtonPressed = "Walk";
        //iTween.MoveBy(gameObject, iTween.Hash("z", .1, "time", 1.3, "easeType", "linear"));
       // iTween.MoveBy(gameObject, iTween.Hash("z", 4, "time", 2, "easeType", "linear"));
    }

    public void Walk()
    {
        WalkButtonClicked();
       // iTween.MoveBy(gameObject, iTween.Hash("z", .1, "time", 1.3, "easeType", "linear"));
        //Thread.Sleep(1300);
        iTween.MoveBy(gameObject, iTween.Hash("delay", .5, "z", 2, "time", 5, "easeType", "linear"));
    }

    void ResetButtonNames()
	{
		GameObject ButtonToReset = GameObject.Find(CurrentButtonPressed);
		ButtonToReset.GetComponentInChildren<Text> ().text = CurrentButtonPressed;
		print ("change button name and it is now " + ButtonToReset.GetComponentInChildren<Text> ().text);
		ButtonToReset.GetComponentInChildren<ChangeButtonText> ().ValuetoGet = 0;
	}
}
