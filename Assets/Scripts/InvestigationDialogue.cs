using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InvestigationDialogue : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text suspectNameText;
    public TMP_Text questionText;
    public TMP_Text answerText;
    public TMP_Text continueText;

    [Header("Suspect Info")]
    public string suspectName;

    [TextArea(2, 4)]
    public string[] answers = new string[3];

    [Header("Scene Flow")]
    public string nextSceneName;

    private string[] questions =
    {
        "Where were you when it happened?",
        "How was your relationship with the victim?",
        "What exactly happened last night?"
    };

    private int currentIndex = -1;
    private bool interrogationStarted = false;
    private bool interrogationFinished = false;

    void Start()
    {
        suspectNameText.text = suspectName;
        questionText.text = "";
        answerText.text = "";
        continueText.text = "Press SPACE to begin interrogation";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!interrogationStarted)
            {
                interrogationStarted = true;
                currentIndex = 0;
                ShowCurrentQuestionAndAnswer();
                return;
            }

            if (!interrogationFinished)
            {
                currentIndex++;

                if (currentIndex < questions.Length)
                {
                    ShowCurrentQuestionAndAnswer();
                }
                else
                {
                    interrogationFinished = true;
                    questionText.text = "Interrogation complete.";
                    answerText.text = "";

                    if (!string.IsNullOrEmpty(nextSceneName))
                    {
                        continueText.text = "Press SPACE to move to the next suspect";
                    }
                    else
                    {
                        continueText.text = "All suspects have been questioned";
                    }
                }

                return;
            }

            if (interrogationFinished && !string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }

    void ShowCurrentQuestionAndAnswer()
    {
        if (currentIndex >= 0 && currentIndex < questions.Length && currentIndex < answers.Length)
        {
            questionText.text = "Question: " + questions[currentIndex];
            answerText.text = "Answer: " + answers[currentIndex];
            continueText.text = "Press SPACE to continue";
        }
    }
}