using UnityEngine;

public delegate float MathOperation(float a, float b);

public class Delegates : MonoBehaviour
{
    float Add(float a, float b)
    {
        return a + b;
    }
    float Sub(float a, float b)
    {
        return a - b;
    }

    float Mul(float a, float b)
    {
        return a * b;
    }

    float Div(float a, float b)
    {
        return a / b;
    }

    void Start()
    {
        MathOperation op = null;
        float x = 1.0f;
        float y = 2.0f;

        op = Add;
        float sum = op(x, y);

        op = Sub;
        float diff = op(x, y);

        op = Mul;
        float product = op(x, y);

        op = Div;
        float quotient = op(x, y);

        Debug.Log(sum);
        Debug.Log(diff);
        Debug.Log(product);
        Debug.Log(quotient);
    }
}
