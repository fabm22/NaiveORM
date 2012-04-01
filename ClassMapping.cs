using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace NaiveORM
{
    /*
     * entre autres, on va implémenter les OneToMany, ManyToOne, OneToOne etc.
     */
    partial class ClassMapping<T> : IClassMap<T>, IAttributeMap
    {
        public void AddAttribute(Attribute _Property, Expression<Func<T, object>> expression)
        {
            string[] _SplitName=null;
            if (expression.Body.NodeType == ExpressionType.Convert)
            {
                _Property.Name = expression.Body.ToString()
                        .Replace("Convert(", "").Replace(")", "");
                string[] _Splitter = { "." };
                _SplitName = _Property.Name.Split(_Splitter, StringSplitOptions.None);
                _Property.Name = _SplitName[_SplitName.Length - 1]; //last?
                UnaryExpression _TempUnaryExp = (UnaryExpression)expression.Body;
                _Property.Type = _TempUnaryExp.Operand.Type;
            }
            else 
            {
                _Property.Name = expression.Body.ToString();
                string[] _Splitter = {"."};
                _SplitName = _Property.Name.Split(_Splitter, StringSplitOptions.None);
                _Property.Name = _SplitName[_Splitter.Length-1];
                _Property.Type = expression.Body.Type;
            }
            _Properties.Add(_Property);
        }


        public void ID(Expression<Func<T, object>> expression)
        {
            Attribute _ID = new Attribute();
            _ID.AttributeType = AttributeType.ID;
            AddAttribute(_ID, expression); //from 'ClassMapping<T>', juste au dessus
        }

        public void Reference(Expression<Func<T, object>> expression) //donc on crée un nouveau attribut qui est une référence ici
        {
            Attribute _ID = new Attribute();
            _ID.AttributeType = AttributeType.ID;
            AddAttribute(_ID, expression);
        }

    // Mapping
        public void Map(Expression<Func<T,object>> expression,
            string _MappedProperty, bool _Cascade)
        {
            Attribute _ID = new Attribute();
            _ID.AttributeType = AttributeType.Map;
            _ID.MappedProperty = _MappedProperty;
            _ID.Cascade = _Cascade;
            AddAttribute(_ID, expression);
        }

        public void ManyToOne(Expression<Func<T,object>> expression,
            string _MappedProperty, bool _Cascade)
        {
            Attribute _ID = new Attribute();
            _ID.AttributeType = AttributeType.ManyToOne;
            _ID.MappedProperty = _MappedProperty;
            _ID.Cascade = _Cascade;
            AddAttribute(_ID, expression);
        }

        public void ManyToMany(Expression<Func<T, object>> expression,
            string _MappedProperty, bool _Cascade)
        {
            Attribute _ID = new Attribute();
            _ID.AttributeType = AttributeType.ManyToMany;
            _ID.MappedProperty = _MappedProperty;
            _ID.Cascade = _Cascade;
            AddAttribute(_ID, expression);
        }

        #region IAttributeMap Members
        public List<Attribute> Properties
        {
            get { return _Properties; }
            set { _Properties = value; }
        }
        #endregion
    }
}
