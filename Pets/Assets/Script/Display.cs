using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{

    public ActionHolder animal;
    public Image img;
    public Text timer;
    public Text action;
    public Image actions;

    void Start ()
    {
        img.sprite = animal.Image;
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
                action.text = "Barking";
                timer.text = "1";
                break;
            case PetState.Hungry:
                actions.sprite = animal.actions[1];
                action.text = "Hungry";
                timer.text = "2";
                break;
            case PetState.Loo:
                actions.sprite = animal.actions[2];
                action.text = "Shit";
                timer.text = "5";
                break;
        }
    }
}
