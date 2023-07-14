using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EntityLayer
{
    public class EntityCloner
    {
        /// <summary>
        /// Клас EntityCloner надає зручні функції для клонування властивостей об'єктів сутностей.
        /// Він динамічно зберігає масиви властивостей для кожного типу сутності, щоб уникнути повторних викликів методу GetProperties для одного типу.
        /// Це полегшує клонування властивостей між об'єктами та забезпечує більш ефективну роботу з властивостями сутностей.
        /// </summary>
        struct DictionaryEntity
        {
            public Type entityType;
            public PropertyInfo[] entityProperties;
        }

        private static List<DictionaryEntity> propertyDictionary = new List<DictionaryEntity>();

        public static PropertyInfo[] GetProperties(Type entityType)
        {
            PropertyInfo[] result = null;
            foreach (var DE in propertyDictionary.Where(p => p.entityType == entityType))
                result = DE.entityProperties;
            if (result == null)
            {
                result = entityType.GetProperties();
                propertyDictionary.Add(
                    new DictionaryEntity()
                    {
                        entityType = entityType,
                        entityProperties = result
                    });
            }
            return result;
        }

        public static void CloneProperties<Entity>(Entity from, Entity to)
        {
            var typeofentity = typeof(Entity);
            PropertyInfo[] properties = EntityCloner.GetProperties(typeof(Entity));
            foreach (PropertyInfo property in properties)
            {
                property.SetValue(to, property.GetValue(from));
            }
        }
    }
}
