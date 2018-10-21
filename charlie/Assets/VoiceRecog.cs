using System;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Text;
using UnityEngine.UI;

public class VoiceRecog : MonoBehaviour
{

    [SerializeField]
    private string[] m_Keywords;

    private KeywordRecognizer m_Recognizer;
    public GameObject Cube;
    public AnimateV2 dog;
    public GameObject word;

    void Start()
    {
        m_Keywords = new string[7];
        m_Keywords[0] = "sit";
        m_Keywords[1] = "stand";
        m_Keywords[2] = "walk";
        m_Keywords[3] = "text";
        m_Keywords[4] = "run";
        m_Keywords[5] = "change";
        m_Keywords[6] = "throw";

        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPharseRecognized;
        m_Recognizer.Start();
    }

    private void OnPharseRecognized(PhraseRecognizedEventArgs args)
    {
        float newX = UnityEngine.Random.Range(-3, 3);
        float newY = UnityEngine.Random.Range(-3, 3);
        //float newX = (0);
       // float newY = (0);
        float newZ = (1);

        print(args.text);

        if (args.text == m_Keywords[0])
        {
            //Instantiate(Cube, new Vector3(newX, newZ, newY), Quaternion.identity);
            dog.SitButtonClicked();
           
        }

        if (args.text == m_Keywords[1])
        {
            //Instantiate(Sphere, new Vector3(newX, newZ, newY), Quaternion.identity);
            dog.StandButtonClicked();
        }

        if (args.text == m_Keywords[2])
        {
            //Instantiate(Sphere, new Vector3(newX, newZ, newY), Quaternion.identity);
            dog.Walk();
        }

        if (args.text == m_Keywords[3])
        {
            word.GetComponent<Renderer>().enabled = true;
        }

        if (args.text == m_Keywords[5])
        {
            word.GetComponent<TextMesh>().text = "lakisudhfi";

        }
        if (args.text == m_Keywords[4])
        {
            //Instantiate(Sphere, new Vector3(newX, newZ, newY), Quaternion.identity);
            dog.Run();

        }



        if (args.text == m_Keywords[6]) {



        }

    }


    // Update is called once per frame
    void Update()
    {
       // print("yoyo");
        if (Input.GetKeyDown("1")) {
            dog.scene1();
        }
        if (Input.GetKeyDown("2"))
        {
            dog.scene2();
        }
        if (Input.GetKeyDown("3"))
        {
            dog.scene3();
        }
        if (Input.GetKeyDown("4"))
        {
            dog.scene4();
        }
        if (Input.GetKeyDown("5"))
        {
            dog.scene5();
        }
    }
}




