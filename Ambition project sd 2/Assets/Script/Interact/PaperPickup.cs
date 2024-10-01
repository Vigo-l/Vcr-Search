using UnityEngine;

public class PaperPickup : Interactable
{
    public Animation animation;
    public AnimationClip Pickup;
    public AnimationClip Drop;

    public bool PickedUp;

    public GameObject InteractText;

    public override void OnFocus()
    {
        if (PickedUp == false)
        {
            InteractText.SetActive(true);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PickedUp == true)
            {
                animation.Play(Drop.name);
                PickedUp = false;
            }

        }
    }

    public override void OnInteract()
    {
        if (PickedUp == false)
        {
            animation.Play(Pickup.name);
            InteractText.SetActive(false);
            PickedUp = true;
        }
        else
        {
            animation.Play(Drop.name);
            PickedUp = false;
        }


    }

    public override void OnLoseFocus()
    {
        InteractText.SetActive(false);
    }
}
