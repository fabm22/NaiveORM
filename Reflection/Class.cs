using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;

namespace NaiveORM.Reflection
{
    internal partial class Class
    {
        private List<Property> _Properties = new List<Property>();

        public Class(Type ClassMapping) //constructor with a "Type" obj as param
        {
            IAttributeMap Item = (IAttributeMap)Activator.CreateInstance(ClassMapping);

            foreach (NaiveORM.Attribute _Property in Item.Properties)
            {
                //Here is where we'll add your property overridding at a later time
            }
        }

        public Class(Type Class, ModuleBuilder Module) //other constructor
        {
            Type BaseType = Class.BaseType;
            Type GenericType = BaseType.GetGenericArguments() [0];
            TypeBuilder TypeBuilder = Module.DefineType("NaiveORM0ClassesM."+ GenericType.Name + "Derived",
                TypeAttributes.Public, GenericType);

         //   FieldBuilder ChangedField = CreateChangedClearMethod(TypeBuilder);
        }

        //le mec manipule le code MSIL pour générer les classes objets de notre domaine...?
        private void CreateChangedClearMethod(TypeBuilder TypeBuilder, FieldBuilder ChangedField)
        {
            MethodBuilder MyMethod = TypeBuilder.DefineMethod("ClearChanged0", MethodAttributes.Public,
                typeof(void), new Type[0]);
            ILGenerator Generator = MyMethod.GetILGenerator();
            Generator.Emit(OpCodes.Ldarg_0);
            Generator.Emit(OpCodes.Ldfld, ChangedField);
            Generator.Emit(OpCodes.Callvirt, typeof(List<String>).GetMethod("Clear"));
            Generator.Emit(OpCodes.Ret);
            
        }

        private void CreateChangedClearMethod()
        {

        }

        private void OverrideProperties(TypeBuilder TypeBuilder, FieldBuilder ChangedField, Type ClassMapper)
        {
            IAttributeMap Item = (IAttributeMap)Activator.CreateInstance(ClassMapper);
            foreach (Attribute Property in Item.Properties)
            {
                if (Property.AttributeType == AttributeType.ID || Property.AttributeType == AttributeType.Reference)
                {
                   Properties.Add(new Property
                }
            }
        }
    }
}