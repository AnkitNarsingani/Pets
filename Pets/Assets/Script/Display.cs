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
       
	}
	
	void Update ()
    {
        UpdateReferences();
    }

    public void UpdateReferences()
    {
        int value = (int)animal.currState;
        img.sprite = animal.Image;
        timer.text = animal.timer.ToString();
        action.text = animal.currState.ToString();
        actions.sprite = animal.actions[value];
        print(animal.actions[value]);
    }
}
