using UnityEngine;

// Homework: Add the following shapes
// -Hexagon (1%)
// -Septagon(1%)
// -Octagon (1%)
// -Nonagon (1%)
// -Decagon (1%)
// In order to receive full marks, each shape must override the Area and PrintFormula methods.
// You must instantiate each shape, assign them sideLength values.
// You must test your code by adding each shape to the shapes array.
// Upload BOTH Shape.cs AND Shapes.cs scripts (uploading your project will result in a mark of ZERO).
public class Shapes : MonoBehaviour
{
    Shape triangle = new Triangle();
    Shape square = new Square();
    Shape pentagon = new Pentagon();

    void Start()
    {
        const float sideLength = 4.0f;
        triangle.sideLength = sideLength;
        square.sideLength = sideLength;
        pentagon.sideLength = sideLength;

        //triangle.PrintFormula();
        //triangle.PrintArea();
        //
        //square.PrintFormula();
        //square.PrintArea();
        //
        //pentagon.PrintFormula();
        //pentagon.PrintArea();

        // Since we standardize access with polymorphism, we can conveniently perform common operations on all our shapes!
        Shape[] shapes = {  triangle, square, pentagon };
        for (int i = 0; i < shapes.Length; i++)
        {
            Shape shape = shapes[i];
            shape.PrintFormula();
            shape.PrintArea();
        }
    }
}
