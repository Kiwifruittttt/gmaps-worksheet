using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D 
{
    public float[,] Entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
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
             float m10, float m11, float m12,
             float m20, float m21, float m22)
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

    // static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    //{
        //return // your code here
    //}

    //public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    //{
        //return // your code here
    //}

    //public static HMatrix2D operator *(HMatrix2D left, float scalar)
    //{
        //return // your code here
    //}

    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
        (
            left.Entries[0, 0] * right.x + left.Entries[0, 1] * right.x + left.Entries[0, 2] * 1,
            left.Entries[1 ,0] * right.x + left.Entries[1, 1] * right.x + left.Entries[1, 2] * 1
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
            00 01 02    xx 01 xx
            xx xx xx    xx 11 xx
            xx xx xx    xx 21 xx
            */
            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],
            left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2], 
            
            left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],
            left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],
            left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2], 

            left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],
            left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],
            left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2]
        );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if(left.Entries[x, y] != right.Entries[x, y])
                {
                    return false;
                }
            }
        }
        return true;
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
                    //HMatrix2D[x, y] = 1;
                //}
                //else
                //{
                    //HMatrix2D[x, y] = 0;
                //}
            //}
        //}

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Entries[x, y] = (x == y) ? 1 : 0;
            }
        }
    }

    public void SetTranslationMat(float transX, float transY)
    {
        SetIdentity();
        Entries[0, 0] = transX;
        Entries[1, 2] = transY;
    }

    public void SetRotationMat(float rotDeg)
    {
        SetIdentity();
        float rad = rotDeg * Mathf.Deg2Rad;
        //Entries[0, 0] = 
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
