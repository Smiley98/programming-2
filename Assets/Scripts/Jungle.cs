using UnityEngine;

public class Jungle : MonoBehaviour
{
    Elephant elephant = new Elephant();
    Lion lion = new Lion();
    Giraffe giraffe = new Giraffe();
    Panda panda = new Panda();

    void Start()
    {
        // Attributes common to all Animals
        elephant.hunger = 69420.0f;
        lion.hunger = 42.0f;
        giraffe.hunger = 0.0f;  // <-- Full of leaves and all things tasty!
        panda.hunger = 0.0f;    // <-- Eats shoots and leaves

        elephant.TakeDump();
        lion.Roar();
        giraffe.Eat();
        panda.Roll();
    }
}
