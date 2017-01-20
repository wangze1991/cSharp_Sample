using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 枚举位运算
{
    class Program
    {
        static void Main(string[] args)
        {
            AppUserStates state = AppUserStates.MobileVerified |AppUserStates.UserEnabled|AppUserStates.MobileVerified;
            Console.WriteLine((int)state);
            state &= ~AppUserStates.MobileVerified;
            Console.WriteLine((int)state);
            Console.WriteLine((state & AppUserStates.SecurityEmailVerified));
            Console.WriteLine(state & AppUserStates.MobileVerified);
            Console.ReadKey();
        }
    }
    /// <summary>
    /// 用户状态枚举。
    /// </summary>
    [Flags]
    public enum AppUserStates
    {
        /// <summary>
        /// 未设置任何标记。
        /// </summary>
        //None = 0,

        /// <summary>
        /// 用户已启用。
        /// </summary>
        UserEnabled = 1,

        /// <summary>
        /// 安全邮箱已验证。
        /// </summary>
        SecurityEmailVerified = 2,

        /// <summary>
        /// 用户密码已创建。
        /// </summary>
        PasswordCreated = 4,

        /// <summary>
        /// 手机已验证。
        /// </summary>
        MobileVerified = 8,

        /// <summary>
        /// 设置了所有标记。
        /// </summary>
        All = UserEnabled | SecurityEmailVerified | PasswordCreated | MobileVerified,
    }
}
