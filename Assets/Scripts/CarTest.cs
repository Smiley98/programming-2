using UnityEngine;

public class CarTest : MonoBehaviour
{
    void Start()
    {
        Car car = new Car();
        car.Park();
        if (car.gas > 0)
        {
            // "How fast are we driving?" "Yes"
            car.Drive(Vector3.forward * float.MaxValue);

            // TODO - Make an audio lesson that loads Initial D soundtracks
            if (car.IsDrifting())
            {
                Debug.Log("Scrrrrrrrrrrt");

                // Drifted a little too hard there bud
                car.Explode();
            }
        }
    }
}
