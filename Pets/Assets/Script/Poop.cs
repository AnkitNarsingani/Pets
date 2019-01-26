using UnityEngine;

public class Poop : MonoBehaviour
{
	private void Start ()
    {

	}
	
	protected virtual bool Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider.gameObject.name.Equals(gameObject.name))
                return true;
            else
                return false;
        }
        else
            return false;
    }

}
