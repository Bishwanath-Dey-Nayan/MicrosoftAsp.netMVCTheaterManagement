using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLTheater
{

    public enum DataTypes
    {
        Text,
        Number,
        Integer,
        boolean,
        DateTime,
        Date
    }

    public class DBClass:System.Attribute
    {

        public string Column { get; set; }
        public DataTypes DataType { get; set; }

    }
}