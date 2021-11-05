using System;
using System.Linq.Expressions;
using WebApplication.EfCore;

namespace WebApplication
{
    public class TenantFilterProvider
    {
        private readonly CurrentTenant _currentTenant;

        public TenantFilterProvider(CurrentTenant currentTenant)
        {
            _currentTenant = currentTenant;
        }
        
        public LambdaExpression GetExpression()
        {
            Expression<Func<MyEntity, bool>> expression = entity => entity.TenantId == _currentTenant.TenantId;

            return expression;
        }
    }
}