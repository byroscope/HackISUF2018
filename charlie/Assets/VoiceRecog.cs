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
    public ConfidenceLevel confidence = ConfidenceLevel.Low;
    public AnimateV2 dog;
    

    void Start()
    {
        m_Keywords = new string[12];
        m_Keywords[0] = "out";
        m_Keywords[1] = "called";
        m_Keywords[2] = "Sit";
        m_Keywords[3] = "sniffing";
        m_Keywords[4] = "fetch";
        m_Keywords[5] = "friend";
        m_Keywords[6] = "walks";
        m_Keywords[7] = "loves";
        m_Keywords[8] = "runs";
        m_Keywords[9] = "smell";
        m_Keywords[10] = "play";
        m_Keywords[11] = "chases";


        m_Recognizer = new KeywordRecognizer(m_Keywords, confidence);
        m_Recognizer.OnPhraseRecognized += OnPharseRecognized;
        m_Recognizer.Start();
    }

    private void OnPharseRecognized(PhraseRecognizedEventArgs args)
    {
        print(args.text);

        if (args.text == m_Keywords[0] || args.text == m_Keywords[6])
        {
            dog.scene1();
            m_Keywords[6] = "";
        }
        if (args.text == m_Keywords[1] || args.text == m_Keywords[7])
        {
            dog.scene2();
            m_Keywords[7] = "";
        }
        if (args.text == m_Keywords[2] || args.text == m_Keywords[8])
        {
            dog.scene3();
            m_Keywords[8] = "";
        }
        if (args.text == m_Keywords[3] || args.text == m_Keywords[9])
        {
            dog.scene4();
            m_Keywords[9] = "";
        }
        if (args.text == m_Keywords[4] || args.text == m_Keywords[10])
        {
            dog.scene5();
            m_Keywords[10] = "";
        }
        if (args.text == m_Keywords[5] || args.text == m_Keywords[11])
        {
            dog.scene6();
            m_Keywords[11] = "";
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
        if (Input.GetKeyDown("6"))
        {
            
            dog.scene6();
        }
    }
}




