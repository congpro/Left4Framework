using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Framework.Common
{
    public  static  class Types
    {
        #region Fields

        /// <summary>
        /// 表示 <see cref="System.Array"/> 的类型。
        /// </summary>
        public static readonly Type Array = typeof(System.Array);

        /// <summary>
        /// 表示 <see cref="System.Convert"/> 的类型。
        /// </summary>
        public static readonly Type Convert = typeof(System.Convert);
        /// <summary>
        /// 表示 <see cref="System.Collections.IEnumerator"/> 的类型。
        /// </summary>
        public static readonly Type IEnumerator = typeof(System.Collections.IEnumerator);

        /// <summary>
        /// 表示 <see cref="System.Boolean"/> 的类型。
        /// </summary>
        public static readonly Type Boolean = typeof(System.Boolean);

        /// <summary>
        /// 表示 <see cref="System.Byte"/> 的类型。
        /// </summary>
        public static readonly Type Byte = typeof(System.Byte);

        /// <summary>
        /// 表示 <see cref="System.Byte"/> 数组的类型。
        /// </summary>
        public static readonly Type ByteArray = typeof(System.Byte[]);

        /// <summary>
        /// 表示 <see cref="System.Char"/> 的类型。
        /// </summary>
        public static readonly Type Char = typeof(System.Char);

        /// <summary>
        /// 表示 <see cref="System.Char"/> 数组数组的类型。
        /// </summary>
        public static readonly Type CharArray = typeof(System.Char[]);

        #region No SILVERLIGHT
#if !SILVERLIGHT

        /// <summary>
        /// 表示 <see cref="System.Collections.Hashtable"/> 的类型。
        /// </summary>
        public static readonly Type Hashtable = typeof(System.Collections.Hashtable);

        /// <summary>
        /// 表示 <see cref="System.Collections.ArrayList"/> 的类型。
        /// </summary>
        public static readonly Type ArrayList = typeof(System.Collections.ArrayList);

        /// <summary>
        /// 表示 <see cref="System.Data.DataSet"/> 的类型。
        /// </summary>
        public static readonly Type DataSet = typeof(System.Data.DataSet);

        /// <summary>
        /// 表示 <see cref="System.Data.DataTable"/> 的类型。
        /// </summary>
        public static readonly Type DataTable = typeof(System.Data.DataTable);

        /// <summary>
        /// 表示 <see cref="System.Data.DataRow"/> 的类型。
        /// </summary>
        public static readonly Type DataRow = typeof(System.Data.DataRow);
        /// <summary>
        /// 表示 <see cref="System.Data.DataColumn"/> 的类型。
        /// </summary>
        public static readonly Type DataColumn = typeof(System.Data.DataColumn);
#endif
        #endregion

        /// <summary>
        /// 表示 <see cref="System.DateTime"/> 的类型。
        /// </summary>
        public static readonly Type DateTime = typeof(System.DateTime);

        /// <summary>
        /// 表示 <see cref="System.DBNull"/> 的类型。
        /// </summary>
        public static readonly Type DBNull = typeof(DBNull);

        /// <summary>
        /// 表示 <see cref="System.Decimal"/> 的类型。
        /// </summary>
        public static readonly Type Decimal = typeof(System.Decimal);

        /// <summary>
        /// 表示 <see cref="System.Delegate"/> 的类型。
        /// </summary>
        public static readonly Type Delegate = typeof(System.Delegate);

        /// <summary>
        /// 表示 <see cref="System.Double"/> 的类型。
        /// </summary>
        public static readonly Type Double = typeof(System.Double);

        /// <summary>
        /// 表示 <see cref="System.Enum"/> 的类型。
        /// </summary>
        public static readonly Type Enum = typeof(Enum);

        /// <summary>
        /// 表示 <see cref="System.Exception"/> 的类型。
        /// </summary>
        public static readonly Type Exception = typeof(System.Exception);

        /// <summary>
        /// 表示 Flase 的字符串形式。
        /// </summary>
        public static readonly string[] FlaseStrings = { "flase", "否", "非校验", "Unchecked", "0", "No" };

        /// <summary>
        /// 表示 <see cref="System.Collections.Generic.Dictionary&lt;TKey, TValue&gt;"/> 的类型。
        /// </summary>
        public static readonly Type GDictionary = typeof(System.Collections.Generic.Dictionary<,>);

        /// <summary>
        /// 表示 <see cref="System.Collections.Generic.IDictionary&lt;TKey, TValue&gt;"/> 的类型。
        /// </summary>
        public static readonly Type GIDictionary = typeof(System.Collections.Generic.IDictionary<,>);

        /// <summary>
        /// 表示 <see cref="System.Collections.Generic.IList&lt;T&gt;"/> 的类型。
        /// </summary>
        public static readonly Type GIList = typeof(System.Collections.Generic.IList<>);

        /// <summary>
        /// 表示 <see cref="System.Collections.Generic.List&lt;T&gt;"/> 的类型。
        /// </summary>
        public static readonly Type GList = typeof(System.Collections.Generic.List<>);

        /// <summary>
        /// 表示 <see cref="System.Guid"/> 的类型。
        /// </summary>
        public static readonly Type Guid = typeof(System.Guid);

        /// <summary>
        /// 表示 <see cref="System.Collections.ICollection"/> 的类型。
        /// </summary>
        public static readonly Type ICollection = typeof(System.Collections.ICollection);

        /// <summary>
        /// 表示 <see cref="System.IConvertible"/> 的类型。
        /// </summary>
        public static readonly Type IConvertible = typeof(IConvertible);

        /// <summary>
        /// 表示 <see cref="System.Collections.IDictionary"/> 的类型。
        /// </summary>
        public static readonly Type IDictionary = typeof(System.Collections.IDictionary);

        /// <summary>
        /// 表示 <see cref="System.IDisposable"/> 的类型。
        /// </summary>
        public static readonly Type IDisposable = typeof(System.IDisposable);
        /// <summary>
        /// 表示 <see cref="System.Collections.IList"/> 的类型。
        /// </summary>
        public static readonly Type IList = typeof(System.Collections.IList);

        /// <summary>
        /// 表示 <see cref="System.Int16"/> 的类型。
        /// </summary>
        public static readonly Type Int16 = typeof(System.Int16);

        /// <summary>
        /// 表示 <see cref="System.Int32"/> 的类型。
        /// </summary>
        public static readonly Type Int32 = typeof(System.Int32);

        /// <summary>
        /// 表示 <see cref="System.Int64"/> 的类型。
        /// </summary>
        public static readonly Type Int64 = typeof(System.Int64);

        /// <summary>
        /// 表示 <see cref="System.IO.MemoryStream"/> 的类型。
        /// </summary>
        public static readonly Type MemoryStream = typeof(System.IO.MemoryStream);

        /// <summary>
        /// 表示 <see cref="System.Nullable&lt;T&gt;"/> 的类型。
        /// </summary>
        public static readonly Type Nullable = typeof(Nullable<>);

        /// <summary>
        /// 表示浮点数的数据类型集合。
        /// </summary>
        public static readonly Type[] NumberFloatTypes = { Single, Double, Decimal };

        /// <summary>
        /// 表示数字的数据类型集合。
        /// </summary>
        public static readonly Type[] NumberTypes = {SByte,Byte, UInt16, UInt32, UInt64
                                                     ,Int16, Int32, Int64
                                                     , Single,Double,Decimal };

        /// <summary>
        /// 表示 <see cref="System.Object"/> 的类型。
        /// </summary>
        public static readonly Type Object = typeof(System.Object);

        /// <summary>
        /// 表示 <see cref="System.Object"/> 数组的类型。
        /// </summary>
        public static readonly Type ObjectArray = typeof(System.Object[]);

        /// <summary>
        /// 表示 <see cref="System.Object"/> 的类型（ref）。
        /// </summary>
        public static readonly Type RefObject = Object.MakeByRefType();

        /// <summary>
        /// 表示 <see cref="System.Text.RegularExpressions.Regex"/> 的类型。
        /// </summary>
        public static readonly Type Regex = typeof(System.Text.RegularExpressions.Regex);

        /// <summary>
        /// 表示 <see cref="System.SByte"/> 的类型。
        /// </summary>
        public static readonly Type SByte = typeof(System.SByte);

        /// <summary>
        /// 表示 <see cref="System.Single"/> 的类型。
        /// </summary>
        public static readonly Type Single = typeof(System.Single);

        /// <summary>
        /// 表示 <see cref="System.IO.Stream"/> 的类型。
        /// </summary>
        public static readonly Type Stream = typeof(System.IO.Stream);

        /// <summary>
        /// 表示 <see cref="System.String"/> 的类型。
        /// </summary>
        public static readonly Type String = typeof(System.String);

        /// <summary>
        /// 表示 <see cref="System.Text.StringBuilder"/> 的类型。
        /// </summary>
        public static readonly Type StringBuilder = typeof(System.Text.StringBuilder);

        /// <summary>
        /// 表示 <see cref="System.TimeSpan"/> 的类型。
        /// </summary>
        public static readonly Type TimeSpan = typeof(System.TimeSpan);

        /// <summary>
        /// 表示 True 的字符串形式。
        /// </summary>
        public static readonly string[] TrueStrings = { "true", "是", "校验", "Checked", "1", "Yes" };

        /// <summary>
        /// 表示 <see cref="System.Type"/> 的类型。
        /// </summary>
        public static readonly Type Type = typeof(Type);

        /// <summary>
        /// 表示 <see cref="System.Type"/>[] 的类型。
        /// </summary>
        public static readonly Type TypeArray = typeof(Type[]);

        /// <summary>
        /// 表示 <see cref="System.UInt16"/> 的类型。
        /// </summary>
        public static readonly Type UInt16 = typeof(System.UInt16);

        /// <summary>
        /// 表示 <see cref="System.UInt32"/> 的类型。
        /// </summary>
        public static readonly Type UInt32 = typeof(System.UInt32);

        /// <summary>
        /// 表示 <see cref="System.UInt64"/> 的类型。
        /// </summary>
        public static readonly Type UInt64 = typeof(System.UInt64);

        /// <summary>
        /// 表示 void 的类型。
        /// </summary>
        public static readonly Type Void = typeof(void);

        #endregion Fields

        #region Methods

        /// <summary>
        /// 返回一个类型的默认值。
        /// </summary>
        /// <param name="type">值类型或引用类型。</param>
        /// <returns>返回类型的默认值。</returns>
        public static object GetDefaultValue(this Type type)
        {
            return type.IsValueType && !(type.IsGenericType && type.GetGenericTypeDefinition().Equals(Types.Nullable))
                ? Activator.CreateInstance(type)
                : null;
        }

#if !SILVERLIGHT
        /// <summary>
        /// 判断一个类型是否为 <see cref="System.Data.DataTable"/> 或 <see cref="System.Data.DataSet"/> 的类型。
        /// </summary>
        /// <typeparam name="T">数据类型。</typeparam>
        /// <returns>如果类型为 <see cref="System.Data.DataTable"/> 或 <see cref="System.Data.DataSet"/>，则返回 true，否则返回 false。</returns>
        public static bool IsDataType<T>()
        {
            return IsDataType(typeof(T));
        }

        /// <summary>
        /// 判断一个类型是否为 <see cref="System.Data.DataTable"/> 或 <see cref="System.Data.DataSet"/> 的类型。
        /// </summary>
        /// <param name="type">数据类型。</param>
        /// <returns>如果类型为 <see cref="System.Data.DataTable"/> 或 <see cref="System.Data.DataSet"/>，则返回 true，否则返回 false。</returns>
        public static bool IsDataType(this Type type)
        {
            return DataTable.IsAssignableFrom(type) || DataSet.IsAssignableFrom(type);
        }
#endif

        /// <summary>
        /// 判断一个类型是否为可空类型。
        /// </summary>
        /// <param name="type">需要判断的类型。</param>
        /// <returns>如果为 true 则是一个可空类型，否则为 false。</returns>
        public static bool IsNullable(this Type type)
        {
            return type.IsValueType && type.IsGenericType && type.GetGenericTypeDefinition().Equals(Types.Nullable);
        }

        /// <summary>
        /// 判断一个类型是否为数字类型。
        /// </summary>
        /// <param name="type">数据类型。</param>
        /// <returns>如果类型为任意数字类型则返回 true，否则返回 false。</returns>
        public static bool IsNumber(this Type type)
        {
            return System.Array.IndexOf(NumberTypes, type) > -1;
        }

        /// <summary>
        /// 判断一个类型是否为浮点数类型。
        /// </summary>
        /// <param name="type">数据类型。</param>
        /// <returns>如果类型为 <see cref="System.Single"/>、<see cref="System.Double"/> 或 <see cref="System.Decimal"/> 则返回 true，否则返回 false。</returns>
        public static bool IsNumberFloat(this Type type)
        {
            return System.Array.IndexOf(NumberFloatTypes, type) > -1;
        }

        /// <summary>
        /// 返回由 <typeparamref name="T"/> 标识的特性（包括继承链）。
        /// </summary>
        /// <typeparam name="T">特性的数据类型。</typeparam>
        /// <param name="member">成员。</param>
        /// <returns>如果存在标志，则返回这个值，否则返回一个默认值。</returns>
        public static T GetAttribute<T>(this MemberInfo member)
            where T : Attribute
        {
            return GetAttribute<T>(member, true);
        }

        /// <summary>
        /// 返回由 <typeparamref name="T"/> 标识的特性。
        /// </summary>
        /// <typeparam name="T">特性的数据类型。</typeparam>
        /// <param name="member">成员。</param>
        /// <param name="inherit">指定是否搜索该成员的继承链以查找这些属性。</param>
        /// <returns>如果存在标志，则返回这个值，否则返回一个默认值。</returns>
        public static T GetAttribute<T>(this MemberInfo member, bool inherit)
            where T : Attribute
        {
            if (member != null)
            {
                var ats = member.GetCustomAttributes(typeof(T), inherit);
                if (ats.Length > 0) return (T)ats[0];
            }
            return default(T);
        }

        /// <summary>
        /// 查找指定名称的字段（不区分大小写、静态、实例、公有和私有）。
        /// </summary>
        /// <param name="type">数据类型。</param>
        /// <param name="name">字段名称。</param>
        /// <returns>返回一个字段或一个 null 值。</returns>
        public static FieldInfo FindField(this Type type, string name)
        {
            if (type == null) throw new ArgumentNullException("type");
            return type.GetField(name, MemberFlags.AnyFlags);
        }

        /// <summary>
        /// 查找指定名称的属性（不区分大小写、静态、实例、公有和私有）。
        /// </summary>
        /// <param name="type">数据类型。</param>
        /// <param name="name">属性名称。</param>
        /// <returns>返回一个属性或一个 null 值。</returns>
        public static PropertyInfo FindProperty(this Type type, string name)
        {
            if (type == null) throw new ArgumentNullException("type");
            return type.GetProperty(name, MemberFlags.AnyFlags);
        }

        /// <summary>
        /// 查找指定参数类型数组和名称的方法（不区分大小写、静态、实例、公有和私有）。
        /// </summary>
        /// <param name="type">数据类型。</param>
        /// <param name="name">方法名称。</param>
        /// <param name="types">方法的参数类型数组。</param>
        /// <returns>返回一个方法或一个 null 值。</returns>
        public static MethodInfo FindMethod(this Type type, string name, params Type[] types)
        {
            if (type == null) throw new ArgumentNullException("type");
            if (types == null || types.Length == 0) return type.GetMethod(name, MemberFlags.AnyFlags);
            return type.GetMethod(name, MemberFlags.AnyFlags, null, types, null);
        }

        /// <summary>
        /// 查找指定参数类型数组的构造函数。
        /// </summary>
        /// <param name="type">数据类型。</param>
        /// <param name="types">构造函数的参数类型数组。</param>
        /// <returns>返回一个构造函数或一个 null 值。</returns>
        public static ConstructorInfo FindConstructor(this Type type, params Type[] types)
        {
            if (type == null) throw new ArgumentNullException("type");
            return type.GetConstructor(MemberFlags.AnyFlags, null, types ?? System.Type.EmptyTypes, null);
        }


        #endregion Methods
    }
}
