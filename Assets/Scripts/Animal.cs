using UnityEngine;

public class Animal
{
    public float hunger;
    public bool isOxygenated;
    public float stoolCapacity;
}

public class Elephant : Animal
{
    // Only the elephant knows true power
    // (private, so no other animals have access to this "coveted" information)
    private const float ELEPHANT_DUMP = float.MaxValue;

    public void TakeDump()
    {
        stoolCapacity = ELEPHANT_DUMP;
    }
}

public class Lion : Animal
{
    public void Roar()
    {
        stoolCapacity = float.MaxValue / 2.0f;
        Debug.Log("Now you know the real secret of the king of the jungle");
        Debug.Log("Shout out to Katy Perry");
    }
}

public class Giraffe : Animal
{
    bool isNeckExtended;

    public void Eat()
    {
        isNeckExtended = true;
        hunger = 0.0f;
    }
}

public class Panda : Animal
{
    float angularVelocity;
    
    public void Roll()
    {
        // 1 revolution per minute... pandas are chill :)
        angularVelocity = 1.0f;
    }
}
