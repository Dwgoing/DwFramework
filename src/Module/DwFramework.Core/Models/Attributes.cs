﻿using System;

namespace DwFramework.Core
{
    /// <summary>
    /// 可注册的对象
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class RegisterableAttribute : Attribute
    {
        public Type InterfaceType { get; private set; }
        public Lifetime Lifetime { get; private set; }
        public bool IsAutoActivate { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="interfaceType"></param>
        /// <param name="lifetime"></param>
        /// <param name="isAutoActivate"></param>
        public RegisterableAttribute(Type interfaceType = null, Lifetime lifetime = Lifetime.InstancePerDependency, bool isAutoActivate = false)
        {
            InterfaceType = interfaceType;
            Lifetime = lifetime;
            IsAutoActivate = isAutoActivate;
        }
    }
}
