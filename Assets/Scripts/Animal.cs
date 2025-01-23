using UnityEngine;

public class Animal
{
    public float weight;
    public float speed;
    public Color color;
    public int age;
    public float hunger;

    public void Eat()
    {
        hunger = 0.0f;
    }

    public void Breathe()
    {

    }

    public void Drink()
    {

    }

    public void CreateChildren()
    {

    }
}

public class Cat : Animal
{
    public void Meow()
    {
        Debug.Log("Meowwwwwww");
    }
}

public class Capybara : Animal
{
    public float zenFactor;

    public void RideOtherAnimals()
    {
        // https://www.youtube.com/watch?v=TNd3DSamlcU
        Debug.Log("CAPYBARA CAPYBARA CAPYBARA CAPYBARA");
    }
}

public class Shark : Animal
{
    public Quaternion Rotate()
    {
        return Quaternion.Euler(0.0f, 0.0f, 90.0f);
    }

    public void Hunt()
    {
        Debug.Log("Dun dun.... Dun dun... Dun. Dun. Dun. Dun (Jaws)");
    }
}

public class Axolotl : Animal
{
    public float reactionTime;
    public float cutenessFactor;

    public void Regenerate()
    {
        Debug.Log("Limbs regenerating... Come back soon!");
    }

    public void BeCute()
    {
        cutenessFactor = float.MaxValue;
    }
}
