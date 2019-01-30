using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    public ActionHolder animal;
    public Text timer;
    public Image actions;

	public float ActionTimer;
	public float FeedTimer;
	public float PoopTimer;

    void Start ()
    {

    }
	
	void Update ()
    {

    }

    public void UpdateReferences(PetState state)
    {
        switch(state)
        {
            case PetState.Action:
                actions.sprite = animal.actions[0];
				timer.text = ActionTimer.ToString();
                break;
            case PetState.Hungry:
                actions.sprite = animal.actions[1];
				timer.text = FeedTimer.ToString();
                break;
            case PetState.Loo:
                actions.sprite = animal.actions[2];
				timer.text = PoopTimer.ToString();
                break;
        }
    }
}
