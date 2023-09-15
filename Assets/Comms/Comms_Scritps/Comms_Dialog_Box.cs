using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Comms_Dialog_Box : MonoBehaviour
{
    public static Comms_Dialog_Box _comms_Dialog_Box { get; private set; }

    public TextMeshProUGUI _textComponent;
    public float _textSpeed;

    private string _MonOpeningText = "We have some defense but not much, so be cautious these rocks could take us out quickly if they hit us. I took a scan of the asteroid field it looks like we will be out of it in about 5 Earth minutes.";
    private string _ourBombSystemIsReady = "Our Bomb’s system is ready. You get 1 every 30 seconds so use them wisely";
    private string _bombIsReady = "Bomb is ready";
    private string _sheildsAreGone = "There go our shields please be careful! If we get hit like that again it's over.";
    private string _slowMovingRocks = "A Cluster of slow-moving asteroids in front of us watch out";
    private string _thickestPartOfBelt = "We are getting to the thickest part of the belt, here they come.";
    private string _finalBossMon = "Look out!!! In front of you, that rock is huge! I don’t think one shot will do it! Keep firing!";
    private string _fixedItMon = "Fixed it, I have the engines back up.";

    private void Awake()
    {
        if(_comms_Dialog_Box != null  && _comms_Dialog_Box != this)
        {
            Destroy(this);
        }
        else
        {
            _comms_Dialog_Box = this;
        }
    }

    private void Start()
    {
        _textComponent.text = string.Empty;
    }

    public void EmptyTextBox()
    {
        _textComponent.text = string.Empty;
    }

    public void StartDialogueBoxOne()
    {
   
        StartCoroutine(TypeLine(_MonOpeningText));
    }

    public void OurBombSystemReady()
    {
        StartCoroutine(TypeLine(_ourBombSystemIsReady));
    }

    public void BombIsReady()
    {
        StartCoroutine(TypeLine(_bombIsReady));
    }

    public void SheildsAreGone()
    {
        StartCoroutine(TypeLine(_sheildsAreGone));
    }

    public void SlowMovingRocks()
    {
        StartCoroutine(TypeLine(_slowMovingRocks));
    }

    public void WeAreGettingToThickest()
    {
        StartCoroutine(TypeLine(_thickestPartOfBelt));
    }

    public void FinalBossText()
    {
        StartCoroutine(TypeLine(_finalBossMon));
    }

    public void FixedItMon()
    {
        StartCoroutine(TypeLine(_fixedItMon));
    }


    IEnumerator TypeLine(string s)
    {
        foreach (char c in s.ToCharArray())
        {
            _textComponent.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }
}
