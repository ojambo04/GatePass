﻿using Ardalis.Specification;

namespace GatePass.Core.PassAggregate.Specifications
{
    public class SinglePassByVisitorIdPaginationSpec : Specification<SinglePass>
    {
        public SinglePassByVisitorIdPaginationSpec(int pageIndex, int pageSize, Guid visitorId)
        {
            Query
                .OrderByDescending(p => p.VisitDate)
                .Where(p => p.VisitorId == visitorId)
                .Skip(pageIndex * pageSize)
                .Take(pageSize);
        }
    }
}
