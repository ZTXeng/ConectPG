using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkPG
{
    [DbConfigurationType(typeof(AppDbContextConfiguration))]
    public class AppDbContext
    {
    }

    public class AppDbContextConfiguration : DbConfiguration
    {
        public AppDbContextConfiguration()
        {
            this.AddInterceptor(new MyEntityFrameworkInterceptor());
        }
    }

    class MyEntityFrameworkInterceptor : DbCommandInterceptor
    {
        public override void ReaderExecuted(
            DbCommand command,
            DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            if (interceptionContext.Result == null) return;
            interceptionContext.Result = new WrappingDbDataReader(interceptionContext.Result);
        }

        public override void ScalarExecuted(
            DbCommand command,
            DbCommandInterceptionContext<object> interceptionContext)
        {
            interceptionContext.Result = ModifyReturnValues(interceptionContext.Result);
        }

        static object ModifyReturnValues(object result)
        {
            // Transform and then
            return result;
        }
    }


    class WrappingDbDataReader : DbDataReader, IDataReader
    {
        // Wrap an existing DbDataReader, proxy all calls to the underlying instance,
        // modify return values and/or parameters as needed...
        public WrappingDbDataReader(DbDataReader reader)
        {
        }

        public override object this[int ordinal] => throw new NotImplementedException();

        public override object this[string name] => throw new NotImplementedException();

        public override int Depth => throw new NotImplementedException();

        public override int FieldCount => throw new NotImplementedException();

        public override bool HasRows => throw new NotImplementedException();

        public override bool IsClosed => throw new NotImplementedException();

        public override int RecordsAffected => throw new NotImplementedException();

        public override bool GetBoolean(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override byte GetByte(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            throw new NotImplementedException();
        }

        public override char GetChar(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            throw new NotImplementedException();
        }

        public override string GetDataTypeName(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetDateTime(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override decimal GetDecimal(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override double GetDouble(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override Type GetFieldType(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override float GetFloat(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override Guid GetGuid(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override short GetInt16(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override int GetInt32(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override long GetInt64(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override string GetName(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override int GetOrdinal(string name)
        {
            throw new NotImplementedException();
        }

        public override string GetString(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override object GetValue(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public override bool IsDBNull(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override bool NextResult()
        {
            throw new NotImplementedException();
        }

        public override bool Read()
        {
            throw new NotImplementedException();
        }
    }

}
