using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaiveORM
{
    class Attribute
    {
        public Attribute(){}

        private string _Name = "";
        private Type _Type = null;
        private AttributeType _AttributeType = AttributeType.ID;
        private bool _Cascade;
        private string _MappedProperty;

        public bool Cascade
        {
            get { return _Cascade; }
            set { _Cascade = value; }
        }

        public string MappedProperty
        {
            get { return _MappedProperty; }
            set { _MappedProperty = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value;}
        }

        public Type Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public AttributeType AttributeType
        {
            get { return _AttributeType; }
            set { _AttributeType = value; }
        }
    }

    public enum AttributeType // to check les enum en C#
    {
        ID = 0,
        Reference,
        Map,
        ManyToOne,
        ManyToMany
    }

    //class AttributeType //to check later..
    //{
    //    public static AttributeType ID { get; set; }
    //}
}
