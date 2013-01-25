using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Framework.Common
{
        /// <summary>
        /// Emit 生成器助手。
        /// </summary>
        public class EmitHelper
        {
            #region Fields

            /// <summary>
            /// 值类型转换集合。
            /// </summary>
            private static readonly Dictionary<Type, OpCode> s_Converts;

            private DynamicMethod _DynamicMethod;
            private ILGenerator _ILGenerator;

            #endregion Fields

            #region Constructors

            static EmitHelper()
            {
                s_Converts = new Dictionary<Type, OpCode>(13);

                s_Converts.Add(Types.SByte, OpCodes.Conv_I1);
                s_Converts.Add(Types.Int16, OpCodes.Conv_I2);
                s_Converts.Add(Types.Int32, OpCodes.Conv_I4);
                s_Converts.Add(Types.Int64, OpCodes.Conv_I8);

                s_Converts.Add(Types.Byte, OpCodes.Conv_U1);
                s_Converts.Add(Types.UInt16, OpCodes.Conv_U2);
                s_Converts.Add(Types.UInt32, OpCodes.Conv_U4);
                s_Converts.Add(Types.UInt64, OpCodes.Conv_U8);

                s_Converts.Add(Types.Single, OpCodes.Conv_R4);
                s_Converts.Add(Types.Double, OpCodes.Conv_R8);
                s_Converts.Add(Types.Decimal, OpCodes.Conv_R8);

                s_Converts.Add(Types.Boolean, OpCodes.Conv_I1);
                s_Converts.Add(Types.Char, OpCodes.Conv_U2);
            }
#if SILVERLIGHT
        /// <summary>
        /// 指定方法名称、返回类型、参数类型、动态方法逻辑关联的类型，初始化 <see cref="Sofire.Dynamic.EmitHelper"/> 类的新实例。
        /// </summary>
        /// <param name="name">方法名称。</param>
        /// <param name="returnType">返回类型。</param>
        /// <param name="parameterTypes">参数类型。</param>
        /// <param name="initLocals">指示方法中的局部变量是否初始化为零。</param>
        public EmitHelper(string name, Type returnType, Type[] parameterTypes, bool initLocals)
            : this(new DynamicMethod(name, returnType, parameterTypes), initLocals)
#else
            /// <summary>
            /// 指定方法名称、返回类型、参数类型、动态方法逻辑关联的类型，初始化 <see cref="Sofire.Dynamic.EmitHelper"/> 类的新实例。
            /// </summary>
            /// <param name="name">方法名称。</param>
            /// <param name="returnType">返回类型。</param>
            /// <param name="parameterTypes">参数类型。</param>
            /// <param name="owner">逻辑关联的类型。</param>
            /// <param name="skipVisibility">要跳过动态方法的 MSIL 访问的类型和成员的 JIT 可见性检查，则为 true；否则为 false。</param>
            /// <param name="initLocals">指示方法中的局部变量是否初始化为零。</param>
            public EmitHelper(string name, Type returnType, Type[] parameterTypes, Type owner, bool skipVisibility, bool initLocals)
                : this(new DynamicMethod(name, returnType, parameterTypes, owner, skipVisibility), initLocals)
#endif
            {
            }

            /// <summary>
            /// 指定动态方法，初始化 <see cref="Sofire.Dynamic.EmitHelper"/> 类的新实例。
            /// </summary>
            /// <param name="dynamicMethod">表示一种可编译、执行和丢弃的动态方法。</param>
            /// <param name="initLocals">指示方法中的局部变量是否初始化为零。</param>
            public EmitHelper(DynamicMethod dynamicMethod, bool initLocals)
            {
                dynamicMethod.InitLocals = initLocals; //- 不进行局部变量的初始化
                this._ILGenerator = dynamicMethod.GetILGenerator();
                this._DynamicMethod = dynamicMethod;
            }

            #endregion Constructors

            #region Properties

            /// <summary>
            /// 获取动态方法。
            /// </summary>
            public DynamicMethod DynamicMethod
            {
                get { return this._DynamicMethod; }
            }

            /// <summary>
            /// 生成 Microsoft 中间语言 (MSIL) 指令。
            /// </summary>
            public ILGenerator ILGenerator
            {
                get { return this._ILGenerator; }
            }

            #endregion Properties

            #region Methods

            /// <summary>
            /// 根据给定的类型进行拆箱或转换。
            /// </summary>
            /// <param name="toType">进行拆箱或转换的类型。</param>
            public void AnyCastTo(Type toType)
            {
                this.CastTo(toType, OpCodes.Unbox_Any);
            }

            /// <summary>
            /// 调用方法或重载的方法。
            /// </summary>
            /// <param name="methodInfo">方法元数据。</param>
            public void Call(MethodInfo methodInfo)
            {
                //- 是一个静态函数、析构方法，或者不是虚函数
                if (methodInfo.IsStatic || methodInfo.IsFinal || !methodInfo.IsVirtual)
                {
                    //var ps = methodInfo.GetParameters();
                    //Type[] types = new Type[ps.Length];
                    //for(int i = 0 ; i < ps.Length ; i++)
                    //{
                    //    types[i] = ps[i].ParameterType;
                    //}
                    this._ILGenerator.EmitCall(OpCodes.Call, methodInfo, null);
                }
                else
                {
                    //- 对于 虚函数 应当调用其重载函数( override )
                    this._ILGenerator.EmitCall(OpCodes.Callvirt, methodInfo, null);
                }
            }

            /// <summary>
            /// 根据给定的类型进行拆箱或转换。
            /// </summary>
            /// <param name="toType">进行拆箱或转换的类型。</param>
            public void CastTo(Type toType)
            {
                this.CastTo(toType, OpCodes.Unbox_Any);
            }

            /// <summary>
            /// 将 fromType 转换成 toType。
            /// </summary>
            /// <param name="fromType">原类型。</param>
            /// <param name="toType">目标类型，转换后的类型。</param>
            public void CastTo(Type fromType, Type toType)
            {
                if (fromType == toType) return;

                if (toType == typeof(void))
                {
                    //- 需要转换的类型是一个 void 类型，而原类型却不是 void 类型，则移除堆栈顶部的值，取消这次转换。
                    if (fromType != typeof(void)) this.Pop();
                }
                else
                {
                    //- 原类型是一个值类型。
                    if (fromType.IsValueType)
                    {
                        if (toType.IsValueType)
                        {   //- 原类型和目标类型同为值类型
                            Convert(toType);
                            return;
                        }
                        else
                        {   //- 目标类型是一个引用类型，将原类型从值类型转换为引用类型（装箱）。
                            this._ILGenerator.Emit(OpCodes.Box, fromType);
                            throw new ArgumentException("测试，此错误。");
                        }
                    }
                    //- 进行 Unbox 或 as 转换
                    this.CastTo(toType);
                }
            }

            /// <summary>
            /// 将位于堆栈顶部的值，进行值类型转换。
            /// </summary>
            /// <param name="toType">转换后的类型。</param>
            public void Convert(Type toType)
            {
                this._ILGenerator.Emit(s_Converts[toType]);
            }
            /// <summary>
            /// 完成动态方法并创建一个可用于执行该方法的委托。
            /// </summary>
            /// <typeparam name="D">一个签名与动态方法的签名匹配的委托类型。</typeparam>
            /// <returns>一个指定类型的委托，可用于执行动态方法。</returns>
            public D CreateDelegate<D>()
                where D : class
            {
                return this._DynamicMethod.CreateDelegate(typeof(D)) as D;
            }

            /// <summary>
            /// 声明指定类型的局部变量。
            /// </summary>
            /// <param name="localType">一个 System.Type 对象，表示局部变量的类型。</param>
            /// <returns>一个 System.Reflection.Emit.LocalBuilder 对象，表示局部变量。</returns>
            public LocalBuilder DeclareLocal(Type localType)
            {
                return this._ILGenerator.DeclareLocal(localType);
            }

            /// <summary>
            /// 声明指定类型的局部变量，还可以选择固定该变量所引用的对象。
            /// </summary>
            /// <param name="localType">一个 System.Type 对象，表示局部变量的类型。</param>
            /// <param name="pinned">如果要将对象固定在内存中，则为 true；否则为 false。</param>
            /// <returns>一个 System.Reflection.Emit.LocalBuilder 对象，表示局部变量。</returns>
            public LocalBuilder DeclareLocal(Type localType, bool pinned)
            {
                return this._ILGenerator.DeclareLocal(localType, pinned);
            }

            /// <summary>
            /// 将参数地址加载到计算堆栈上。
            /// </summary>
            /// <param name="targetIsValueType">为 true 则表示值类型，否则表示引用类型。</param>
            /// <param name="argumentIndex">参数索引</param>
            public void LoadArgument(bool targetIsValueType, int argumentIndex)
            {
                if (targetIsValueType)
                {
                    LoadArgumentAddress(argumentIndex);
                }
                else
                {
                    LoadArgument(argumentIndex);
                }
            }

            /// <summary>
            /// 将引用类型参数地址加载到计算堆栈上。
            /// </summary>
            /// <param name="argumentIndex">参数索引。</param>
            public void LoadArgument(int argumentIndex)
            {
                switch (argumentIndex)
                {
                    case 0:
                        this._ILGenerator.Emit(OpCodes.Ldarg_0);
                        break;
                    case 1:
                        this._ILGenerator.Emit(OpCodes.Ldarg_1);
                        break;
                    case 2:
                        this._ILGenerator.Emit(OpCodes.Ldarg_2);
                        break;
                    case 3:
                        this._ILGenerator.Emit(OpCodes.Ldarg_3);
                        break;
                    default:
                        this.LoadArgumentAddress(argumentIndex);
                        break;
                }
            }

            /// <summary>
            /// 将值类型参数地址加载到计算堆栈上。
            /// </summary>
            /// <param name="argumentIndex">参数索引。</param>
            public void LoadArgumentAddress(int argumentIndex)
            {
                if (argumentIndex < 256)
                {
                    this._ILGenerator.Emit(OpCodes.Ldarga_S, (byte)argumentIndex);
                }
                else
                {
                    this._ILGenerator.Emit(OpCodes.Ldarga, argumentIndex);
                }
            }

            /// <summary>
            /// 将给定的整型值作为 Int32 推送到到计算堆栈上。
            /// </summary>
            /// <param name="value">整型值。</param>
            public void LoadConstant(int value)
            {
                switch (value)
                {
                    case -1:
                        this._ILGenerator.Emit(OpCodes.Ldc_I4_M1);
                        break;
                    case 0:
                        this._ILGenerator.Emit(OpCodes.Ldc_I4_0);
                        break;
                    case 1:
                        this._ILGenerator.Emit(OpCodes.Ldc_I4_1);
                        break;
                    case 2:
                        this._ILGenerator.Emit(OpCodes.Ldc_I4_2);
                        break;
                    case 3:
                        this._ILGenerator.Emit(OpCodes.Ldc_I4_3);
                        break;
                    case 4:
                        this._ILGenerator.Emit(OpCodes.Ldc_I4_4);
                        break;
                    case 5:
                        this._ILGenerator.Emit(OpCodes.Ldc_I4_5);
                        break;
                    case 6:
                        this._ILGenerator.Emit(OpCodes.Ldc_I4_6);
                        break;
                    case 7:
                        this._ILGenerator.Emit(OpCodes.Ldc_I4_7);
                        break;
                    case 8:
                        this._ILGenerator.Emit(OpCodes.Ldc_I4_8);
                        break;
                    default:
                        if (value > -129 && value < 128)
                        {
                            this._ILGenerator.Emit(OpCodes.Ldc_I4_S, (SByte)value);
                        }
                        else
                        {
                            this._ILGenerator.Emit(OpCodes.Ldc_I4, value);
                        }
                        break;
                }
            }

            /// <summary>
            /// 查找对象中其引用当前位于计算堆栈的字段的值。
            /// </summary>
            /// <param name="fieldInfo">字段元数据。</param>
            public void LoadField(FieldInfo fieldInfo)
            {
                this._ILGenerator.Emit(OpCodes.Ldfld, fieldInfo);
            }

            /// <summary>
            /// 将指定索引处的局部变量加载到计算堆栈上。
            /// </summary>
            /// <param name="local">局部变量。</param>
            public void LoadLocal(LocalBuilder local)
            {
                this._ILGenerator.Emit(OpCodes.Ldloc, local);
            }

            /// <summary> 
            /// </summary>
            /// <param name="index"></param>
            public void LoadLocal(int index)
            {
                switch (index)
                {
                    case 0:
                        this._ILGenerator.Emit(OpCodes.Ldloc_0);
                        break;
                    case 1:
                        this._ILGenerator.Emit(OpCodes.Ldloc_1);
                        break;
                    case 2:
                        this._ILGenerator.Emit(OpCodes.Ldloc_2);
                        break;
                    case 3:
                        this._ILGenerator.Emit(OpCodes.Ldloc_3);
                        break;
                    default:
                        if (index < 256)
                            this._ILGenerator.Emit(OpCodes.Ldloc_S, (byte)index);
                        else
                            this._ILGenerator.Emit(OpCodes.Ldloc, index);
                        break;
                }
            }

            /// <summary>
            /// 将位于特定索引处的局部变量的地址加载到计算堆栈上（短格式，如 ref、out）。
            /// </summary>
            /// <param name="local">局部变量。</param>
            public void LoadLocalBySpecific(LocalBuilder local)
            {
                this._ILGenerator.Emit(OpCodes.Ldloca_S, local);
            }

            /// <summary>
            /// 将空引用（O 类型）推送到计算堆栈上。
            /// </summary>
            public void LoadNull()
            {
                this._ILGenerator.Emit(OpCodes.Ldnull);
            }

            /// <summary> 
            /// </summary>
            /// <param name="type"></param>
            public void LoadObject(Type type)
            {
                this._ILGenerator.Emit(OpCodes.Ldobj, type);
            }

            /// <summary>
            /// 将位于指定数组索引处的包含对象引用的元素作为 O 类型（对象引用）加载到计算堆栈的顶部。
            /// </summary>
            public void LoadRefElement()
            {
                this._ILGenerator.Emit(OpCodes.Ldelem_Ref);
            }

            /// <summary>
            /// 将对象引用作为 O（对象引用）类型间接加载到计算堆栈上。
            /// </summary>
            public void LoadReference()
            {
                this._ILGenerator.Emit(OpCodes.Ldind_Ref);
            }

            /// <summary>
            /// 将静态字段的值推送到计算堆栈上。
            /// </summary>
            /// <param name="fieldInfo">字段元数据。</param>
            public void LoadStaticField(FieldInfo fieldInfo)
            {
                this._ILGenerator.Emit(OpCodes.Ldsfld, fieldInfo);
            }

            /// <summary>
            /// 指定成员元数据，将成员元数据的 this 参数地址加载到计算堆栈上。
            /// </summary>
            /// <param name="memberInfo">成员元数据。</param>
            public void LoadThis(MemberInfo memberInfo)
            {
                this.LoadArgument(0);
                this.CastTo(Types.Object, memberInfo.DeclaringType);
            }

            /// <summary>
            /// 创建一个值类型的新对象或新实例，并将对象引用（O 类型）推送到计算堆栈上。
            /// </summary>
            /// <param name="constructorInfo">构造函数元数据。</param>
            public void NewObject(ConstructorInfo constructorInfo)
            {
                this._ILGenerator.Emit(OpCodes.Newobj, constructorInfo);
            }

            /// <summary>
            /// 移除当前位于计算堆栈顶部的值。
            /// </summary>
            public void Pop()
            {
                this._ILGenerator.Emit(OpCodes.Pop);
            }

            /// <summary>
            /// 从当前方法返回，并将返回值（如果存在）从调用方的计算堆栈推送到被调用方的计算堆栈上。
            /// </summary>
            public void Return()
            {
                _ILGenerator.Emit(OpCodes.Ret);
            }

            /// <summary>
            /// 
            /// </summary>
            public void StoreByRef()
            {
                this._ILGenerator.Emit(OpCodes.Stind_Ref);
            }

            /// <summary>
            /// 用新值替换在对象引用或指针的字段中存储的值。
            /// </summary>
            /// <param name="fieldInfo">字段元数据。</param>
            public void StoreField(FieldInfo fieldInfo)
            {
                this._ILGenerator.Emit(OpCodes.Stfld, fieldInfo);
            }

            /// <summary>
            /// 从计算堆栈的顶部弹出当前值并将其存储到指定索引处的局部变量列表中。
            /// </summary>
            /// <param name="local">局部变量。</param>
            public void StoreLocal(LocalBuilder local)
            {
                this._ILGenerator.Emit(OpCodes.Stloc, local);
            }

            /// <summary>
            /// 用计算堆栈上的对象 ref 值（O 类型）替换给定索引处的数组元素。
            /// </summary>
            public void StoreLocalByRef()
            {
                this._ILGenerator.Emit(OpCodes.Stelem_Ref);
            }

            /// <summary>
            /// 用来自计算堆栈的值替换静态字段的值。
            /// </summary>
            /// <param name="fieldInfo">字段元数据。</param>
            public void StoreStaticField(FieldInfo fieldInfo)
            {
                this._ILGenerator.Emit(OpCodes.Stsfld, fieldInfo);
            }

            /// <summary>
            /// 尝试将值类转换为对象引用（Object 类型）。
            /// </summary>
            /// <param name="toType">转换的类型。</param>
            public void TryBox(Type toType)
            {
                if (toType.IsValueType)
                {
                    this._ILGenerator.Emit(OpCodes.Box, toType);
                }
            }

            private void CastTo(Type toType, OpCode unBoxCode)
            {
                if (toType.IsValueType)
                {
                    this._ILGenerator.Emit(unBoxCode, toType);
                }
                else
                {
                    this._ILGenerator.Emit(OpCodes.Isinst, toType);
                    //this._ILGenerator.Emit(OpCodes.Castclass, toType);
                }
            }

            #endregion Methods
        }
}
