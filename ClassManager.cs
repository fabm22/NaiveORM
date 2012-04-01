using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Assemblies;
using System.Reflection;
using NaiveORM;    //Link: http://msdn.microsoft.com/fr-fr/library/ms173100(v=vs.80).aspx

namespace NaiveORM
{   /*
     * " ClassManager class uses reflection to find all classes that inherit 
     * from the ClassMapping class. In turn it creates a Class object (which
     * will later override various properties and be used to create a derived
     * type that we will use to actually store/load the information from the 
     * database). " */
    internal class ClassManager
    {
        #region Constructor 
        public ClassManager(Assembly Assembly)
        {
            LoadClasses(Assembly);
        }
        #endregion

        #region Private Variables
        
        private Dictionary<Type, Class> Classes = new Dictionary<Type, Class>();
        
        #endregion

        #region Private Functions

        private void LoadClasses( Assembly BusinessObjectsAssembly)
        {
            Type[] Types = BusinessObjectsAssembly.GetTypes();
            foreach ( Type Temp in Types )
            {
                Type _BaseType = Temp.BaseType;
                if (_BaseType != null && _BaseType.FullName.StartsWith("ClassMapping"))
                
                    Classes.Add( _BaseType.GetGenericArguments()[0], new Class(Temp) );
                    //affichage des arguments de type du Type jff
                    //foreach( Object o in _BaseType.GetGenericArguments())
                    //{
                    //    Console.Write( o.ToString);
                    //}
                }
            }
        }

        #endregion

    }

    internal class Class
    {
        public Class(Type ClassMapping) //constructor with a "Type" obj as param
        {
            IAttributeMap Item = (IAttributeMap) Activator.CreateInstance(ClassMapping);
            foreach( NaiveORM.Attribute _Property in Item.Properties)
            {
                //Here is where we'll add your property overridding at a later time
            }
        }
    }
}
