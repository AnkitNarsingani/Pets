
public class DogPoop : RayCastHit
{
    public Dog dog;
    

    void Start()
    {
        dog = FindObjectOfType<Dog>();
    }

    new void Update()
    {
        if (base.Update())
        {
            dog.GetNewAction();
            dog.display.UpdateReferences(dog.petState);
			dog.display.GetComponent<Timer> ().StartTimer ();
            Destroy(gameObject);
        }

    }
}
