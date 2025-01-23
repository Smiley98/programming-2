using UnityEngine;

// The "abstract" keyword means "you can't instantiate this class"!
public abstract class Shape
{
    // An abstract method is a method that has NO body, hence it MUST be overwritten
    public abstract float Area();

    // A virtual method is a method that HAS a body, but CAN be overwritten
    public virtual void PrintFormula()
    {
        // Override this to update shape-specific formula printing
        Debug.Log("Placeholder formula method");
    }

    public void PrintSideLength()
    {
        Debug.Log(name + " has a side-length of " + sideLength);
    }

    public void PrintArea()
    {
        Debug.Log("Area of " + name + " is " + Area());
    }

    public float sideLength = 0.0f;
    public string name;
}

public class Triangle : Shape
{
    // "override" means "replace previous (base class') implementation"
    public override float Area()
    {
        // Base * Height divided by two
        return (sideLength * sideLength) / 2.0f;
    }

    public override void PrintFormula()
    {
        Debug.Log("Area of a triangle is base times height");
    }
}

public class Square : Shape
{
    public override float Area()
    {
        return sideLength * sideLength;
    }

    public override void PrintFormula()
    {
        Debug.Log("Area of a square is side-length times side-length");
    }
}

public class Pentagon : Shape
{
    public override float Area()
    {
        return 0.25f * Mathf.Sqrt(5.0f * (5.0f + 2.0f * Mathf.Sqrt(5.0f))) * (sideLength * sideLength);
    }

    // https://www.google.com/search?q=area+of+a+pentagon&rlz=1C1GCEA_enCA1144CA1144&oq=area+of+a+pentagon&gs_lcrp=EgZjaHJvbWUyDggAEEUYORhDGIAEGIoFMgwIARAAGEMYgAQYigUyDAgCEAAYQxiABBiKBTIHCAMQABiABDIHCAQQABiABDIHCAUQABiABDIHCAYQABiABDIHCAcQABiABDIHCAgQABiABDIHCAkQABiABNIBCTM3MzdqMGoxNagCCLACAQ&sourceid=chrome&ie=UTF-8
    public override void PrintFormula()
    {
        Debug.Log("Area of a pentagon is some voodoo black magic");
    }
}
