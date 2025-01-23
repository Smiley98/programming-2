using UnityEngine;

// Homework: Add the following shapes
// -Hexagon (1%)
// -Septagon(1%)
// -Octagon (1%)
// -Nonagon (1%)
// -Decagon (1%)
// In order to receive full marks, each shape must override the Area and PrintFormula methods.
// You must instantiate each shape, assign them name & sideLength values.
// You must test your code by adding each shape to the shapes array.
// Upload BOTH Shape.cs AND Shapes.cs scripts (uploading your project will result in a mark of ZERO).

public class Shapes : MonoBehaviour
{
    Shape triangle = new Triangle();
    Shape square = new Square();
    Shape pentagon = new Pentagon();
    void Start()
    {
        triangle.name = "Triangle";
        triangle.sideLength = 4.0f;
        //triangle.PrintFormula();
        //triangle.PrintSideLength();
        //triangle.PrintArea();

        square.name = "Square";
        square.sideLength = 4.0f;
        //square.PrintFormula();
        //square.PrintSideLength();
        //square.PrintArea();

        pentagon.name = "Pentagon";
        pentagon.sideLength = 4.0f;
        //pentagon.PrintFormula();
        //pentagon.PrintSideLength();
        //pentagon.PrintArea();

        // An advantage of polymorphism is automation.
        // We can do large-scale operations by looping through an array of objects!
        Shape[] shapes = { triangle, square, pentagon };
        for (int i = 0; i < shapes.Length; i++)
        {
            Shape shape = shapes[i];
            shape.PrintFormula();
            shape.PrintSideLength();
            shape.PrintArea();
        }
    }
}
