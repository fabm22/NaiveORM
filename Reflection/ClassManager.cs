using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration.Assemblies;
using System.Reflection;
using System.Reflection.Emit;
using NaiveORM;    //Link: http://msdn.microsoft.com/fr-fr/library/ms173100(v=vs.80).aspx
using System.Threading;


namespace NaiveORM.Reflection
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
            CreateAssembly();
            LoadClasses(Assembly);
            foreach (Type Key in Classes.Keys)
            {
                object CreatedClass = Activator.CreateInstance(this[Key].DerivedType);
            }
        }
        #endregion

        #region Private Variables

        private Dictionary<Type, Class> Classes = new Dictionary<Type, Class>(); //dico assoc. type et classe
        private AssemblyBuilder _Builder = null;
        private ModuleBuilder _Module = null;

        #endregion

        #region Private Functions

        private void CreateAssembly()
        {  //to create an assembly programmatically
            AssemblyName Name = new AssemblyName("NaiveORM0Classes");
            AppDomain Domain = Thread.GetDomain();
            _Builder = Domain.DefineDynamicAssembly(Name, AssemblyBuilderAccess.Run);
            _Module = _Builder.DefineDynamicModule("NaiveORM0ClassesM");
        }

        private void LoadClasses(Assembly BusinessObjectsAssembly)
        {
            Type[] Types = BusinessObjectsAssembly.GetTypes();
            foreach (Type Temp in Types)
            {
                Type _BaseType = Temp.BaseType;
                if (_BaseType != null && _BaseType.FullName.StartsWith("ClassMapping"))

                    Classes.Add(_BaseType.GetGenericArguments()[0], new Class(Temp));
                //affichage des arguments de type du Type jff
                //foreach( Object o in _BaseType.GetGenericArguments())
                //{
                //    Console.Write( o.ToString);
                //}
            }
        }
    }
        #endregion

    #region Public Properties

    /* Gets the associated class with the type
         * param Type value
         * returns generated class associated
         */
    ////public Reflection.Class this[ Type value ]
    ////{
    ////    get
    ////    { 
    ////        return Classes[value]; 
    ////    }
    ////}
    #endregion  
}
    


