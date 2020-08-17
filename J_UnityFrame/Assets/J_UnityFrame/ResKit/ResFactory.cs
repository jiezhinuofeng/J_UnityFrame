using System;

namespace J_Framework.ResKit
{
    /// <summary>
    /// 需要实现一个根据不同的前缀加载不同资源这样的一个机制。
    /// </summary>
    public class ResFactory 
    {
        private static Func<string, Res> mResCreator = s => null;

        public static Res Creat(string addRess)
        {
            if (addRess.StartsWith("resources://"))
            {
                return new Res
                {
                    Name = addRess
                };
            }

            return mResCreator.Invoke(addRess);
        }


        public static void RegisterCustomRes(Func<string,Res> customResCreator)
        {
            mResCreator = customResCreator;
        }
    }
}

