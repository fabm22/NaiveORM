using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace NaiveORM
{
    public interface IAttributeMap //to map the attributes of the model/table
    {
        List<Attribute> Properties { get; set; }
    }

    public interface IClassMap<T>   //Map a class?, selfmade I
    {
        void ID( Expression<Func<T, object>> expression );
        void Reference( Expression<Func<T, object>> expression );
    }

    partial class ClassMapping<T> : IClassMap<T>, IAttributeMap
    {      
        private void AddAttribute_OLD(Attribute _Property, 
                Expression<Func<T, object>> expression )
        {
            _Property.Name = expression.Body.ToString();
            string[] _Splitter = { "." };
            string[] _SplitName = _Property.Name.Split( _Splitter, StringSplitOptions.None);
            _Property.Name = _SplitName[ _SplitName.Length-1 ];
            _Property.Type = expression.Body.Type;
            _Properties.Add(_Property);
        }


        #region IAttributeMap Members
        private List<Attribute> _Properties = new List<Attribute>();
        //public List<Attribute> Properties //'implemented' from interface
        //{
        //    get
        //    {
        //        return _Properties; //throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        _Properties = value;    //throw new NotImplementedException();
        //    }
        //}
        #endregion
    }

}
