using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;
    [SerializeField] private TMP_Text instructiontext;
    [SerializeField] private Image instruction;
    [SerializeField] private TutorialMovement movement;
    [SerializeField] private TutorialCamera cameraManager;

    private bool btutorial;
    public bool IsInTutorial
    { get { return btutorial; } }

    private bool binstruct=false;

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    private void Start()
    {
        btutorial = true;
        instruction.gameObject.SetActive(true);
        instructiontext.text = "Press A and D to move the player";
    }

    private void Update()
    {
        if (instruction.color.a > 0 && binstruct)
        {
            float a = instruction.color.a - 0.5f * Time.deltaTime;
            instruction.color = new Color(0.6037736f, 0.6037736f, 0.6037736f, a);
        }
        else if(instruction.color.a<=0)
        {
            instruction.gameObject.SetActive(false);
            binstruct = false;
        }

        if (movement.Moved2D)
        {
            binstruct = true;
        }

        if(cameraManager.CamSwitched)
        {
            binstruct = true;
            Invoke("TDMoveTutorial", 3f);
        }

        if(movement.MovedTD)
        {
            binstruct = true;
            Invoke("Objective", 3f);
        }
    }

    public void Cameratutorial()
    {
        cameraManager.CanSwitchCamera = true;
        instruction.gameObject.SetActive(true);
        instruction.color = new Color(0.6037736f, 0.6037736f, 0.6037736f, 1);
        instructiontext.text = "Press C to switch camera";
    }

    private void TDMoveTutorial()
    {
        movement.CanMoveTD = true;
        instruction.gameObject.SetActive(true);
        instruction.color = new Color(0.6037736f, 0.6037736f, 0.6037736f, 1);
        instructiontext.text = "Press WASD to move the player";
    }

    private void Objective()
    {
        instruction.gameObject.SetActive(true);
        instruction.color = new Color(0.6037736f, 0.6037736f, 0.6037736f, 1);
        instructiontext.text = "Collect the Key and Open the door";
        Invoke("Close", 5f);
    }

    private void Close()
    {
        btutorial = false;
        binstruct = true;
    }
}
