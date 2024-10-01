using UnityEngine;

public class NoteBook : MonoBehaviour
{
    [SerializeField] private Animation NotebookAnimation;
    [SerializeField] private AnimationClip Pickup;
    [SerializeField] private AnimationClip Drop;

    public bool paperup;

    void Start()
    {
        // Initialize paperup if needed
        paperup = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            if (!paperup)
            {
                NotebookAnimation.Play(Pickup.name);
                paperup = true;
            }
            else
            {
                NotebookAnimation.Play(Drop.name);
                paperup = false;
            }
        }
    }
}
