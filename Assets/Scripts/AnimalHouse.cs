using UnityEngine;

public class AnimalHouse : MonoBehaviour
{
    Cat cat = new Cat();
    Capybara capybara = new Capybara();
    Shark goblinShark = new Shark();
    Axolotl axolF = new Axolotl();

    void Start()
    {
        cat.Meow();                 // <-- cat-specific behaviour
        cat.color = Color.magenta;  // <-- common animal attribute
        cat.Drink();                // <-- common animal behaviour
        
        // Create lots of kittens
        for (int i = 0; i < 10; i++)
        {
            cat.CreateChildren();
        }

        capybara.zenFactor = float.MaxValue * 420.0f;   // <-- capybara-specific
        capybara.RideOtherAnimals();                    // <-- capybara-specific
        capybara.Breathe(); // Common to all animals
        capybara.Drink();   // Common to all animals

        goblinShark.Rotate();
        goblinShark.Hunt();

        // The sole purpose of axolotls is to be cute ;)
        axolF.BeCute();
    }
}
