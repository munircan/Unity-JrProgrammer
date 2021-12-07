using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;

    private List<string> textToDisplay = new List<string>();

    private float RotatingSpeed;
    private float TimeToNextText;

    private int CurrentText;

    // Start is called before the first frame update
    private void Start()
    {
        TimeToNextText = 0.0f;
        CurrentText = 0;

        RotatingSpeed = 1.0f;

        textToDisplay.Add("Congratulation");
        textToDisplay.Add("All Errors Fixed");

        Text.text = textToDisplay[0];

        SparksParticles.Play();
    }

    // Update is called once per frame
    private void Update()
    {
        Text.transform.Rotate(0, RotatingSpeed, 0);
        SparksParticles.transform.Rotate(0, RotatingSpeed, 0);

        TimeToNextText += Time.deltaTime;
        if (!(TimeToNextText >= 1.5f)) return;
        CurrentText++;
        if (CurrentText >= textToDisplay.Count)
        {
            CurrentText = 0;
        }

        Text.text = textToDisplay[CurrentText];
        TimeToNextText = 0.0f;
    }
}