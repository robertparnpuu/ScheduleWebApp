﻿using Core;
using Domain.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Tests.Domain.Common {

    public abstract class BaseEntityTests<TEntity, TData>
        where TEntity : BaseEntity<TData>, new()
        where TData : class, IBaseEntity, new()
    {
        protected TEntity obj;
        [TestInitialize]
        public virtual void TestInitialize() => obj = CreateObject();

        [TestMethod]
        public void IdTest() => isReadOnlyProperty(obj.Data.id);

        protected virtual TEntity CreateObject() => new();

        protected virtual T getPropertyValue<T>(bool canWrite = false) => default;

        protected void isReadOnlyProperty<T>(T expected)
        {
            var actual = getPropertyValue<T>();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAllDefaultProperties()
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.Name == "id") Assert.IsTrue(IsGuid(property.GetValue(obj)));
                else if (property.PropertyType == typeof(string)) Assert.AreEqual("-", property.GetValue(obj));
                else if (property.PropertyType == typeof(int)) Assert.IsNull(property.GetValue(obj));
                else if (property.PropertyType == typeof(DateTime)) Assert.AreEqual(default(DateTime), property.GetValue(obj));
                else if (property.PropertyType == typeof(object));
            }
        }
        
        public static bool IsGuid(object value) 
        { 
            Guid x; 

            return Guid.TryParse(value.ToString(), out x);
        }
        
    }
}       
