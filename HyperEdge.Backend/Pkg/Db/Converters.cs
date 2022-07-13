using System;
using System.Data;
using Dapper;


namespace HyperEdge.Backend.Db
{

    public class BinaryUlidHandler : SqlMapper.TypeHandler<Ulid>
    {
        public override Ulid Parse(object value)
        {
            return new Ulid((byte[])value);
        }

        public override void SetValue(IDbDataParameter parameter, Ulid value)
        {
            parameter.DbType = DbType.Binary;
            parameter.Size = 16;
            parameter.Value = value.ToByteArray();
        }
    }

    public class StringUlidHandler : SqlMapper.TypeHandler<Ulid>
    {
        public override Ulid Parse(object value)
        {
            return Ulid.Parse((string)value);
        }

        public override void SetValue(IDbDataParameter parameter, Ulid value)
        {
            parameter.DbType = DbType.StringFixedLength;
            parameter.Size = 26;
            parameter.Value = value.ToString();
        }   
    }
}

