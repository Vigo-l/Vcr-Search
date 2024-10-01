using UnityEngine;

public class Door : Interactable
{

    public Animation dooranimation;
    public AnimationClip DoorOpen;

    public GameObject InteractText;

    public bool doorclosed = true;

    [Header("Animations")]
    [SerializeField] private Animation MonsterAnimations;
    [SerializeField] private AnimationClip MonsterDoor;

    public override void OnFocus()
    {
        if (doorclosed)
        {
            InteractText.SetActive(true);
        }

    }

    public override void OnInteract()
    {
        if (doorclosed == true)
        {
            dooranimation.Play(DoorOpen.name);
            doorclosed = false;
            MonsterAnimations.Play(MonsterDoor.name);
        }

    }

    public override void OnLoseFocus()
    {
        InteractText.SetActive(false);
    }


}
