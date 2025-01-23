using UnityEngine;

// "abstract" prevents our base-class from being instantiated. Only derived-classes can be instantiated
public abstract class Shape
{
    // An "abstract method" is a function without a body that derived-classes must implement.
    public abstract float Area();
    public abstract string Name();


    // A "virtual" method is a function that can be modified in the derived-class, but may also be left in the base class if desired
    public virtual void PrintFormula()
    {
        Debug.Log("Placehold formula output");
    }

    // Regular class method (functions -- "behavour")
    public void PrintArea()
    {
        Debug.Log("Area of " + Name() + " is " + Area());
    }

    // Regular class members (variables -- "data")
    public float sideLength;
}

public class Triangle : Shape
{
    // "override" changes the behaviour of a base-class method (needed to implement abstract methods)
    public override float Area()
    {
        // Bass * Height / 2.0f
        return sideLength * sideLength / 2.0f;
    }

    public override string Name()
    {
        return "Triangle";
    }

    // Even though base-class PrintFormula is virtual, we can still override it to enhance our output! 
    public override void PrintFormula()
    {
        Debug.Log("Area of a " + Name() + " is bass times height divided by two");
    }
}

public class Square : Shape
{
    public override float Area()
    {
        // Bass * Height
        return sideLength * sideLength;
    }

    public override string Name()
    {
        return "Square";
    }

    public override void PrintFormula()
    {
        Debug.Log("Area of a " + Name() + " is bass times height");
    }
}

public class Pentagon : Shape
{
    public override float Area()
    {
        return 0.25f * Mathf.Sqrt(5.0f * (5.0f + 2.0f * Mathf.Sqrt(5.0f))) * sideLength * sideLength;
    }

    public override string Name()
    {
        return "Pentagon";
    }

    public override void PrintFormula()
    {
        Debug.Log("Area of a " + Name() + " is magic voodoo");
    }
}
