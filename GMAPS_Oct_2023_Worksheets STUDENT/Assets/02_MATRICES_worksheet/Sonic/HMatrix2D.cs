using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D 
{
    //Declare 3x3 array
    public float[,] Entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        //Initialise identity matrix
        SetIdentity();
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Entries[x, y] = multiArray[x, y];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
                     float m10, float m11, float m12, //Each m number are like "coordinates" of
                     float m20, float m21, float m22) //elements in the matrix?
    {
	    Entries[0, 0] = m00;
        Entries[0, 1] = m01;
        Entries[0, 2] = m02;
        Entries[1, 0] = m10;
	    Entries[1, 1] = m11;
        Entries[1, 2] = m12;
	    Entries[2, 0] = m20;
        Entries[2, 1] = m21;
        Entries[2, 2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D matResult = new HMatrix2D();
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++) //Add the corresponding element from the matrices together
            {
                matResult.Entries[x, y] = left.Entries[x, y] + right.Entries[x, y];
            }
        }
        return matResult;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D matResult = new HMatrix2D();
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x< 3; x++) //Subtract left element by the corresponding right element
            {
                matResult.Entries[x, y] = left.Entries[x, y] - right.Entries[x, y];
            }
        }
        return matResult;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D matResult = new HMatrix2D();
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++) //Multiplies each element by the scalar
            {
                matResult.Entries[x, y] = left.Entries[x, y] * scalar;
            }
        }
        return matResult;
    }

    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
        (/*
            00 01 02    1, 2?
            10 11 12
            20 21 22 */
            left.Entries[0, 0] * right.x + left.Entries[0, 1] * right.y + left.Entries[0, 2] * 1,
            left.Entries[1 ,0] * right.x + left.Entries[1, 1] * right.y + left.Entries[1, 2] * 1
        );
    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
	    /* 
            00 01 02    00 xx xx
            xx xx xx    10 xx xx
            xx xx xx    20 xx xx
            */
            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],
	    /* 
            00 01 02    00 01 02
            10 11 12    10 11 12
            20 21 22    20 21 22
            */
            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],
            left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2], 
            
            //Multiply left matrix second row with right matrix
            left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],
            left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],
            left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2], 

            //Multiply left mtrix last row with right matrix
            left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],
            left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],
            left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2]
        );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++) //If corresponding elements from two matrices are  
            {                           //not the same, return false
                if(left.Entries[x, y] != right.Entries[x, y])
                {
                    return false;
                }
            }
        }
        return true;    //If they are the same, returns true
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if(left.Entries[x, y] != right.Entries[x, y])
                {
                    return true;
                }
            }
        }
        return false;
    }

    //public HMatrix2D transpose()
    //{
        //return // your code here
    //}

    //public float GetDeterminant()
    //{
        //return // your code here
    //}

    public void SetIdentity()
    {
        //for (int y = 0, y < 3; y++)
        //{
            //for (int x = 0, x < 3; x++)
            //{
                //if(x == y)
                //{
                    //HMatrix2D[x, y] = 1; //Set element to 1 if it's on the diagonal
                //}
                //else
                //{
                    //HMatrix2D[x, y] = 0; //If it's not on the diagonal set to 0
                //}
            //}
        //}

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)             //Loops rows and columns
            {                                       //(x == y) checks if x value and y value are equal?
                Entries[x, y] = (x == y) ? 1 : 0;   //If they are, element is set to 1, else 
            }                                       //they are set to 0
        }
    }

    public void SetTranslationMat(float transX, float transY)
    {
        SetIdentity();
        Entries[0, 2] = transX; //Translates on X axis?
        Entries[1, 2] = transY; //Translates on Y axis?
    }

    public void SetRotationMat(float rotDeg)
    {
        SetIdentity();
        float rad = rotDeg * Mathf.Deg2Rad; //Converts the rotDeg from degrees to radians
        Entries[0, 0] = Mathf.Cos(rad);
        Entries[0, 1] = -Mathf.Sin(rad);    //Not sure if this is correct, I referenced 
        Entries[1, 0] = Mathf.Sin(rad);     //from an online forum :/
        Entries[1, 1] = Mathf.Cos(rad);     //https://stackoverflow.com/questions/5188876/rotation-matrix-given-angle-and-point-in-x-y-z
    }

    //public void SetScalingMat(float scaleX, float scaleY)
    //{
        // your code here
    //}

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += Entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}