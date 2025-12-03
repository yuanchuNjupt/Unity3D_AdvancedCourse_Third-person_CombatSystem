

using UnityEngine;

public static class DevelepTools
{
    //编写一个工具类来提供指数插值
    public static float UnTetheredLerp(float time = 10f)
    {
        return 1 - Mathf.Exp(-time * Time.deltaTime);
    }
}