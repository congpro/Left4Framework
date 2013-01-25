using System.Reflection;

namespace Framework.Common
{
    public  static  class MemberFlags
    {
        #region Fields

        /// <summary>
        /// 所有实例成员和静态成员（区分大小写）。
        /// </summary>
        public const BindingFlags AnyFlags = InstanceFlags | BindingFlags.Static;

        /// <summary>
        /// 所有实例成员（区分大小写）。
        /// </summary>
        public const BindingFlags InstanceFlags = DefaultFlags | BindingFlags.Instance;

        /// <summary>
        /// 所有可获取的实例属性（区分大小写）。
        /// </summary>
        public const BindingFlags InstanceGetPropertyFlags = InstanceFlags | BindingFlags.GetProperty;

        /// <summary>
        /// 所有可设置的实例属性（区分大小写）。
        /// </summary>
        public const BindingFlags InstanceSetPropertyFlags = InstanceFlags | BindingFlags.SetProperty;

        /// <summary>
        /// 所有静态成员（区分大小写）。
        /// </summary>
        public const BindingFlags StaticFlags = DefaultFlags | BindingFlags.Static;

        /// <summary>
        /// 所有可获取的静态属性（区分大小写）。
        /// </summary>
        public const BindingFlags StaticGetPropertyFlags = StaticFlags | BindingFlags.GetProperty;

        /// <summary>
        /// 所有可设置的静态属性（区分大小写）。
        /// </summary>
        public const BindingFlags StaticSetPropertyFlags = StaticFlags | BindingFlags.SetProperty;

        private const BindingFlags DefaultFlags = BindingFlags.Public | BindingFlags.NonPublic;

        #endregion Fields
    }
}
