using System.Collections;
using UnityEngine;

public class LeaveCar : Interactable
{
    public Animation animation;
    public AnimationClip Leave;


    public GameObject Player;
    [SerializeField] private GameObject IntroCamera;

    public GameObject InteractText;


    public override void OnFocus()
    {
        InteractText.SetActive(true);
    }

    public override void OnInteract()
    {
        InteractText.SetActive(false);
        InteractText = null;
        IntroCamera.SetActive(true);
        animation.Play(Leave.name);
        StartCoroutine(endscene());
    }

    public override void OnLoseFocus()
    {
        InteractText.SetActive(false);
    }

    IEnumerator endscene()
    {
        float animationlenght = Leave.length;
        yield return new WaitForSeconds(7);
        Application.Quit();
    }
}
