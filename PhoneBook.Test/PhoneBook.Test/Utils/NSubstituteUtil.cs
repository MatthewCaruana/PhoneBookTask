using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Test.Utils
{
    public static class NSubstituteUtil
    {
        public static DbSet<T> CreateMockSet<T>(IEnumerable<T> data) where T : class
        {
            return CreateMockSet(data.AsQueryable());
        }
        public static DbSet<T> CreateMockSet<T>(T[] data) where T : class
        {
            return CreateMockSet(data.AsQueryable());
        }

        public static DbSet<T> CreateMockSet<T>(IQueryable<T> data) where T : class
        {
            IQueryable<T> queryableData = data.AsQueryable();

            DbSet<T> mockSet = Substitute.For<DbSet<T>, IQueryable<T>>();

            if (data != null)
            {
                ((IQueryable<T>)mockSet).Provider.Returns(queryableData.Provider);
                ((IQueryable<T>)mockSet).Expression.Returns(queryableData.Expression);
                ((IQueryable<T>)mockSet).ElementType.Returns(queryableData.ElementType);
                ((IQueryable<T>)mockSet).GetEnumerator().Returns(queryableData.GetEnumerator());
            }

            return mockSet;
        }
    }
}
