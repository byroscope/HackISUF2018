using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Threading;
using System.Timers;

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
    private static System.Timers.Timer aTimer;

    public Rigidbody sticky;
    public GameObject word;
    private GameObject AggressiveButton;
    private GameObject LayButton;
    private GameObject StandButton;
    private GameObject SitButton;
    private GameObject ConsumeButton;
    public Rigidbody RigBody;
    public Rigidbody enviroFloor;
    private float CrossfadeVal = 0.25f;




    private int textNum = 0;
    void Start()
    {
        AggressiveButton = GameObject.Find("Aggressive");
        LayButton = GameObject.Find("Lay");
        StandButton = GameObject.Find("Stand");
        SitButton = GameObject.Find("Sit");
        ConsumeButton = GameObject.Find("Consume");

        anim = GetComponent<Animator>();
        AnimatorName = anim.name;
        print("name " + AnimatorName);

    }

    void Update()
    {

        if (ChangePose)
        {
            print("Change Pose");
            ChangePose = false;
            //if stands
            if (CurrentPose == 0) {
                if (Pose == 1) {
                    anim.CrossFade("IdleToAggressive", CrossfadeVal);
                } else if (Pose == 2) {
                    anim.CrossFade("IdleToSit", CrossfadeVal);
                } else if (Pose == 3) {
                    anim.CrossFade("IdleToLay", CrossfadeVal);
                }
                else if (Pose == 5) {
                    anim.CrossFade("IdleToConsume", CrossfadeVal);
                }
                CurrentPose = Pose;
            }
            //aggressive
            else if (CurrentPose == 1) {
                if (Pose == 0) {
                    anim.CrossFade("AggressiveToIdle", CrossfadeVal);
                } else if (Pose == 2) {
                    anim.CrossFade("AggressiveToSitTrans", CrossfadeVal);
                } else if (Pose == 3) {
                    anim.CrossFade("AggressiveToLayTrans", CrossfadeVal);
                } else if (Pose == 4) {
                    anim.CrossFade("AggressiveToIdle", CrossfadeVal);
                }
                else if (Pose == 5) {
                    anim.CrossFade("AggressiveToEat", CrossfadeVal);
                }
                CurrentPose = Pose;
            }
            //Sit
            else if (CurrentPose == 2) {
                if (Pose == 0) {
                    anim.CrossFade("SitToIdle", CrossfadeVal);
                } else if (Pose == 1) {
                    anim.CrossFade("SitToAggressiveTrans", CrossfadeVal);
                } else if (Pose == 3) {
                    anim.CrossFade("SitToLay", CrossfadeVal);
                } else if (Pose == 4) {
                    anim.CrossFade("SitToIdle", CrossfadeVal);
                }
                else if (Pose == 5) {
                    anim.CrossFade("SitToEat", CrossfadeVal);
                }
                CurrentPose = Pose;
            }
            //Lay
            else if (CurrentPose == 3) {
                if (Pose == 0) {
                    anim.CrossFade("LayToIdle", CrossfadeVal);
                } else if (Pose == 1) {
                    anim.CrossFade("LayToAggressiveTrans", CrossfadeVal);
                } else if (Pose == 2) {
                    anim.CrossFade("LayToSit", CrossfadeVal);
                } else if (Pose == 4) {
                    anim.CrossFade("LayToIdle", CrossfadeVal);
                }
                else if (Pose == 5) {
                    anim.CrossFade("LayToEat", CrossfadeVal);
                }
                CurrentPose = Pose;
            }
            //walk or consume
            else if (CurrentPose == 4 || CurrentPose == 5) {
                if (Pose == 0) {
                    anim.CrossFade("Idle", CrossfadeVal);
                } else if (Pose == 1) {
                    anim.CrossFade("IdleToAggressive", CrossfadeVal);
                } else if (Pose == 2) {
                    anim.CrossFade("IdleToSit", CrossfadeVal);
                } else if (Pose == 3) {
                    anim.CrossFade("IdleToLay", CrossfadeVal);
                }
                else if (Pose == 5) {
                    anim.CrossFade("IdleToConsume", CrossfadeVal);
                }
                CurrentPose = Pose;
            }
        }

        switch (textNum)
        {
            case 0:
                word.GetComponent<TextMesh>().text = "Moe is walking through the\nforest, enjoying the weather\nwhen a dog walks out.";
                break;
            case 1:
                word.GetComponent<TextMesh>().text = "Moe was startled at first,\nbut he loves dogs,\nso he called him over.";
                break;
            case 2:
                word.GetComponent<TextMesh>().text = "The dog playfully runs over.\n\"Sit!\", exclaims moe";
                break;
            case 3:
                word.GetComponent<TextMesh>().text = "Sensing an exciting smell\nthe dog starts digging\nand sniffing around";// -\n its a stick";
                break;
            case 4:
                word.GetComponent<TextMesh>().text = "The dog found a stick!\nMoe and the dog\ndecide to play fetch";
                break;
            case 5:
                word.GetComponent<TextMesh>().text = "The dog gleefuly chases\nafter the stick that his new\nfriend had thrown";
                break;
            case 6:
                word.GetComponent<TextMesh>().text = "Goodbye doggo!";
                break;                               
        }
    }
    public void StandButtonClicked()
    {
        if (CurrentButtonPressed != "Stand") {
            Pose = 0;
            ChangePose = true;
            //ResetButtonNames ();
        } else {
            anim.CrossFade(StandButton.GetComponentInChildren<Text>().text, 0.5f);
        }
        Move = 0;
        anim.SetFloat("Move", Move);
        CurrentButtonPressed = "Stand";
    }
    public void SitButtonClicked()
    {
        if (CurrentButtonPressed != "Sit") {
            Pose = 2;
            ChangePose = true;
            //ResetButtonNames ();
        } else {
            anim.CrossFade(SitButton.GetComponentInChildren<Text>().text, 0.5f);
        }
        Move = 0;
        CurrentButtonPressed = "Sit";
        anim.SetFloat("Move", Move);
    }
    public void LayButtonClicked()
    {
        if (CurrentButtonPressed != "Lay") {
            Pose = 3;
            ChangePose = true;
            ResetButtonNames();
        } else {
            anim.CrossFade(LayButton.GetComponentInChildren<Text>().text, 0.5f);
        }


        Move = 0;
        anim.SetFloat("Move", Move);
        CurrentButtonPressed = "Lay";
    }
    public void ConsumeButtonClicked()
    {
        if (CurrentButtonPressed != "Consume")
        {
            Pose = 5;
            ChangePose = true;
            ResetButtonNames();
        } else {
            anim.CrossFade(ConsumeButton.GetComponentInChildren<Text>().text, 0.5f);
        }
        Move = 0;
        anim.SetFloat("Move", Move);
        CurrentButtonPressed = "Consume";
    }
    public void AggressiveButtonClicked()
    {
        if (CurrentButtonPressed != "Aggressive")
        {
            Pose = 1;
            ChangePose = true;
            ResetButtonNames();
        } else {
            anim.CrossFade(AggressiveButton.GetComponentInChildren<Text>().text, 0.5f);
        }
        Move = 0;
        anim.SetFloat("Move", Move);
        CurrentButtonPressed = "Aggressive";
    }
    bool BackWards = false;
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
        anim.SetFloat("Move", Move);

        if (Pose != 4) {
            ChangePose = true;
            //ResetButtonNames ();
        }
        Pose = 4;
        CurrentButtonPressed = "Walk";
    }

    public void RunButtonClicked()
    {
        if (Move < 3 && !BackWards)
        {
            Move++;
        }
        else
        {
            BackWards = true;
            Move--;
            if (Move == 1)
            {
                BackWards = false;
            }
        }
        anim.SetFloat("Move", Move);

        if (Pose != 4)
        {
            ChangePose = true;
            //ResetButtonNames ();
        }
        Pose = 4;
        CurrentButtonPressed = "Walk";

    }

    public void scene1() { //comes from tree
        
        WalkButtonClicked();
        iTween.MoveBy(gameObject, iTween.Hash("delay", .5, "z", 2, "time", 5, "easeType", "linear", "oncomplete", "StandButtonClicked"));
        iTween.RotateBy(gameObject, iTween.Hash("delay", 5, "y", -.25, "time", 1.5));
        Invoke("NextText", 5);

    }

    public void scene2()
    { //runs at you
        RunButtonClicked();
        iTween.MoveBy(gameObject, iTween.Hash("delay", 1, "z", 5.5,  "time", 5, "easeType", "linear", "oncomplete", "StandButtonClicked"));
        RunButtonClicked();
        RunButtonClicked();
        iTween.RotateBy(gameObject, iTween.Hash("delay", 5.5, "y", -.1, "time", 1.5));
        Invoke("NextText", 6); //"sit"
    }
    public void scene3() {
        //sits
        SitButtonClicked();
        Invoke("NextText", 1);//"start to dig"
    }
    public void scene4()
    {
        //sniffs, diggs, stick
        anim.CrossFade("IdleSniff", CrossfadeVal);
        iTween.RotateBy(gameObject, iTween.Hash("y", 0, "time", 1.5, "oncomplete", "scene4a"));


    }
    private void scene4a() {
        anim.CrossFade("IdleDig", CrossfadeVal);
        iTween.RotateBy(gameObject, iTween.Hash("y", 0, "time", 2, "oncomplete", "scene4b"));// wait 2 sec
    
    }

    private void scene4b()
    {
        StandButtonClicked();
        sticky.GetComponent<Renderer>().enabled = true;
        Invoke("NextText", 1);

    }
    public void scene5() {
        sticky.AddForce(150, 350, 2000);
        sticky.AddTorque(500, 0, -500);
        Invoke("NextText", 2);
    }

    public void scene6()
    {
        RunButtonClicked();
        iTween.RotateBy(gameObject, iTween.Hash("delay", .5, "y", .35, "time", 1.5));
        RunButtonClicked();
        iTween.MoveBy(gameObject, iTween.Hash("delay", 1, "z", 18, "time", 9, "easeType", "linear"));
        RunButtonClicked();
        Invoke("NextText", 5);
    }


    void ResetButtonNames()
	{
		GameObject ButtonToReset = GameObject.Find(CurrentButtonPressed);
		ButtonToReset.GetComponentInChildren<Text> ().text = CurrentButtonPressed;
		print ("change button name and it is now " + ButtonToReset.GetComponentInChildren<Text> ().text);
		ButtonToReset.GetComponentInChildren<ChangeButtonText> ().ValuetoGet = 0;
	}


    private void NextText()
    {
        textNum++;
    }
}
