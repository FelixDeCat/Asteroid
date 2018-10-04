using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Tools
{

    public static R FindObject<T,R>(this IEnumerable<T> col,R obj, Func<T,R> func)
    {
        foreach (var v in col)
        {
            return func(v);
        }

        return default(R);
    }
}
